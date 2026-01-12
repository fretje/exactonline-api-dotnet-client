using System.Diagnostics;

namespace ExactOnline.Client.OAuth2.WinForms;

/// <summary>
/// From https://stackoverflow.com/a/57626659/101371
/// </summary>
public sealed class WinFormsApartment : IDisposable
{
	readonly Thread _thread; // the STA thread

	readonly TaskScheduler _taskScheduler; // the STA thread's task scheduler

	readonly Task _completion; // to keep track of the STA thread completion

	readonly object _lock = new();

	public TaskScheduler TaskScheduler => _taskScheduler;

	public Task Completion => _completion;

	/// <summary>MessageLoopApartment constructor</summary>
	public WinFormsApartment(Func<Form> createForm)
	{
		TaskCompletionSource<TaskScheduler> schedulerTcs = new();

		TaskCompletionSource<bool> threadEndTcs = new(TaskCreationOptions.RunContinuationsAsynchronously);

		// start an STA thread and gets a task scheduler
		_thread = new(_ =>
		{
			try
			{
				// handle Application.Idle just once
				// to make sure we're inside the message loop
				// and the proper synchronization context has been correctly installed

				void onIdle(object? s, EventArgs e)
				{
					Application.Idle -= onIdle;
					// make the task scheduler available
					schedulerTcs.SetResult(TaskScheduler.FromCurrentSynchronizationContext());
				};

				Application.Idle += onIdle;
				Application.Run(createForm());

				threadEndTcs.TrySetResult(true);
			}
			catch (Exception ex)
			{
				threadEndTcs.TrySetException(ex);
			}
		});

		async Task waitForThreadEndAsync()
		{
			// we use TaskCreationOptions.RunContinuationsAsynchronously
			// to make sure thread.Join() won't try to join itself
			Debug.Assert(Thread.CurrentThread != _thread);
			try
			{
				await threadEndTcs.Task.ConfigureAwait(false);
			}
			finally
			{
				_thread.Join();
			}
		}

		_thread.SetApartmentState(ApartmentState.STA);
		_thread.IsBackground = true;
		_thread.Start();

		_taskScheduler = schedulerTcs.Task.Result;
		_completion = waitForThreadEndAsync();
	}

	// TODO: it's here for debugging leaks
	public static readonly WeakReference s_debugTaskRef = new(null);

	/// <summary>shutdown the STA thread</summary>
	public void Dispose()
	{
		lock (_lock)
		{
			if (Thread.CurrentThread == _thread)
				throw new InvalidOperationException();

			if (!_completion.IsCompleted)
			{
				// execute Application.ExitThread() on the STA thread
				var terminatorTask = Run(Application.ExitThread);

				s_debugTaskRef.Target = terminatorTask; // TODO: it's here for debugging leaks

				_completion.GetAwaiter().GetResult();
			}
		}
	}

	// Task.Factory.StartNew wrappers
	public Task Run(Action action, CancellationToken token = default) =>
		Task.Factory.StartNew(action, token, TaskCreationOptions.None, _taskScheduler);

	public Task<TResult> Run<TResult>(Func<TResult> action, CancellationToken token = default) =>
		Task.Factory.StartNew(action, token, TaskCreationOptions.None, _taskScheduler);

	public Task Run(Func<Task> action, CancellationToken token = default) =>
		Task.Factory.StartNew(action, token, TaskCreationOptions.None, _taskScheduler).Unwrap();

	public Task<TResult> Run<TResult>(Func<Task<TResult>> action, CancellationToken token = default) =>
		Task.Factory.StartNew(action, token, TaskCreationOptions.None, _taskScheduler).Unwrap();
}
