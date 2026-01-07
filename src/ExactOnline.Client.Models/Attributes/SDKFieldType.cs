namespace ExactOnline.Client.Models;

public sealed class SDKFieldType(FieldType fieldType) : Attribute
{
	public FieldType TypeOfField { get; } = fieldType;
}
