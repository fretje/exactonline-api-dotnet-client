using System.Runtime.Serialization;

namespace ExactOnline.Client.Sdk.Exceptions;

[Serializable]
public class TooManyRequestsException : ExactOnlineClientException
{
	private DateTime? _rateLimitResetTime;

	public DateTime? RateLimitRestTime => _rateLimitResetTime;

	public TooManyRequestsException(DateTime? rateLimitResetTime = null)
	{
		_rateLimitResetTime = rateLimitResetTime;
	}

	public TooManyRequestsException(string message, DateTime? rateLimitResetTime = null) : base(message)
	{
		_rateLimitResetTime = rateLimitResetTime;
	}

	public TooManyRequestsException(string message, Exception innerException, DateTime? rateLimitResetTime = null)
		: base(message, innerException)
	{
		_rateLimitResetTime = rateLimitResetTime;
	}

	protected TooManyRequestsException(SerializationInfo info, StreamingContext context,
		DateTime? rateLimitResetTime = null)
		: base(info, context)
	{
		_rateLimitResetTime = rateLimitResetTime;
	}
}
