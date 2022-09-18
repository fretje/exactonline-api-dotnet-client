namespace ExactOnline.Client.Sdk.Models;

public class ApiList<T>
{
	public ApiList(List<T> list, string skipToken) =>
		(List, SkipToken) = (list, skipToken);

	public List<T> List { get; }
	public string SkipToken { get; }
}
