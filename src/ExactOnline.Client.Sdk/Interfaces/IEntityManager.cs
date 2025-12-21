using ExactOnline.Client.Sdk.Controllers;

namespace ExactOnline.Client.Sdk.Interfaces;

/// <summary>
/// Interface for classes that manage a collection of (linked) entities
/// This interface is used by the ControllerList class for 'GetEntityManager' method for fetching
/// the associated controller for a specific entity
/// </summary>
public interface IEntityManager
{
	bool IsManagedEntity(object entity);

	bool AddEntityToManagedEntitiesCollection(object entity);

	EntityController? GetEntityController(string guid);

	string? GetIdentifierValue(object entity);
}
