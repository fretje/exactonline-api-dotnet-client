using System.Collections;
using System.Diagnostics;
using System.Reflection;
using ExactOnline.Client.Models;
using ExactOnline.Client.Sdk.Controllers;
using Newtonsoft.Json;

namespace ExactOnline.Client.Sdk.Helpers;

public class ExactOnlineJsonConverter : JsonConverter
{
	private readonly Func<object, EntityController?>? _getEntityControllerFunc;
	private readonly bool _createUpdateJson;
	private readonly object? _originalEntity;

	public ExactOnlineJsonConverter() =>
		_createUpdateJson = false;

	public ExactOnlineJsonConverter(object originalObject, Func<object, EntityController?>? getEntityControllerFunc)
	{
		_getEntityControllerFunc = getEntityControllerFunc;
		_originalEntity = originalObject;
		_createUpdateJson = true;
	}

	/// <summary>
	/// Indicates if an entity can be converted to Json
	/// </summary>
	/// <param name="objectType">Type of the entity</param>
	/// <returns>True if the entity can be converted</returns>
	public override bool CanConvert(Type objectType) =>
		objectType.ToString().Contains("ExactOnline.Client.Models");

	public override object ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer) =>
		throw new NotImplementedException();

	/// <summary>
	/// Converts the object to Json
	/// </summary>
	public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
	{
		if (value is null)
		{
			return;
		}

		var writeableFields = GetWriteableFields(value);
		PropertyInfo[] guidsToSkip = [.. writeableFields.Where(x => x.GetValue(value) is Guid guid && guid == Guid.Empty)];

		// Remove the fields to skip from the writeable fields
		writeableFields = [.. writeableFields.Except(writeableFields.Join(guidsToSkip, e => e.GetValue(value), m => m.GetValue(value), (e, m) => e))];
		if (writeableFields.Length < 1)
		{
			return;
		}

		// Create Json 
		writer.WriteStartObject();
		foreach (var field in writeableFields)
		{
			var jsonPropertyAttribute = field.GetCustomAttribute<JsonPropertyAttribute>();
			var fieldName = jsonPropertyAttribute?.PropertyName ?? field.Name;

			var fieldValue = field.GetValue(value);
			fieldValue = CheckDateFormat(fieldValue);

			if (fieldValue is IEnumerable enumerable && fieldValue.GetType().IsGenericType)
			{
				// Write property value for linked entities
				WriteLinkedEntities(writer, fieldName, enumerable);
			}
			else
			{
				// Write property value for normal key value pair
				writer.WritePropertyName(fieldName);
				writer.WriteValue(fieldValue);
			}
		}
		writer.WriteEnd();
	}

	private PropertyInfo[] GetWriteableFields(object value)
	{
		var writeableFields = value.GetType().GetProperties().Where(IsWriteField).ToArray();

		if (_createUpdateJson)
		{
			var updatedfields = GetUpdatedFields(writeableFields, value); // If Json for update: Get only updated fields
			writeableFields = [.. from f in writeableFields
								  join up in updatedfields on f.Name equals up.Name
								  select f];
		}

		return writeableFields;
	}

	/// <summary>
	/// Returns if a field is writeable (is not a identifier and is not a TypeOfField.ReadOnly field)
	/// </summary>
	/// <param name="pi"></param>
	/// <returns></returns>
	private static bool IsWriteField(PropertyInfo pi) =>
		!pi.GetCustomAttributes().OfType<SDKFieldType>().Any(a => a.TypeOfField == FieldType.ReadOnly);

	private PropertyInfo[] GetUpdatedFields(PropertyInfo[] writeableFields, object value)
	{
		// Check if this is an object where only the json for updated fields have to be created
		writeableFields = [.. value.GetType().GetProperties().Where(property => IsUpdatedField(value, property))];
		return writeableFields;
	}

	/// <summary>
	/// Method for creating Json
	/// Indicates if the field is a field to create json for
	/// </summary>
	private bool IsUpdatedField(object objectToConvert, PropertyInfo pi)
	{
		Debug.Assert(_originalEntity is not null, "_originalEntity should never be null here");

		var returnValue = false;

		var originalvalue = _originalEntity!.GetType().GetProperty(pi.Name).GetValue(_originalEntity) ?? "null";
		var currentvalue = pi.GetValue(objectToConvert) ?? "null";

		if (currentvalue is ICollection collection && currentvalue.GetType() != typeof(byte[]) && _getEntityControllerFunc is not null)
		{
			foreach (var entity in collection)
			{
				var entityController = _getEntityControllerFunc(entity);
				if (entityController is null || entityController.IsUpdated(entity))
				{
					returnValue = true;
				}
			}
		}
		else
		{
			returnValue = !originalvalue.Equals(currentvalue);
		}

		return returnValue;
	}

	/// <summary>
	/// Check if datetime. If so, convert to EdmDate
	/// </summary>
	private static object CheckDateFormat(object fieldValue)
	{
		if (fieldValue is DateTime dateTime)
		{
			fieldValue = ConvertDateToEdmDate(dateTime);
		}
		return fieldValue;
	}

	/// <summary>
	/// Converts datetime to required format
	/// </summary>
	private static string ConvertDateToEdmDate(DateTime date) =>
		string.Format("{0:yyyy-MM-ddTHH:mm}", date);

	private void WriteLinkedEntities(JsonWriter writer, string fieldname, IEnumerable fieldValue)
	{
		var linkedEntities = fieldValue.Cast<object>().ToArray();
		if (linkedEntities.Length < 0)
		{
			return;
		}

		writer.WritePropertyName(fieldname);
		writer.WriteStartArray();
		foreach (var item in fieldValue)
		{
			writer.WriteRawValue(JsonConvert.SerializeObject(item, GetCorrectConverter(item)));
		}
		writer.WriteEndArray();
	}

	private ExactOnlineJsonConverter GetCorrectConverter(object entity)
	{
		ExactOnlineJsonConverter converter;

		if (_createUpdateJson)
		{
			if (_getEntityControllerFunc!(entity) is { } entityController)
			{
				// Entity is an existing entity. Create JsonConverter for updating an existing entity
				converter = new(entityController.OriginalEntity, _getEntityControllerFunc);
			}
			else
			{
				// Entity is a new entity. Create JsonConverter for sending only changed fields
				var emptyEntity = Activator.CreateInstance(entity.GetType());
				converter = new(emptyEntity, _getEntityControllerFunc);
			}
		}
		else
		{
			converter = new();
		}

		return converter;
	}
}
