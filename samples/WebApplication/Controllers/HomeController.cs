using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;
using ExactOnline.Client.Models.CRM;
using ExactOnline.Client.OAuth2;
using ExactOnline.Client.Sdk.Controllers;
using ExactOnline.Client.Sdk.Test.Infrastructure;

namespace WebApplication.Controllers;

public class HomeController : Controller
{
	private TestApp testApp;

	public HomeController()
	{
		var path = Path.Combine(Server.MapPath("~"), @"..\..\testapp.config");
		testApp = new TestApp(path);
	}

	// The authorizer is stored in the session state, so as long as that lives the user won't have to log in again.
	// For the Authorization to live longer than that, you can store the refresh token in safe storage (using the RefresTokenUpdated event)
	// and as long as you supply that refresh token again in the constructor of the authorizer, the user won't have to log in again.
	private ExactOnlineAuthorizer Authorizer
	{
		get
		{
			if (Session["Authorizer"] is not ExactOnlineAuthorizer authorizer)
			{
				// To make this work set the authorisation properties of your test app in the testapp.config.
				authorizer = new ExactOnlineAuthorizer(testApp.ClientId, testApp.ClientSecret, testApp.CallbackUrl,
					testApp.BaseUrl, ExactOnlineTest.AccessToken, ExactOnlineTest.RefreshToken, ExactOnlineTest.AccessTokenExpiresAt);
				authorizer.TokensChanged += (_, e) =>
					(ExactOnlineTest.RefreshToken, ExactOnlineTest.AccessToken, ExactOnlineTest.AccessTokenExpiresAt) =
					(e.NewRefreshToken, e.NewAccessToken, e.NewExpiresAt);
				Session["Authorizer"] = authorizer;
			}
			return authorizer;
		}
	}

	public async Task<ActionResult> Index(CancellationToken ct)
	{
		if (await Authorizer.IsAuthorizationNeededAsync(ct))
		{
			// When authorization is needed we redirect to the authorizationUrl
			return Redirect(await Authorizer.GetLoginLinkUriAsync());
		}

		// When we get here, that means the authorizer is authorized and we can use its GetAccessTokenAsync method for the exactOnlineclient
		var client = new ExactOnlineClient(testApp.BaseUrl, Authorizer.GetAccessTokenAsync, null, ExactOnlineTest.MinutelyRemaining, ExactOnlineTest.MinutelyResetTime);
		client.MinutelyChanged += (_, e) => (ExactOnlineTest.MinutelyRemaining, ExactOnlineTest.MinutelyResetTime) = (e.NewRemaining, e.NewResetTime);
		await client.InitializeDivisionAsync();

		// Get the Code and Name of a random account in the administration.
		var fields = new[] { "Code", "Name" };
		var account = client.For<Account>().Top(1).Select(fields).Get().FirstOrDefault();
		Debug.WriteLine(string.Format("Account {0} - {1}", account.Code?.TrimStart(), account.Name));
		Debug.WriteLine(string.Format("X-RateLimit-Limit:  {0} - X-RateLimit-Remaining: {1} - X-RateLimit-Reset: {2}",
			client.EolResponseHeader.RateLimit.Limit, client.EolResponseHeader.RateLimit.Remaining, client.EolResponseHeader.RateLimit.Reset));

		return View(account);
	}

	public async Task<ActionResult> Callback(string code, CancellationToken ct)
	{
		// After authorization, Exact Online will call back with the refresh token in the "code" parameter of the url
		// That's where we ask the authorizer to process that code
		await Authorizer.ProcessAuthorizationAsync(code, ct);

		// We redirect back to ourselves Index, which should now continue with using the exact online client
		return RedirectToAction("Index");
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
