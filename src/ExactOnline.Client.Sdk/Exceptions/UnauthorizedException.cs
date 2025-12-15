namespace ExactOnline.Client.Sdk.Exceptions;

[Serializable]
public class UnauthorizedException : ExactOnlineClientException // HTTP: 401
{
	public UnauthorizedException() { }
	public UnauthorizedException(string message) : base(message) { }
	public UnauthorizedException(string message, Exception inner)
		: base(message, inner) { }
}
