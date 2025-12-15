namespace ExactOnline.Client.Sdk.Exceptions;

public abstract class ExactOnlineClientException : Exception
{
	protected ExactOnlineClientException() {}
	protected ExactOnlineClientException(string message) : base(message) {}
	protected ExactOnlineClientException(string message, Exception inner) : base(message, inner) {}
}
