namespace ExactOnline.Client.Sdk.Models;

public class MinutelyChangedEventArgs : EventArgs
{
	public MinutelyChangedEventArgs(int newRemaining, DateTime newResetTime) =>
		(NewRemaining, NewResetTime) = (newRemaining, newResetTime);

	public int NewRemaining { get; }
	public DateTime NewResetTime { get; }
}
