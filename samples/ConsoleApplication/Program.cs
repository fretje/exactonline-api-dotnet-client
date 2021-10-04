﻿using ExactOnline.Client.Models.CRM;
using ExactOnline.Client.OAuth;
using ExactOnline.Client.Sdk.Controllers;
using ExactOnline.Client.Sdk.Enums;
using ExactOnline.Client.Sdk.Helpers;
using ExactOnline.Client.Sdk.Sync;
using ExactOnline.Client.Sdk.Sync.EntityFramework;
using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;

namespace ConsoleApplication
{
	internal class Program
	{
		private static string _exactOnlineUrl => "https://start.exactonline.be";

		private static readonly string _refreshTokenCacheFile = @"c:\temp\refreshTokenCache";
		private static readonly string _accessTokenCacheFile = @"c:\temp\accessTokenCache";
		private static readonly string _accessTokenExpirationCacheFile = @"c:\temp\accessTokenExpirationUtcCache";

		private static string _refreshToken
		{
			get => File.Exists(_refreshTokenCacheFile) ? File.ReadAllText(_refreshTokenCacheFile) : null;
			set => File.WriteAllText(_refreshTokenCacheFile, value);
		}
		private static string _accessToken
		{
			get => File.Exists(_accessTokenCacheFile) ? File.ReadAllText(_accessTokenCacheFile) : null;
			set => File.WriteAllText(_accessTokenCacheFile, value);
		}
		private static DateTimeOffset? _accessTokenExpiration
		{
			get => File.Exists(_accessTokenExpirationCacheFile) ? DateTime.Parse(File.ReadAllText(_accessTokenExpirationCacheFile), null, DateTimeStyles.RoundtripKind) : (DateTime?)null;
			set
			{
				if (value.HasValue)
				{
					File.WriteAllText(_accessTokenExpirationCacheFile, value.Value.ToString("o"));
				}
				else
				{
					File.Delete(_accessTokenExpirationCacheFile);
				}
			}
		}

		[STAThread]
		private static void Main()
		{
			// To make this work set the authorisation properties of your test app in the testapp.config.
			var testApp = new TestApp();

			var httpClient = new HttpClient();
			var authorizer = new ExactOnlineAuthorizer(httpClient, _exactOnlineUrl, testApp.ClientId.ToString(), testApp.ClientSecret, testApp.CallbackUrl, _refreshToken, _accessToken, _accessTokenExpiration);
			authorizer.AnyTokenUpdated += (sender, e) => (_refreshToken, _accessToken, _accessTokenExpiration) = (e.NewRefreshToken, e.NewAccessToken, e.NewAccessTokenExpiration);
			var client = new ExactOnlineClient(_exactOnlineUrl, 0, authorizer.GetAccessToken, httpClient);

			// Get the Code and Name of a random account in the administration.
			var fields = new[] { "Code", "Name" };
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
			var efTarget = new EntityFrameworkTarget();

			// Synchronize a single full entity
			client.SynchronizeWith<Account>(efTarget, ModelInfo.For<Account>().FieldNames(true));

			// Or create a filter first and then call SynchronizeWith on the ExactOnlineQuery.
			// In this case you have to provide the client as a parameter because SynchronizeWith
			// needs access to the Sync.Deleted entities in case we're dealing with a sync endpoint.
			client.For<Account>()
				.Select("AddressLine1", "AddressLine2", "AddressLine3")
				.Where(a => a.StartDate, new DateTime(2000, 1, 1), OperatorEnum.Gt)
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
		}
	}
}
