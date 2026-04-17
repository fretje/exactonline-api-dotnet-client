using ExactOnline.Client.Sdk.Enums;
using ExactOnline.Client.Sdk.Sync;

namespace ExactOnline.Client.Sdk.Sync.UnitTests;

[TestClass]
public class SyncPageContextTests
{
	private sealed class Dummy { public int Id { get; set; } }

	[TestMethod]
	[TestCategory("Unit Test")]
	public void InitBlock_AssignsAllRequiredMembers()
	{
		var entities = new List<Dummy> { new() { Id = 1 } };
		var raw = new List<Dummy> { new() { Id = 1 }, new() { Id = 1 } };
		var fields = new[] { "Id" };
		using var cts = new CancellationTokenSource();

		var context = new SyncPageContext<Dummy>
		{
			Entities = entities,
			RawEntities = raw,
			PageIndex = 3,
			SkipToken = "tok",
			MaxTimestamp = 42L,
			MaxModified = new DateTime(2026, 4, 17),
			Fields = fields,
			EndpointType = EndpointTypeEnum.Sync,
			CancellationToken = cts.Token,
		};

		Assert.AreSame(entities, context.Entities);
		Assert.AreSame(raw, context.RawEntities);
		Assert.AreEqual(3, context.PageIndex);
		Assert.AreEqual("tok", context.SkipToken);
		Assert.AreEqual(42L, context.MaxTimestamp);
		Assert.AreEqual(new DateTime(2026, 4, 17), context.MaxModified);
		Assert.AreSame(fields, context.Fields);
		Assert.AreEqual(EndpointTypeEnum.Sync, context.EndpointType);
		Assert.AreEqual(cts.Token, context.CancellationToken);
	}

	[TestMethod]
	[TestCategory("Unit Test")]
	public void InitBlock_AllowsNullOptionalMembers()
	{
		var context = new SyncPageContext<Dummy>
		{
			Entities = [],
			RawEntities = [],
			PageIndex = 0,
			MaxTimestamp = 0L,
			Fields = [],
			EndpointType = EndpointTypeEnum.Bulk,
			CancellationToken = CancellationToken.None,
		};

		Assert.IsNull(context.SkipToken);
		Assert.IsNull(context.MaxModified);
	}
}
