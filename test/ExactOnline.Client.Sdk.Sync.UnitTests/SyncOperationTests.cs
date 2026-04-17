using ExactOnline.Client.Models.CRM;
using ExactOnline.Client.Sdk.Controllers;
using ExactOnline.Client.Sdk.Sync;

namespace ExactOnline.Client.Sdk.Sync.UnitTests;

[TestClass]
public class SyncOperationTests
{
	private static ExactOnlineClient CreateClient() =>
		new("https://example.com/", division: 1, accesstokenFunc: _ => Task.FromResult("token"));

	[TestMethod]
	[TestCategory("Unit Test")]
	public void Ctor_NullClient_Throws() =>
		Assert.Throws<ArgumentNullException>(() => new SyncOperation<Account>(null!));

	[TestMethod]
	[TestCategory("Unit Test")]
	public void For_ReturnsOperationBoundToClient()
	{
		var client = CreateClient();

		var op = SyncOperation.For<Account>(client);

		Assert.IsNotNull(op);
	}

	[TestMethod]
	[TestCategory("Unit Test")]
	public void WithMaxTimestamp_NullDelegate_Throws()
	{
		var op = SyncOperation.For<Account>(CreateClient());

		Assert.Throws<ArgumentNullException>(() => op.WithMaxTimestamp(null!));
	}

	[TestMethod]
	[TestCategory("Unit Test")]
	public void WithMaxModified_NullDelegate_Throws()
	{
		var op = SyncOperation.For<Account>(CreateClient());

		Assert.Throws<ArgumentNullException>(() => op.WithMaxModified(null!));
	}

	[TestMethod]
	[TestCategory("Unit Test")]
	public void OnPage_NullDelegate_Throws()
	{
		var op = SyncOperation.For<Account>(CreateClient());

		Assert.Throws<ArgumentNullException>(() => op.OnPage(null!));
	}

	[TestMethod]
	[TestCategory("Unit Test")]
	public void OnDeletedPage_NullDelegate_Throws()
	{
		var op = SyncOperation.For<Account>(CreateClient());

		Assert.Throws<ArgumentNullException>(() => op.OnDeletedPage(null!));
	}

	[TestMethod]
	[TestCategory("Unit Test")]
	public void ReportProgress_NullDelegate_Throws()
	{
		var op = SyncOperation.For<Account>(CreateClient());

		Assert.Throws<ArgumentNullException>(() => op.ReportProgress(null!));
	}

	[TestMethod]
	[TestCategory("Unit Test")]
	public void FluentChain_ReturnsSameInstance()
	{
		var op = SyncOperation.For<Account>(CreateClient());

		var after = op
			.WithFields("Code")
			.WithMaxTimestamp(_ => Task.FromResult(0L))
			.WithMaxModified(_ => Task.FromResult<DateTime?>(null))
			.OnPage(_ => Task.FromResult(0))
			.OnDeletedPage(_ => Task.FromResult(0))
			.ReportProgress(_ => { });

		Assert.AreSame(op, after);
	}

	[TestMethod]
	[TestCategory("Unit Test")]
	public void WithFields_NullArray_TreatedAsEmpty()
	{
		var op = SyncOperation.For<Account>(CreateClient());

		var same = op.WithFields(null!);

		Assert.AreSame(op, same);
	}
}
