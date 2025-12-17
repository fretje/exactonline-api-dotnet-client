namespace ExactOnline.Client.Sdk.Models;

public class ApiList<T>(List<T> list, string? skipToken)
{
	public List<T> List { get; } = list;
	public string? SkipToken { get; } = skipToken;
}
