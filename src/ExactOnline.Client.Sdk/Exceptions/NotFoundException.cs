using System.Runtime.Serialization;

namespace ExactOnline.Client.Sdk.Exceptions;

[Serializable]
public class NotFoundException : ExceptionBase // HTTP: 404
{
	public NotFoundException() { }
	public NotFoundException(string message) : base(message) { }
	public NotFoundException(string message, Exception inner)
		: base(message, inner) { }
	protected NotFoundException(SerializationInfo info, StreamingContext context)
		: base(info, context) { }
}
