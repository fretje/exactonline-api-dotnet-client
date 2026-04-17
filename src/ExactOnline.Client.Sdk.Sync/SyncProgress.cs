namespace ExactOnline.Client.Sdk.Sync;

/// <summary>Progress snapshot reported during a <see cref="SyncOperation{TModel}"/> run.</summary>
/// <remarks>Initializes a new snapshot with the cumulative counters at a given page.</remarks>
public readonly struct SyncProgress(int recordsRead, int recordsInsertedOrUpdated, int recordsDeletedRead, int recordsDeleted, int pageIndex)
{
	/// <summary>Total rows read from the upsert feed so far.</summary>
	public int RecordsRead { get; } = recordsRead;

	/// <summary>Total rows the upsert callback reported as persisted so far.</summary>
	public int RecordsInsertedOrUpdated { get; } = recordsInsertedOrUpdated;

	/// <summary>Total keys read from the deletion feed so far.</summary>
	public int RecordsDeletedRead { get; } = recordsDeletedRead;

	/// <summary>Total rows the deletion callback reported as removed so far.</summary>
	public int RecordsDeleted { get; } = recordsDeleted;

	/// <summary>0-based counter of the page that produced this snapshot.</summary>
	public int PageIndex { get; } = pageIndex;

	/// <inheritdoc />
	public override string ToString() =>
		$"page={PageIndex} read={RecordsRead} upserted={RecordsInsertedOrUpdated} deletedRead={RecordsDeletedRead} deleted={RecordsDeleted}";
}
