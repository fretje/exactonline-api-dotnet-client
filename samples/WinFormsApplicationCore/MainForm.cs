using ExactOnline.Client.OAuth2.WinForms;
using ExactOnline.Client.Sdk.Controllers;
using ExactOnline.Client.Sdk.Test.Infrastructure;

namespace WinFormsApplicationCore;

public partial class MainForm : Form
{
	private readonly ExactOnlineWinFormsAuthorizer _authorizer;
	private readonly ExactOnlineClient _client;

	public MainForm()
	{
		InitializeComponent();

		countItemsButton.Click += (_, _) => CountItemsAsync();

        // To make this work set the authorisation properties of your test app in the testapp.config.
        TestApp testApp = new();

		_authorizer = new(testApp.ClientId, testApp.ClientSecret, testApp.CallbackUrl, testApp.BaseUrl, ExactOnlineTest.AccessToken, ExactOnlineTest.RefreshToken, ExactOnlineTest.AccessTokenExpiresAt);
		_authorizer.TokensChanged += (_, e) => (ExactOnlineTest.RefreshToken, ExactOnlineTest.AccessToken, ExactOnlineTest.AccessTokenExpiresAt) = (e.NewRefreshToken, e.NewAccessToken, e.NewExpiresAt);

		_client = new(testApp.BaseUrl, _authorizer.GetAccessTokenAsync, null, ExactOnlineTest.MinutelyRemaining, ExactOnlineTest.MinutelyResetTime);
		_client.MinutelyChanged += (_, e) => (ExactOnlineTest.MinutelyRemaining, ExactOnlineTest.MinutelyResetTime) = (e.NewRemaining, e.NewResetTime);
	}

	private async void CountItemsAsync()
	{
		var count = await _client
			.For<ExactOnline.Client.Models.Logistics.Item>()
			.CountAsync();

		outputTextBox.AppendText($"Total items: {count}{Environment.NewLine}");
	}

	private async void MainForm_Load(object sender, EventArgs e)
	{
		try
		{
			await _client.InitializeDivisionAsync();

			initializingLabel.Text = $"Exact Online initialized for division {_client.Division}";
		}
		catch (Exception ex)
		{
			outputTextBox.AppendText($"Error initializing Exact Online: {ex.Message}{Environment.NewLine}");
		}
	}
}
