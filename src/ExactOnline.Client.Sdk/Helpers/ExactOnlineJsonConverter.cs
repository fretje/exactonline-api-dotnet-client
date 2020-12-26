using ExactOnline.Client.Sdk.Controllers;
using ExactOnline.Client.Sdk.Delegates;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ExactOnline.Client.Sdk.Helpers
{
    public class ExactOnlineJsonConverter : JsonConverter
    {
        private readonly GetEntityController _entityControllerDelegate;
        private readonly bool _createUpdateJson;
        private readonly object _originalEntity;

        public ExactOnlineJsonConverter() =>
            _createUpdateJson = false;

        public ExactOnlineJsonConverter(object originalObject, GetEntityController ecDelegate)
        {
            _entityControllerDelegate = ecDelegate;
            _originalEntity = originalObject;
            _createUpdateJson = true;
        }

        /// <summary>
        /// Create an instance of objectType, based properties in the JSON object
        /// </summary>
        /// <param name="objectType">type of object expected</param>
        /// <param name="jObject">contents of JSON object that will be deserialized</param>
        /// <returns></returns>
        protected static T Create<T>(Type objectType, JObject jObject) =>
            throw new NotImplementedException();

        /// <summary>
        /// Indicates if an entity can be converted to Json
        /// </summary>
        /// <param name="objectType">Type of the entity</param>
        /// <returns>True if the entity can be converted</returns>
        public override bool CanConvert(Type objectType) =>
            objectType.ToString().Contains("ExactOnline.Client.Models");

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) =>
            throw new NotImplementedException();

        /// <summary>
        /// Converts datetime to required format
        /// </summary>
        private static string ConvertDateToEdmDate(DateTime date) =>
            string.Format("{0:yyyy-MM-ddTHH:mm}", date);

        /// <summary>
        /// Returns if a field is writeable (is not a identifier and is not a TypeOfField.ReadOnly field)
        /// </summary>
        /// <param name="pi"></param>
        /// <returns></returns>
        private static bool IsWriteField(PropertyInfo pi) =>
            !pi.GetCustomAttributes().OfType<SDKFieldType>().Any(a => a.TypeOfField == FieldType.ReadOnly);

        /// <summary>
        /// Method for creating Json
        /// Indicates if the field is a field to create json for
        /// </summary>
        private bool IsUpdatedField(object objectToConvert, PropertyInfo pi)
        {
            var returnValue = false;

            var originalvalue = _originalEntity.GetType().GetProperty(pi.Name).GetValue(_originalEntity) ?? "null";
            var currentvalue = pi.GetValue(objectToConvert) ?? "null";

            if (currentvalue is ICollection collection && currentvalue.GetType() != typeof(byte[]))
            {
                foreach (var entity in collection)
                {
                    var entitymanager = GetEntityController(entity);
                    if (entitymanager == null || entitymanager.IsUpdated(entity))
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

        private EntityController GetEntityController(object entity) => _entityControllerDelegate(entity);

        private JsonConverter GetCorrectConverter(object entity)
        {
            ExactOnlineJsonConverter converter;

            if (_createUpdateJson)
            {
                var emanager = GetEntityController(entity);
                if (emanager != null)
                {
                    // Entity is an existing entity. Create JsonConverter for updating an existing entity
                    converter = new ExactOnlineJsonConverter(emanager.OriginalEntity, _entityControllerDelegate);
                }
                else
                {
                    // Entity is a new entity. Create JsonConverter for sending only changed fields
                    var emptyEntity = Activator.CreateInstance(entity.GetType());
                    converter = new ExactOnlineJsonConverter(emptyEntity, _entityControllerDelegate);
                }
            }
            else
            {
                converter = new ExactOnlineJsonConverter();
            }

            return converter;
        }

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

        private PropertyInfo[] GetWriteableFields(object value, bool jsonForUpdate)
        {
            var writeableFields = value.GetType().GetProperties().Where(IsWriteField).ToArray();

            if (jsonForUpdate)
            {
                var updatedfields = GetUpdatedFields(writeableFields, value); // If Json for update: Get only updated fields
                writeableFields = (from f in writeableFields
                                   join up in updatedfields on f.Name equals up.Name
                                   select f).ToArray();
            }

            return writeableFields;
        }

        private IEnumerable<PropertyInfo> GetUpdatedFields(PropertyInfo[] writeableFields, object value)
        {
            // Check if this is an object where only the json for updated fields have to be created
            writeableFields = value.GetType().GetProperties().Where(property => IsUpdatedField(value, property)).ToArray();
            return writeableFields;
        }

        /// <summary>
        /// Converts the object to Json
        /// </summary>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var writeableFields = GetWriteableFields(value, _createUpdateJson);
            var guidsToSkip = writeableFields.Where(x => x.GetValue(value) is Guid guid
                                    && guid == Guid.Empty).ToArray();

            // Remove the fields to skip from the writeable fields
            writeableFields = writeableFields.Except(writeableFields.Join(guidsToSkip, e => e.GetValue(value), m => m.GetValue(value), (e, m) => e)).ToArray();
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

                if (fieldValue != null && fieldValue.GetType().IsGenericType && fieldValue is IEnumerable enumerable)
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

        /// <summary>
        /// Check if datetime. If so, convert to EdmDate
        /// </summary>
        private object CheckDateFormat(object fieldValue)
        {
            if (fieldValue is DateTime dateTime)
            {
                fieldValue = ConvertDateToEdmDate(dateTime);
            }
            return fieldValue;
        }
    }
}
