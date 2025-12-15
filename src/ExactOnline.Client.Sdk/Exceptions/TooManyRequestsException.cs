namespace ExactOnline.Client.Sdk.Exceptions;

[Serializable]
public class TooManyRequestsException : ExactOnlineClientException
{
	public TooManyRequestsException() { }
	public TooManyRequestsException(string message) : base(message) { }
	public TooManyRequestsException(string message, Exception innerException)
		: base(message, innerException) { }
}
