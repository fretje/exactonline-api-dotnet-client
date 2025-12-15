namespace ExactOnline.Client.Sdk.Exceptions;

[Serializable]
public class NotFoundException : ExactOnlineClientException // HTTP: 404
{
	public NotFoundException() { }
	public NotFoundException(string message) : base(message) { }
	public NotFoundException(string message, Exception inner)
		: base(message, inner) { }
}
