using ExactOnline.Client.Models.CRM;
using ExactOnline.Client.OAuth;
using ExactOnline.Client.Sdk.Controllers;
using ExactOnline.Client.Sdk.Enums;
using ExactOnline.Client.Sdk.Helpers;
using ExactOnline.Client.Sdk.Sync;
using ExactOnline.Client.Sdk.Sync.EntityFramework;
using System;
using System.Diagnostics;
using System.Linq;

namespace ConsoleApplication
{
	internal class Program
	{
		public static string ExactOnlineUrl => "https://start.exactonline.be";

		[STAThread]
		private static void Main()
		{
			// To make this work set the authorisation properties of your test app in the testapp.config.
			var testApp = new TestApp();

			var authorizer = new ExactOnlineAuthorizer(ExactOnlineUrl, testApp.ClientId.ToString(), testApp.ClientSecret, testApp.CallbackUrl);
			var client = new ExactOnlineClient(ExactOnlineUrl, authorizer.GetAccessToken);

			// Get the Code and Name of a random account in the administration.
			var fields = new[] { "Code", "Name" };
			var account = client.For<Account>().Top(1).Select(fields).Get().FirstOrDefault();
			WriteRateLimitInfo(client);

			// This is an example of how to use skipToken for paging.
			var skipToken = string.Empty;
			var accounts = client.For<Account>().Select(fields).Get(ref skipToken);
			WriteRateLimitInfo(client);

			// Now I can use the skip token to get the first record from the next page.
			var nextAccount = client.For<Account>().Top(1).Select(fields).Get(ref skipToken).FirstOrDefault();
			WriteRateLimitInfo(client);


			// How to use SynchronizeWith functionality

			// First new up a specific target (a custom target can easily be added by creating 2 classes deriving from
			// SyncTargetBase and SyncTargetControllerBase. See the example EntityFrameworkTarget and its Controller to get started.
			// EntityFrameworkTarget will automatically create a database on localdb.
			// Or you can also supply a connectionstring in the constructor for more control.
			var efTarget = new EntityFrameworkTarget();

			// Synchronize a single full entity
			client.SynchronizeWith<Account>(efTarget, ModelInfo.For<Account>().FieldNames(true));
			WriteRateLimitInfo(client);

			// Or create a filter first and then call SynchronizeWith on the ExactOnlineQuery.
			// In this case you have to provide the client as a parameter because SynchronizeWith
			// needs access to the Sync.Deleted entities in case we're dealing with a sync endpoint.
			client.For<Account>()
				.Select("AddressLine1", "AddressLine2", "AddressLine3")
				.Where(a => a.StartDate, new DateTime(2000, 1, 1), OperatorEnum.Gt)
				.SynchronizeWith(efTarget, client);
			WriteRateLimitInfo(client);

			// There's also an override that takes a type in case you want to run the synchronization dynamically (for a given modeltype)
			// E.g. use the following code to synchronize all supported modeltypes
			//foreach (var modelType in EntityFrameworkTarget.SupportedModelTypes)
			//{
			//	client.SynchronizeWith(efTarget, modelType, ModelInfo.For(modelType).FieldNames(true));
			//	WriteRateLimitInfo(client);
			//}
		}

		private static void WriteRateLimitInfo(ExactOnlineClient client) =>
			Debug.WriteLine(string.Format("X-RateLimit-Limit: {0} - X-RateLimit-Remaining: {1} - X-RateLimit-Reset: {2} - X-RateLimit-Minutely-Limit: {3} - X-RateLimit-Minutely-Remaining: {4} - X-RateLimit-Minutely-Reset: {5}",
				client.EolResponseHeader.RateLimit.Limit, client.EolResponseHeader.RateLimit.Remaining, client.EolResponseHeader.RateLimit.Reset, client.EolResponseHeader.RateLimit.MinutelyLimit, client.EolResponseHeader.RateLimit.MinutelyRemaining, client.EolResponseHeader.RateLimit.MinutelyReset));
	}
}
