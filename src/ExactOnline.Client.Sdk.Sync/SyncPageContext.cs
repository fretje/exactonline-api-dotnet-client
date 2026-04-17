using ExactOnline.Client.Sdk.Enums;

namespace ExactOnline.Client.Sdk.Sync;

/// <summary>Context passed to the per-page upsert handler.</summary>
public sealed class SyncPageContext<TModel>
{
	/// <summary>Deduplicated entities ready to persist (after <c>FilterDoubles</c> for sync-feed endpoints).</summary>
	public required IReadOnlyList<TModel> Entities { get; init; }
	/// <summary>Original page as returned by the API — useful if you need the raw sync-feed history.</summary>
	public required IReadOnlyList<TModel> RawEntities { get; init; }
	/// <summary>0-based page counter within the run.</summary>
	public required int PageIndex { get; init; }
	/// <summary>Skiptoken for the next page (null on the last page).</summary>
	public string? SkipToken { get; init; }
	/// <summary>Watermark the run started from (<c>Timestamp</c>).</summary>
	public required long MaxTimestamp { get; init; }
	/// <summary>Watermark the run started from (<c>Modified</c>).</summary>
	public DateTime? MaxModified { get; init; }
	/// <summary>Final list of selected fields (identifier/timestamp/modified added automatically).</summary>
	public required string[] Fields { get; init; }
	/// <summary>Chosen endpoint: <c>Sync</c>, <c>Bulk</c> or <c>Single</c>.</summary>
	public required EndpointTypeEnum EndpointType { get; init; }
	/// <summary>Cancellation token for the run.</summary>
	public required CancellationToken CancellationToken { get; init; }
}
