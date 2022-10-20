using System.Runtime.Serialization;

namespace ExactOnline.Client.Sdk.Exceptions;

[Serializable]
public class BadRequestException : ExceptionBase // HTTP: 400
{
	public BadRequestException() { }
	public BadRequestException(string message) : base(message) { }
	public BadRequestException(string message, Exception inner)
		: base(message, inner) { }
	protected BadRequestException(SerializationInfo info, StreamingContext context)
		: base(info, context) { }
}
