using System;

public sealed class SDKFieldType : Attribute
{
    public FieldType TypeOfField { get; set; }

    public SDKFieldType(FieldType fieldType) => TypeOfField = fieldType;
}
