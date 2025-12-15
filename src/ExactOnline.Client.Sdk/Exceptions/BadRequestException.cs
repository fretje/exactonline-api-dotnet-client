namespace ExactOnline.Client.Sdk.Exceptions;

[Serializable]
public class BadRequestException : ExactOnlineClientException // HTTP: 400
{
	public BadRequestException() { }
	public BadRequestException(string message) : base(message) { }
	public BadRequestException(string message, Exception inner)
		: base(message, inner) { }
}
