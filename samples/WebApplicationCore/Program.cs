using System.Diagnostics;
using ExactOnline.Client.Models.CRM;
using ExactOnline.Client.OAuth2;
using ExactOnline.Client.Sdk.Controllers;
using ExactOnline.Client.Sdk.Sync;
using ExactOnline.Client.Sdk.Sync.EntityFrameworkCore;
using ExactOnline.Client.Sdk.Test.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// This is only necessary to be able to add migrations.
builder.Services.AddDbContext<EntityFrameworkCoreDbContext>(b => b.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=ExactOnlineClientSdkSyncTest;Integrated Security=True;MultipleActiveResultSets=True"));

var app = builder.Build();

// Configure the HTTP request pipeline.

var testApp = new TestApp(@"..\..\testapp.config");

var authorizer = new ExactOnlineAuthorizer(testApp.ClientId.ToString(), testApp.ClientSecret, testApp.CallbackUrl,
	ExactOnlineTest.Url, ExactOnlineTest.AccessToken, ExactOnlineTest.RefreshToken, ExactOnlineTest.AccessTokenExpiresAt);

authorizer.TokensChanged += (_, e) =>
	(ExactOnlineTest.RefreshToken, ExactOnlineTest.AccessToken, ExactOnlineTest.AccessTokenExpiresAt) =
	(e.NewRefreshToken, e.NewAccessToken, e.NewExpiresAt);

app.MapGet("/", async (ILogger<Program> logger, CancellationToken ct) =>
{
	if (await authorizer.IsAuthorizationNeededAsync(ct))
	{
		return Results.Redirect(await authorizer.GetLoginLinkUriAsync(ct: ct));
	}

	var client = new ExactOnlineClient(ExactOnlineTest.Url, authorizer.GetAccessTokenAsync, null, ExactOnlineTest.MinutelyRemaining, ExactOnlineTest.MinutelyResetTime, ExactOnlineTest.CustomDescriptionLanguage, logger);
	client.MinutelyChanged += (_, e) => (ExactOnlineTest.MinutelyRemaining, ExactOnlineTest.MinutelyResetTime) = (e.NewRemaining, e.NewResetTime);
	await client.InitializeDivisionAsync(ct);

	// Get the Code and Name of a random account in the administration.
	var fields = new[] { "Code", "Name" };
	var account = (await client.For<Account>().Top(1).Select(fields).GetAsync(ct: ct)).List.First();
	Debug.WriteLine(string.Format("Account {0} - {1}", account.Code.TrimStart(), account.Name));
	Debug.WriteLine(string.Format("X-RateLimit-Limit:  {0} - X-RateLimit-Remaining: {1} - X-RateLimit-Reset: {2}",
		client.EolResponseHeader.RateLimit.Limit, client.EolResponseHeader.RateLimit.Remaining, client.EolResponseHeader.RateLimit.Reset));

	return Results.Ok(account);
});

app.MapGet("/callback", async (string code, string? state, CancellationToken ct) =>
{
	await authorizer.ProcessAuthorizationAsync(code, ct);

	return Results.LocalRedirect(string.IsNullOrWhiteSpace(state) ? "/" : state);
});

app.MapGet("/sync", async (ILogger<Program> logger, CancellationToken ct) =>
{
	if (await authorizer.IsAuthorizationNeededAsync(ct))
	{
		return Results.Redirect(await authorizer.GetLoginLinkUriAsync("/sync", ct: ct));
	}

	var client = new ExactOnlineClient(ExactOnlineTest.Url, authorizer.GetAccessTokenAsync, null, ExactOnlineTest.MinutelyRemaining, ExactOnlineTest.MinutelyResetTime, ExactOnlineTest.CustomDescriptionLanguage, logger);
	client.MinutelyChanged += (_, e) => (ExactOnlineTest.MinutelyRemaining, ExactOnlineTest.MinutelyResetTime) = (e.NewRemaining, e.NewResetTime);
	await client.InitializeDivisionAsync();

	// How to use SynchronizeWith functionality

	// First new up a specific target (a custom target can easily be added by creating 2 classes deriving from
	// SyncTargetBase and SyncTargetControllerBase. See the example EntityFrameworkTarget and its Controller to get started.
	// EntityFrameworkTarget will automatically create a database on localdb.
	// Or you can also supply a connectionstring in the constructor for more control.
	var efTarget = new EntityFrameworkCoreTarget("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=ExactOnlineClientSdkSyncTest;Integrated Security=True;MultipleActiveResultSets=True");

	// Make sure the database is initialized!
	await efTarget.InitializeDatabaseAsync(ct);

	// Synchronize a single full entity
	await client.SynchronizeWithAsync<Account>(efTarget, ModelInfo.For<Account>().FieldNames(true), ct: ct);

	// There's also an override that takes a type in case you want to run the synchronization dynamically (for a given modeltype)
	// E.g. use the following code to synchronize all supported modeltypes
	//foreach (var modelType in EntityFrameworkCoreTarget.SupportedModelTypes)
	//{
	//	// These give an 'unauthorized exception' apparently...
	//	if (modelType == typeof(ExactOnline.Client.Models.Accountancy.AccountInvolvedAccount) ||
	//		modelType == typeof(ExactOnline.Client.Models.Accountancy.AccountOwner) ||
	//		modelType == typeof(ExactOnline.Client.Models.Payroll.EmploymentSalary) ||
	//		modelType == typeof(ExactOnline.Client.Models.Financial.OfficialReturn) ||
	//		modelType == typeof(ExactOnline.Client.Models.Accountancy.SolutionLink) ||
	//		modelType == typeof(ExactOnline.Client.Models.Accountancy.TaskType) ||
	//		modelType == typeof(ExactOnline.Client.Models.HRM.LeaveBuildUpRegistration))
	//		continue;

	//	await client.SynchronizeWithAsync(efTarget, modelType, ModelInfo.For(modelType).FieldNames(true));
	//}

	return Results.Ok();
});

app.Run();
