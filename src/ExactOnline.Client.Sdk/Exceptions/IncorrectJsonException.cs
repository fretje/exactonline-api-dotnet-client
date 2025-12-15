namespace ExactOnline.Client.Sdk.Exceptions;

[Serializable]
public class IncorrectJsonException : ExactOnlineClientException
{
	public IncorrectJsonException() { }
	public IncorrectJsonException(string message) : base(message) { }
	public IncorrectJsonException(string message, Exception innerException)
		: base(message, innerException) { }
}
