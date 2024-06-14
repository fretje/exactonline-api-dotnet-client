using System.Collections;
using ExactOnline.Client.Sdk.Helpers;
using ExactOnline.Client.Sdk.Interfaces;

namespace ExactOnline.Client.Sdk.Controllers;

/// <summary>
/// Controls the state of an entity to create the functionality for only sending altered fields to the API
/// </summary>
/// <remarks>
/// Creates an instance of EntityController
/// </remarks>
/// <param name="entity">An instance of an Entity that must be managed</param>
/// <param name="keyName">Name of the keyname field of the entity (mostly ID)</param>
/// <param name="identifier">Name of the identifier field of the entity (mostly ID)</param>
/// <param name="connection">Instance of IApiConnection to connect to the specific part of the API</param>
/// <param name="getEntityControllerFunc">Delegate that gets the entity controller</param>
public class EntityController(object entity, string keyName, string identifier, IApiConnection connection, Func<object, EntityController> getEntityControllerFunc)
{
	private readonly string _keyName = keyName; // Name of the field that identifies the entity
	private readonly string _identifier = identifier; // Value of the field that identifies the entity 
	private readonly IApiConnection _connection = connection;
	private readonly Func<object, EntityController> _getEntityControllerFunc = getEntityControllerFunc;

	public object OriginalEntity { get; private set; } = Clone(entity);

	/// <summary>
	/// Indicates if an entity is updated 
	/// Warning: Skips linked entities
	/// </summary>
	/// <returns></returns>
	public bool IsUpdated(object entity)
	{
		var isUpdated = false;
		foreach (var pi in entity.GetType().GetProperties())
		{
			var originalvalue = OriginalEntity.GetType().GetProperty(pi.Name).GetValue(OriginalEntity) ?? "null";
			var currentvalue = pi.GetValue(entity) ?? "null";

			if (!originalvalue.Equals(currentvalue))
			{
				isUpdated = true;
			}
		}
		return isUpdated;
	}

	private static object Clone(object entity)
	{
		var clonedEntity = Activator.CreateInstance(entity.GetType(), null);
		var writableProperties = entity.GetType().GetProperties().Where(p => p.CanWrite);
		foreach (var property in writableProperties)
		{
			var value = property.GetValue(entity);
			if (value != null && value.GetType().IsGenericType && value is IEnumerable enumerable)
			{
				// Create linked entity
				var newValue = (IList)Activator.CreateInstance(value.GetType());

				foreach (var item in enumerable)
				{
					newValue.Add(Clone(item));
				}
				value = newValue;
			}
			clonedEntity.GetType().GetProperty(property.Name).SetValue(clonedEntity, value);
		}
		return clonedEntity;
	}

	/// <summary>
	/// Updates the entity
	/// </summary>
	/// <returns>True if the entity is updated</returns>
	public bool Update(object entity)
	{
		// Convert object to json
		var json = EntityConverter.ConvertObjectToJson(OriginalEntity, entity, _getEntityControllerFunc);

		if (string.IsNullOrEmpty(json))
		{
			//Nothing to update
			return true;
		}

		// Update entire object
		var returnValue = false;

		// Update and set _originalentity to current entity (_entity)
		if (_connection.Put(_keyName, _identifier, json))
		{
			returnValue = true;
			OriginalEntity = Clone(entity);
		}
		return returnValue;
	}

	/// <summary>
	/// Updates the entity
	/// </summary>
	/// <returns>True if the entity is updated</returns>
	public async Task<bool> UpdateAsync(object entity, CancellationToken ct = default)
	{
		// Convert object to json
		var json = EntityConverter.ConvertObjectToJson(OriginalEntity, entity, _getEntityControllerFunc);

		if (string.IsNullOrEmpty(json))
		{
			//Nothing to update
			return true;
		}

		// Update entire object
		var returnValue = false;

		// Update and set _originalentity to current entity (_entity)
		if (await _connection.PutAsync(_keyName, _identifier, json, ct).ConfigureAwait(false))
		{
			returnValue = true;
			OriginalEntity = Clone(entity);
		}
		return returnValue;
	}

	/// <summary>
	/// Deletes the entity
	/// </summary>
	/// <returns>True if the entity is deleted</returns>
	public bool Delete() => _connection.Delete(_keyName, _identifier);

	/// <summary>
	/// Deletes the entity
	/// </summary>
	/// <returns>True if the entity is deleted</returns>
	public Task<bool> DeleteAsync(CancellationToken ct = default) => _connection.DeleteAsync(_keyName, _identifier, ct);
}
