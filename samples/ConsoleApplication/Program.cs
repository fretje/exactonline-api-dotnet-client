using ExactOnline.Client.Models.CRM;
using ExactOnline.Client.OAuth2.WinForms;
using ExactOnline.Client.Sdk.Controllers;
using ExactOnline.Client.Sdk.Enums;
using ExactOnline.Client.Sdk.Sync;
using ExactOnline.Client.Sdk.Sync.EntityFramework;
using ExactOnline.Client.Sdk.Test.Infrastructure;
using Serilog;
using Serilog.Extensions.Logging;

namespace ConsoleApplication;

internal class Program
{
	[STAThread]
	private static async Task Main()
	{
		// We need a WinFormsApartment (message loop) to be able to use the WinFormsAuthorizer
		using WinFormsApartment apartment = new(() => new() { Width = 0, Height = 0 });

		await apartment.Run(async () =>
		{
			// To make this work set the authorisation properties of your test app in the testapp.config.
			TestApp testApp = new();

			ExactOnlineWinFormsAuthorizer authorizer = new(testApp.ClientId, testApp.ClientSecret, testApp.CallbackUrl, ExactOnlineTest.Url, ExactOnlineTest.AccessToken, ExactOnlineTest.RefreshToken, ExactOnlineTest.AccessTokenExpiresAt);
			authorizer.TokensChanged += (_, e) => (ExactOnlineTest.RefreshToken, ExactOnlineTest.AccessToken, ExactOnlineTest.AccessTokenExpiresAt) = (e.NewRefreshToken, e.NewAccessToken, e.NewExpiresAt);

			var seriLogger = new LoggerConfiguration()
				.MinimumLevel.Debug()
				.WriteTo.Debug()
				.WriteTo.Console()
				.CreateLogger();
			var logger = new SerilogLoggerFactory(seriLogger).CreateLogger("ExactOnline Sdk");

			ExactOnlineClient client = new(ExactOnlineTest.Url, authorizer.GetAccessTokenAsync, null, ExactOnlineTest.MinutelyRemaining, ExactOnlineTest.MinutelyResetTime, ExactOnlineTest.CustomDescriptionLanguage, logger);
			client.MinutelyChanged += (_, e) => (ExactOnlineTest.MinutelyRemaining, ExactOnlineTest.MinutelyResetTime) = (e.NewRemaining, e.NewResetTime);
			await client.InitializeDivisionAsync();

			// Get the Code and Name of a random account in the administration.
			string[] fields = ["Code", "Name"];
			var account = client.For<Account>().Top(1).Select(fields).Get().FirstOrDefault();

			// This is an example of how to use skipToken for paging.
			var skipToken = string.Empty;
			var accounts = client.For<Account>().Select(fields).Get(ref skipToken);

			// Now I can use the skip token to get the first record from the next page.
			var nextAccount = client.For<Account>().Top(1).Select(fields).Get(ref skipToken).FirstOrDefault();


			// How to use SynchronizeWith functionality

			// First new up a specific target (a custom target can easily be added by creating 2 classes deriving from
			// SyncTargetBase and SyncTargetControllerBase. See the example EntityFrameworkTarget and its Controller to get started.
			// EntityFrameworkTarget will automatically create a database on localdb.
			// Or you can also supply a connectionstring in the constructor for more control.
			EntityFrameworkTarget efTarget = new();

			// Synchronize a single full entity
			client.SynchronizeWith<Account>(efTarget, ModelInfo.For<Account>().FieldNames(true));

			// Or create a filter first and then call SynchronizeWith on the ExactOnlineQuery.
			// In this case you have to provide the client as a parameter because SynchronizeWith
			// needs access to the Sync.Deleted entities in case we're dealing with a sync endpoint.
			client.For<Account>()
				.Select("AddressLine1", "AddressLine2", "AddressLine3")
				.Where(a => a.StartDate, new(2000, 1, 1), OperatorEnum.Gt)
				.SynchronizeWith(efTarget, client);

			// There's also an override that takes a type in case you want to run the synchronization dynamically (for a given modeltype)
			// E.g. use the following code to synchronize all supported modeltypes
			//foreach (var modelType in EntityFrameworkTarget.SupportedModelTypes)
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
		});
	}
}
