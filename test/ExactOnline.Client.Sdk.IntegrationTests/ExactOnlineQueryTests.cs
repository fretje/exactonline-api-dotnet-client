using ExactOnline.Client.Models.CRM;
using ExactOnline.Client.Models.Financial;
using ExactOnline.Client.Sdk.Exceptions;

namespace ExactOnline.Client.Sdk.IntegrationTests;

[TestClass]
public class ExactOnlineQueryTests
{
	public TestContext TestContext { get; set; } = default!;

	[TestMethod]
	[TestCategory("Integration Tests")]
	public async Task GetSpecificCollectionUsingOData_WithOutOData()
	{
		var client = await new TestObjectsCreator().GetClientAsync(TestContext.CancellationToken);

		var accounts = client.For<GLAccount>()
			.Select("Code")
			.Get();

		if (accounts.Count is 0)
		{
			throw new Exception("The collection of Account entities is empty");
		}
	}

	[TestMethod]
	[TestCategory("Integration Tests")]
	public async Task GetSpecificCollectionUsingOData_WithWhere()
	{
		var client = await new TestObjectsCreator().GetClientAsync(TestContext.CancellationToken);

		var accounts = client.For<GLAccount>()
			.Select("Code")
			.Where($"Description+eq+'{TestObjectsCreator.SpecificGLAccountDescription}'")
			.Get();

		if (accounts.Count is 0)
		{
			throw new Exception("The collection of Account entities is empty");
		}
	}

	[TestMethod]
	[TestCategory("Integration Tests")]
	public async Task GetSpecificCollectionUsingOData_WithWhereAndAnd()
	{
		var client = await new TestObjectsCreator().GetClientAsync(TestContext.CancellationToken);

		var accounts = client.For<GLAccount>()
			.Select("Code")
			.Where($"Description+eq+'{TestObjectsCreator.SpecificGLAccountDescription}'")
			.And($"Code+eq+'{TestObjectsCreator.SpecificGLAccountCode}'")
			.Get();

		if (accounts.Count is 0)
		{
			throw new Exception("The collection of Account entities is empty");
		}
	}

	// Is allready being tested in unit tests
	[TestMethod, Ignore]
	[TestCategory("Integration Tests")]
	public async Task GetSpecificCollectionUsingOData_WithNonExistingEntity()
	{
		var client = await new TestObjectsCreator().GetClientAsync(TestContext.CancellationToken);

		Assert.Throws<Exception>(() =>
			client.For<object>()
				.Where($"Description+eq+'{TestObjectsCreator.SpecificGLAccountDescription}'")
				.Get());
	}

	[TestMethod]
	[TestCategory("Integration Tests")]
	public async Task GetSpecificCollectionUsingOData_WithNonExistingField()
	{
		var client = await new TestObjectsCreator().GetClientAsync(TestContext.CancellationToken);

		Assert.Throws<BadRequestException>(() =>
			client.For<Account>()
				.Select("Code")
				.Where($"Description+eq+'{TestObjectsCreator.SpecificGLAccountDescription}'")
				.Get());
	}

	[TestMethod]
	[TestCategory("Integration Tests")]
	public async Task ExactOnlineQuery_WithCorrectProperty_Succeeds()
	{
		var client = await new TestObjectsCreator().GetClientAsync(TestContext.CancellationToken);

		var accounts = client.For<Account>()
			.Select("Code")
			.Get();

		Assert.IsGreaterThan(1, accounts.Count);
	}

	[TestMethod]
	[TestCategory("Integration Tests")]
	public async Task ExactOnlineQuery_WithWrongProperty_Fails()
	{
		var client = await new TestObjectsCreator().GetClientAsync(TestContext.CancellationToken);

		Assert.Throws<BadRequestException>(() => client.For<Account>().Select("Xxx").Get());
	}
}
