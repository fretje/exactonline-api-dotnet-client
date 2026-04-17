using ExactOnline.Client.Sdk.Sync;

namespace ExactOnline.Client.Sdk.Sync.UnitTests;

[TestClass]
public class SyncProgressTests
{
	[TestMethod]
	[TestCategory("Unit Test")]
	public void Ctor_AssignsAllCounters()
	{
		var progress = new SyncProgress(
			recordsRead: 10,
			recordsInsertedOrUpdated: 7,
			recordsDeletedRead: 3,
			recordsDeleted: 2,
			pageIndex: 4);

		Assert.AreEqual(10, progress.RecordsRead);
		Assert.AreEqual(7, progress.RecordsInsertedOrUpdated);
		Assert.AreEqual(3, progress.RecordsDeletedRead);
		Assert.AreEqual(2, progress.RecordsDeleted);
		Assert.AreEqual(4, progress.PageIndex);
	}

	[TestMethod]
	[TestCategory("Unit Test")]
	public void ToString_IncludesAllCounters()
	{
		var progress = new SyncProgress(10, 7, 3, 2, 4);

		var text = progress.ToString();

		Assert.AreEqual("page=4 read=10 upserted=7 deletedRead=3 deleted=2", text);
	}
}
