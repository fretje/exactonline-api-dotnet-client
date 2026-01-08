namespace ExactOnline.Client.Sdk.Test.Infrastructure;

/// <summary>
/// This class is a container for the authorisation details of your test app. These details can be found in the app center 
/// in the maintenance page of your app.
/// </summary>
public class TestApp
{
	public string BaseUrl { get; set; }
	public string ClientId { get; set; }
	public string ClientSecret { get; set; }
	public Uri CallbackUrl { get; set; }
	public string CustomDescriptionLanguage { get; set; }

	/// <summary>
	/// The application details are read from file testapp.config.
	/// testapp.config should consist of 3 lines containing client id, secret and callback url
	/// Or additionally 2 lines containing base url and custom description language.
	/// Example:
	/// 00000000-0000-0000-0000-000000000000
	/// secret
	/// http://foo.bar
	/// https://start.exactonline.be
	/// nl-BE
	/// </summary>
	public TestApp(string path = @"..\..\..\..\..\testapp.config")
	{
		if (!File.Exists(path))
		{
			throw new FileNotFoundException("Please create the testapp.config file in the root of the project. See testapp.config.example for an example.");
		}

		string[] details = File.ReadAllLines(path);
		ClientId = GetSetting(details, 0, "00000000-0000-0000-0000-000000000000");
		ClientSecret = GetSetting(details, 1, "secret");
		CallbackUrl = new(GetSetting(details, 2, "http://foo.bar"));
		BaseUrl = GetSetting(details, 3, "https://start.exactonline.be");
		CustomDescriptionLanguage = GetSetting(details, 4, "nl-BE");
	}

	private static string GetSetting(string[] details, int index, string defaultValue) =>
		index < details.Length ? details[index] : defaultValue;
}
