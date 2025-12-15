namespace ExactOnline.Client.Sdk.Exceptions;

[Serializable]
public class InternalServerErrorException : ExactOnlineClientException // HTTP 500
{
	public InternalServerErrorException() { }
	public InternalServerErrorException(string message) : base(message) { }
	public InternalServerErrorException(string message, Exception inner)
		: base(message, inner) { }
}
