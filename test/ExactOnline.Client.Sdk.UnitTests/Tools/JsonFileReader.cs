using System.Reflection;

namespace ExactOnline.Client.Sdk.UnitTests.Tools;

public class JsonFileReader
{
	public static string GetJsonFromFile(string filename)
	{
		var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
		var filepath = path + Path.DirectorySeparatorChar + "Json" + Path.DirectorySeparatorChar + filename;

		var text = "";
		try
		{
			using StreamReader sr = new(filepath);
			text = sr.ReadToEnd();
		}
		catch (Exception e)
		{
			Console.WriteLine("The file could not be read:");
			Console.WriteLine(e.Message);
		}
		return text;
	}

	public static string GetJsonFromFileWithoutWhiteSpace(string filename)
	{
		var text = GetJsonFromFile(filename);
		text = text.Replace(" ", "");
		text = text.Replace("\n", "");
		text = text.Replace("\r", "");
		return text;
	}
}
