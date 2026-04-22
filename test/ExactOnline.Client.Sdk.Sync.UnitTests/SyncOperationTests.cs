using ExactOnline.Client.Models.CRM;
using ExactOnline.Client.Sdk.Controllers;
using ExactOnline.Client.Sdk.Sync;

namespace ExactOnline.Client.Sdk.Sync.UnitTests;

[TestClass]
public class SyncOperationTests
{
	private static ExactOnlineClient CreateClient() =>
		new("https://example.com/", division: 1, accesstokenFunc: _ => Task.FromResult("token"));

	private static SyncOperation<Account> CreateOperation() =>
		CreateClient().For<Account>().Synchronize();

	[TestMethod]
	[TestCategory("Unit Test")]
	public void Ctor_NullQuery_Throws() =>
		Assert.Throws<ArgumentNullException>(() => new SyncOperation<Account>(null!));

	[TestMethod]
	[TestCategory("Unit Test")]
	public void Synchronize_ReturnsOperationBoundToClient()
	{
		var op = CreateOperation();

		Assert.IsNotNull(op);
	}

	[TestMethod]
	[TestCategory("Unit Test")]
	public void OnGetMaxTimestamp_NullDelegate_Throws()
	{
		var op = CreateOperation();

		Assert.Throws<ArgumentNullException>(() => op.OnGetMaxTimestamp(null!));
	}

	[TestMethod]
	[TestCategory("Unit Test")]
	public void OnGetMaxModified_NullDelegate_Throws()
	{
		var op = CreateOperation();

		Assert.Throws<ArgumentNullException>(() => op.OnGetMaxModified(null!));
	}

	[TestMethod]
	[TestCategory("Unit Test")]
	public void OnChangedEntities_NullDelegate_Throws()
	{
		var op = CreateOperation();

		Assert.Throws<ArgumentNullException>(() => op.OnChangedEntities(null!));
	}

	[TestMethod]
	[TestCategory("Unit Test")]
	public void OnDeletedEntities_NullDelegate_Throws()
	{
		var op = CreateOperation();

		Assert.Throws<ArgumentNullException>(() => op.OnDeletedEntities(null!));
	}

	[TestMethod]
	[TestCategory("Unit Test")]
	public void OnProgress_NullDelegate_Throws()
	{
		var op = CreateOperation();

		Assert.Throws<ArgumentNullException>(() => op.OnProgress(null!));
	}

	[TestMethod]
	[TestCategory("Unit Test")]
	public void FluentChain_ReturnsSameInstance()
	{
		var op = CreateOperation();

		var after = op
			.OnGetMaxTimestamp(_ => Task.FromResult(0L))
			.OnGetMaxModified(_ => Task.FromResult<DateTime?>(null))
			.OnChangedEntities(_ => Task.FromResult(0))
			.OnDeletedEntities(_ => Task.FromResult(0))
			.OnProgress(_ => { });

		Assert.AreSame(op, after);
	}
}
