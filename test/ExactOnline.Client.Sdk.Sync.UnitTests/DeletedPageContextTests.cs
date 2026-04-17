using ExactOnline.Client.Sdk.Sync;

namespace ExactOnline.Client.Sdk.Sync.UnitTests;

[TestClass]
public class DeletedPageContextTests
{
	[TestMethod]
	[TestCategory("Unit Test")]
	public void Ctor_AssignsAllProperties()
	{
		var keys = new[] { Guid.NewGuid(), Guid.NewGuid() };
		using var cts = new CancellationTokenSource();

		var context = new DeletedPageContext(
			entityKeys: keys,
			pageIndex: 2,
			skipToken: "abc",
			maxTimestamp: 1234L,
			cancellationToken: cts.Token);

		Assert.AreSame(keys, context.EntityKeys);
		Assert.AreEqual(2, context.PageIndex);
		Assert.AreEqual("abc", context.SkipToken);
		Assert.AreEqual(1234L, context.MaxTimestamp);
		Assert.AreEqual(cts.Token, context.CancellationToken);
	}

	[TestMethod]
	[TestCategory("Unit Test")]
	public void Ctor_AcceptsNullSkipToken()
	{
		var context = new DeletedPageContext(
			entityKeys: [],
			pageIndex: 0,
			skipToken: null,
			maxTimestamp: 0L,
			cancellationToken: CancellationToken.None);

		Assert.IsNull(context.SkipToken);
	}
}
