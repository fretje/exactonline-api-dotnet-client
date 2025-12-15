namespace ExactOnline.Client.Sdk.Exceptions;

[Serializable]
public class ForbiddenException : ExactOnlineClientException // HTTP: 403
{
	public ForbiddenException() { }
	public ForbiddenException(string message) : base(message) { }
	public ForbiddenException(string message, Exception inner)
		: base(message, inner) { }
}
