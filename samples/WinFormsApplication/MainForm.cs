using System;
using System.Linq;
using System.Windows.Forms;
using ExactOnline.Client.Models.CRM;
using ExactOnline.Client.OAuth2.WinForms;
using ExactOnline.Client.Sdk.Controllers;
using ExactOnline.Client.Sdk.Test.Infrastructure;

namespace WinFormsApplication;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
    }

    private async void MainForm_Load(object sender, EventArgs e)
    {
		// To make this work set the authorisation properties of your test app in the testapp.config.
		var testApp = new TestApp(@"..\..\..\..\testapp.config");

		var authorizer = new ExactOnlineWinFormsAuthorizer(testApp.ClientId, testApp.ClientSecret, testApp.CallbackUrl, testApp.BaseUrl, ExactOnlineTest.AccessToken, ExactOnlineTest.RefreshToken, ExactOnlineTest.AccessTokenExpiresAt);
		authorizer.TokensChanged += (_, e) => (ExactOnlineTest.RefreshToken, ExactOnlineTest.AccessToken, ExactOnlineTest.AccessTokenExpiresAt) = (e.NewRefreshToken, e.NewAccessToken, e.NewExpiresAt);

		try
		{
			var client = new ExactOnlineClient(testApp.BaseUrl, authorizer.GetAccessTokenAsync, null, ExactOnlineTest.MinutelyRemaining, ExactOnlineTest.MinutelyResetTime);
			client.MinutelyChanged += (_, e) => (ExactOnlineTest.MinutelyRemaining, ExactOnlineTest.MinutelyResetTime) = (e.NewRemaining, e.NewResetTime);
			await client.InitializeDivisionAsync();

			// Get the Code and Name of a random account in the administration.
			var fields = new[] { "Code", "Name" };
			var account = (await client.For<Account>().Top(1).Select(fields).GetAsync()).List.FirstOrDefault();
			MessageBox.Show(account.Name);
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.ToString(), ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
	}
}
