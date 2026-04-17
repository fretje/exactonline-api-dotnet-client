namespace ExactOnline.Client.Sdk.Sync;

/// <summary>Context passed to the per-page delete handler.</summary>
public sealed class DeletedPageContext
{
	/// <summary>Initializes a delete-page context.</summary>
	public DeletedPageContext(Guid[] entityKeys, int pageIndex, string? skipToken, long maxTimestamp, CancellationToken cancellationToken)
	{
		EntityKeys = entityKeys;
		PageIndex = pageIndex;
		SkipToken = skipToken;
		MaxTimestamp = maxTimestamp;
		CancellationToken = cancellationToken;
	}

	/// <summary>Entity keys reported as deleted on this page.</summary>
	public Guid[] EntityKeys { get; }
	/// <summary>0-based page counter within the delete loop.</summary>
	public int PageIndex { get; }
	/// <summary>Skiptoken for the next delete page (<see langword="null"/> on the last page).</summary>
	public string? SkipToken { get; }
	/// <summary>Watermark the run started from (<c>Timestamp</c>).</summary>
	public long MaxTimestamp { get; }
	/// <summary>Cancellation token for the run.</summary>
	public CancellationToken CancellationToken { get; }
}
