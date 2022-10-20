using System.Runtime.Serialization;

namespace ExactOnline.Client.Sdk.Exceptions;

public abstract class ExceptionBase : Exception
{
	protected ExceptionBase() {}

	protected ExceptionBase(string message) : base(message) {}

	protected ExceptionBase(string message, Exception inner) : base(message, inner) {}

	protected ExceptionBase(SerializationInfo info, StreamingContext context)
		: base(info, context) { }
}
