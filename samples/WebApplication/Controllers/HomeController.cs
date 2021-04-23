using ExactOnline.Client.Models.CRM;
using ExactOnline.Client.OAuth;
using ExactOnline.Client.Sdk.Controllers;
using ExactOnline.Client.Sdk.Helpers;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
	public class HomeController : Controller
	{
		public static string ExactOnlineUrl => "https://start.exactonline.be";

		// The authorizer is stored in the session state, so as long as that lives the user won't have to log in again.
		// For the Authorization to live longer than that, you can store the refresh token in safe storage (using the RefresTokenUpdated event)
		// and as long as you supply that refresh token again in the constructor of the authorizer, the user won't have to log in again.
		private ExactOnlineAuthorizer Authorizer
		{
			get
			{
				if (!(Session["Authorizer"] is ExactOnlineAuthorizer authorizer))
				{
					// To make this work set the authorisation properties of your test app in the testapp.config.
					var path = Path.Combine(Server.MapPath("~"), @"..\..\testapp.config");
					var testApp = new TestApp(path);
					authorizer = new ExactOnlineAuthorizer(ExactOnlineUrl, testApp.ClientId.ToString(), testApp.ClientSecret, testApp.CallbackUrl);
					Session["Authorizer"] = authorizer;
				}
				return authorizer;
			}
		}

		public async Task<ActionResult> Index()
		{
			if (!string.IsNullOrEmpty(Request.QueryString["code"]))
			{
				// After authorization, Exact Online will call back with the refresh token in the "code" parameter of the url
				// That's where we ask the authorizer to process that refresh token
				Authorizer.ProcessAuthorization(Request.Url);
				// We redirect back to ourselves to remove the refresh token from the url
				return RedirectToAction("Index");
			}

			Uri authorizationUrl = await Authorizer.GetUriIfAuthorizationNeeded();
			if (authorizationUrl != null)
			{
				// When authorization is needed we simply redirect to the authorizationUrl
				return Redirect(authorizationUrl.ToString());
			}

			// When we get here, authorization won't be needed, so the winform should never pop up
			var client = new ExactOnlineClient(ExactOnlineUrl, Authorizer.GetAccessToken);

			// Get the Code and Name of a random account in the administration.
			var fields = new[] { "Code", "Name" };
			var account = client.For<Account>().Top(1).Select(fields).Get().FirstOrDefault();
			Debug.WriteLine(string.Format("Account {0} - {1}", account.Code.TrimStart(), account.Name));
			Debug.WriteLine(string.Format("X-RateLimit-Limit:  {0} - X-RateLimit-Remaining: {1} - X-RateLimit-Reset: {2}",
				client.EolResponseHeader.RateLimit.Limit, client.EolResponseHeader.RateLimit.Remaining, client.EolResponseHeader.RateLimit.Reset));

			return View(account);
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}
