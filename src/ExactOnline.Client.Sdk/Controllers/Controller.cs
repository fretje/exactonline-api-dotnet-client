using ExactOnline.Client.Models;
using ExactOnline.Client.Sdk.Enums;
using ExactOnline.Client.Sdk.Helpers;
using ExactOnline.Client.Sdk.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExactOnline.Client.Sdk.Controllers
{

	/// <summary>
	/// Class for managing entity Objects (Read, Get, Update & Delete)
	/// </summary>
	public class Controller<T> : IController<T>, IEntityManager where T : class
    {
        private readonly Hashtable _entityControllers = new Hashtable();
        private readonly IApiConnection _conn;
		private readonly Func<Type, IEntityManager> _getEntityManager;
		private readonly string _keyname;
        private string _expandfield;

        /// <summary>
        /// Create new instance of the controller
        /// </summary>
        public Controller(IApiConnection conn, Func<Type, IEntityManager> getEntityManager = null)
        {
            _conn = conn ?? throw new ArgumentException("Instance of type APIConnection cannot be null");
			_getEntityManager = getEntityManager;

			// Set keyname of the entity (name of the field that is used to identify)
			var attributes = Attribute.GetCustomAttributes(typeof(T)).Where(x => x.GetType() == typeof(DataServiceKey)).Select(a => a); //DataServiceKey

            // Find unique value of entity
            var enumerable = attributes as IList<Attribute> ?? attributes.ToList();
            if (!enumerable.Any())
            {
                throw new Exception("Cannot find 'DataServiceKey' field. This entity cannot be managed by the Controller");
            }
            var key = (DataServiceKey)enumerable.First();
            _keyname = key.DataServiceKeyName;
        }

		/// <summary>
		/// Returns if the specified entity is managed by the controller
		/// </summary>
		public bool IsManagedEntity(object entity)
		{
			var identifierValue = GetIdentifierValue(entity);
			return identifierValue != null && _entityControllers.Contains(identifierValue);
		}

		/// <summary>
		/// Returns the number of entities of the current type
		/// </summary>
		public int Count(string query) => _conn.Count(query);

        /// <summary>
        /// Returns the number of entities of the current type
        /// </summary>
        public Task<int> CountAsync(string query) => _conn.CountAsync(query);

        /// <summary>
        /// Gets specific collection of entities.
        /// Please notice that this method will return at max 60 entities (or 1000 when working with bulk or sync endpoints). 
        /// </summary>
        /// <param name="query">oData query</param>
        /// <returns>List of entity Objects</returns>
        public List<T> Get(string query) => Get(query, EndpointTypeEnum.Single);

        /// <summary>
        /// Gets specific collection of entities.
        /// This method will return at max 60 entities. When using the bulk
        /// endpoint, this method will return the maximum page size of
        /// the endpoint.
        /// </summary>
        /// <param name="query">oData query</param>
        /// <param name="endpointType">Which endpoint type to use.</param>
        /// <returns>List of entity Objects</returns>
        public List<T> Get(string query, EndpointTypeEnum endpointType)
        {
            var skipToken = string.Empty;
            return Get(query, ref skipToken, endpointType);
        }

        /// <summary>
        /// Gets specific collection of entities and return a skipToken if there are more than
        /// 60 entities to be returned.
        /// </summary>
        /// <param name="query">oData query</param>
        /// <param name="skipToken">The skip token to be used to get the next page of data.</param>
        /// <returns>List of entity Objects</returns>
        public List<T> Get(string query, ref string skipToken) => Get(query, ref skipToken, EndpointTypeEnum.Single);

        /// <summary>
        /// Gets specific collection of entities and return a skipToken if there are more records
        /// than the maximum page size of the endpoint.
        /// </summary>
        /// <param name="query">oData query</param>
        /// <param name="skipToken">The skip token to be used to get the next page of data.</param>
        /// <param name="endpointType">Which endpoint type to use.</param>
        /// <returns>List of entity Objects</returns>
        public List<T> Get(string query, ref string skipToken, EndpointTypeEnum endpointType)
		{
			CheckValidEndpointType(endpointType);

			// Get the response and convert it to a list of entities of the specific type
			var response = _conn.Get(query, endpointType);

			return ParseGetResponse(response, out skipToken);
		}

		/// <summary>
		/// Gets specific collection of entities and return a skipToken if there are more than
		/// 60 entities to be returned.
		/// </summary>
		/// <param name="query">oData query</param>
		/// <returns>List of entity Objects</returns>
		public Task<Models.ApiList<T>> GetAsync(string query) => GetAsync(query, EndpointTypeEnum.Single);

        /// <summary>
        /// Gets specific collection of entities and return a skipToken if there are more records
        /// than the maximum page size of the endpoint.
        /// </summary>
        /// <param name="query">oData query</param>
        /// <param name="skipToken">The skip token to be used to get the next page of data.</param>
        /// <param name="endpointType">Which endpoint type to use.</param>
        public async Task<Models.ApiList<T>> GetAsync(string query, EndpointTypeEnum endpointType)
        {
            CheckValidEndpointType(endpointType);

            // Get the response and convert it to a list of entities of the specific type
            var response = await _conn.GetAsync(query, endpointType).ConfigureAwait(false);

			var entities = ParseGetResponse(response, out var skipToken);

            return new Models.ApiList<T>(entities, skipToken);
        }

        private static void CheckValidEndpointType(EndpointTypeEnum endpointType)
        {
            if (endpointType == EndpointTypeEnum.Bulk && !SupportedActionsSDK.GetByType(typeof(T)).CanBulkRead)
            {
                throw new Exception("Cannot read from bulk endpoint. There is no bulk endpoint for this entity. Please see the Reference Documentation.");
            }
            if (endpointType == EndpointTypeEnum.Sync && !typeof(T).IsSubclassOf(typeof(SupportsSync)))
            {
                throw new Exception("Cannot read from sync endpoint. There is no sync endpoint for this entity. Please see the Reference Documentation.");
            }
        }

		private List<T> ParseGetResponse(string response, out string skipToken)
		{
			skipToken = ApiResponseCleaner.GetSkipToken(response);
			response = ApiResponseCleaner.GetJsonArray(response);

			var entities = EntityConverter.ConvertJsonArrayToObjectList<T>(response);

			// If the entity aren't managed already, register to managed entity collection
			AddEntitiesToManagedEntitiesCollection(entities);

			// Convert list
			return entities.ConvertAll(x => x);
		}

		/// <summary>
		/// Get entity using specific GUID
		/// </summary>
		/// <param name="guid">Global Unique Identifier of the entity</param>
		/// <param name="parameters">parameters</param>
		/// <returns>Entity if exists. Null if entity not exists.</returns>
		public T GetEntity(string guid, string parameters)
        {
            if (guid.Contains('}') || guid.Contains('{'))
            {
                throw new Exception("Bad Guid: Guid cannot contain '}' or '{'");
            }

            // Convert the resonse to an object of the specific type
            var response = _conn.GetEntity(_keyname, guid, parameters);
            response = ApiResponseCleaner.GetJsonObject(response);
            var entity = EntityConverter.ConvertJsonToObject<T>(response);

            // If entity isn't managed already, add entity to EntityController
            AddEntityToManagedEntitiesCollection(entity);
            return entity;
        }

        /// <summary>
        /// Get entity using specific GUID
        /// </summary>
        /// <param name="guid">Global Unique Identifier of the entity</param>
        /// <param name="parameters">parameters</param>
        /// <returns>Entity if exists. Null if entity not exists.</returns>
        public async Task<T> GetEntityAsync(string guid, string parameters)
        {
            if (guid.Contains('}') || guid.Contains('{'))
            {
                throw new Exception("Bad Guid: Guid cannot contain '}' or '{'");
            }

            // Convert the resonse to an object of the specific type
            var response = await _conn.GetEntityAsync(_keyname, guid, parameters).ConfigureAwait(false);
            response = ApiResponseCleaner.GetJsonObject(response);
            var entity = EntityConverter.ConvertJsonToObject<T>(response);

            // If entity isn't managed already, add entity to EntityController
            AddEntityToManagedEntitiesCollection(entity);
            return entity;
        }

        public T GetFunctionResult(string querystring)
        {
            var response = _conn.Get(querystring);

            response = ApiResponseCleaner.GetJsonArray(response);

            var entities = EntityConverter.ConvertJsonArrayToObjectList<T>(response);

            return entities.FirstOrDefault();
        }

        /// <summary>
        /// Creates an entity in Exact Online
        /// </summary>
        /// <param name="entity">Entity to create</param>
        /// <returns>True if succeed</returns>
        public bool Create(ref T entity)
        {
            var supportedActions = GetSupportedActions(entity);
            if (!supportedActions.CanCreate)
            {
                throw new Exception("Cannot create entity. Entity does not support creation. Please see the Reference Documentation.");
            }

            // Get Json code
            var created = false;
            var emptyEntity = Activator.CreateInstance<T>();
            var json = EntityConverter.ConvertObjectToJson(emptyEntity, entity, GetEntityController);

            // Send to API
            var response = _conn.Post(json);
            if (!response.Contains("error"))
            {
                created = true;

                // Set values of API in account entity (to ensure GUID is set)
                response = ApiResponseCleaner.GetJsonObject(response);
                entity = EntityConverter.ConvertJsonToObject<T>(response);

                // Try to add the entity to the managed entities collections
                if (!AddEntityToManagedEntitiesCollection(entity))
                {
                    throw new Exception("This entity already exists");
                }

                // Check if the endpoint supports a read action. Some endpoints such as PrintQuotation only support create (POST).
                if (supportedActions.CanRead)
                {
                    // Get entity with linked entities (API Response for creating does not return the linked entities)
                    entity = GetEntity(GetIdentifierValue(entity), _expandfield);
                }
            }
            return created;
        }

        /// <summary>
        /// Creates an entity in Exact Online
        /// </summary>
        /// <param name="entity">Entity to create</param>
        /// <returns>The created entity if succeed</returns>
        public async Task<T> CreateAsync(T entity)
        {
            var supportedActions = GetSupportedActions(entity);
            if (!supportedActions.CanCreate)
            {
                throw new Exception("Cannot create entity. Entity does not support creation. Please see the Reference Documentation.");
            }

            // Get Json code
            var emptyEntity = Activator.CreateInstance<T>();
            var json = EntityConverter.ConvertObjectToJson(emptyEntity, entity, GetEntityController);

            // Send to API
            var response = await _conn.PostAsync(json).ConfigureAwait(false);
            if (!response.Contains("error"))
            {
                // Set values of API in account entity (to ensure GUID is set)
                response = ApiResponseCleaner.GetJsonObject(response);
                var createdEntity = EntityConverter.ConvertJsonToObject<T>(response);

                // Try to add the entity to the managed entities collections
                if (!AddEntityToManagedEntitiesCollection(createdEntity))
                {
                    throw new Exception("This entity already exists");
                }

                // Check if the endpoint supports a read action. Some endpoints such as PrintQuotation only support create (POST).
                if (supportedActions.CanRead)
                {
                    // Get entity with linked entities (API Response for creating does not return the linked entities)
                    createdEntity = await GetEntityAsync(GetIdentifierValue(createdEntity), _expandfield).ConfigureAwait(false);
                }
                return createdEntity;
            }
            throw new Exception("Response contains error.");
        }

        /// <summary>
        /// Updates an entity in Exact Online
        /// </summary>
        /// <param name="entity">Entity to update</param>
        /// <returns>True if succeeded</returns>
        public bool Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentException("Controller Update: Entity cannot be null");
            }

            // Check if entity can be updated
            if (!IsUpdateable(entity))
            {
                throw new Exception("Cannot update entity. Entity is not updateable. Please see the Reference Documentation.");
            }

            var associatedController = (EntityController)_entityControllers[GetIdentifierValue(entity)];
            return associatedController == null
                ? throw new Exception("Entity identifier value not found")
                : associatedController.Update(entity);
        }

        /// <summary>
        /// Updates an entity in Exact Online
        /// </summary>
        /// <param name="entity">Entity to update</param>
        /// <returns>True if succeeded</returns>
        public Task<bool> UpdateAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentException("Controller Update: Entity cannot be null");
            }

            // Check if entity can be updated
            if (!IsUpdateable(entity))
            {
                throw new Exception("Cannot update entity. Entity is not updateable. Please see the Reference Documentation.");
            }

            var associatedController = (EntityController)_entityControllers[GetIdentifierValue(entity)];
            return associatedController == null
                ? throw new Exception("Entity identifier value not found")
                : associatedController.UpdateAsync(entity);
        }

        private static bool IsUpdateable(T entity) => GetSupportedActions(entity).CanUpdate;

        /// <summary>
        /// Deletes an entity from Exact Online
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>True if succeeded</returns>
        public bool Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentException("Controller Delete: Entity cannot be null");
            }

            // Check if entity can be deleted
            if (!IsDeleteable(entity))
            {
                throw new Exception("Cannot delete entity. Entity does not support deleting. Please see the Reference Documentation.");
            }

            // Delete entity
            var entityIdentifier = GetIdentifierValue(entity);
            var associatedController = (EntityController)_entityControllers[entityIdentifier];

            var returnValue = false;
            if (associatedController.Delete())
            {
                returnValue = true;
                _entityControllers.Remove(entityIdentifier);
            }
            return returnValue;
        }

        /// <summary>
        /// Deletes an entity from Exact Online
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>True if succeeded</returns>
        public async Task<bool> DeleteAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentException("Controller Delete: Entity cannot be null");
            }

            // Check if entity can be deleted
            if (!IsDeleteable(entity))
            {
                throw new Exception("Cannot delete entity. Entity does not support deleting. Please see the Reference Documentation.");
            }

            // Delete entity
            var entityIdentifier = GetIdentifierValue(entity);
            var associatedController = (EntityController)_entityControllers[entityIdentifier];

            var returnValue = false;
            if (await associatedController.DeleteAsync().ConfigureAwait(false))
            {
                returnValue = true;
                _entityControllers.Remove(entityIdentifier);
            }
            return returnValue;
        }

        private static bool IsDeleteable(T entity) => GetSupportedActions(entity).CanDelete;

        private static SupportedActionsSDK GetSupportedActions(T entity) => SupportedActionsSDK.GetByType(entity.GetType());

        /// <summary>
        /// Get the unique value of the entity
        /// </summary>
        /// <returns>Identifier value of the entity. Null if the indicated keyname is set to null or is not found.</returns>
        public string GetIdentifierValue(object entity) =>
            _keyname == null
                ? null
                : _keyname.Contains(",")
                ? null // throw new Exception("Currently the SDK doesn't support entities with a compound key.") // why throw an exception if it only disables the auto change tracking?
                : entity.GetType().GetProperty(_keyname).GetValue(entity).ToString();

        /// <summary>
        /// Adds multiple entities to the managed entities collection.
        /// Only adds the entities with an identifier value.
        /// </summary>
        public void AddEntitiesToManagedEntitiesCollection(IEnumerable<object> entities)
        {
            foreach (var entity in entities.Where(e => GetIdentifierValue(e) != null))
            {
                AddEntityToManagedEntitiesCollection(entity);
            }
        }
        /// <summary>
        /// Adds an associated intance of the EntityController class to the _controllers if the entity is not yet managed 
        /// </summary>
        public bool AddEntityToManagedEntitiesCollection(object entity)
        {
            var returnValue = false;
            var entityIdentifier = GetIdentifierValue(entity);
            if (entityIdentifier == null)
            {
                throw new ArgumentException("Cannot add an entity without an entity identifier", nameof(entity));
            }

            if (!_entityControllers.Contains(entityIdentifier))
            {
                var newController = new EntityController(entity, _keyname, entityIdentifier, _conn, GetEntityController);
                _entityControllers.Add(entityIdentifier, newController);

                returnValue = true;

                // Get linked entity fields
                var linkedEntityFields = from property in entity.GetType().GetProperties()
										 let value = property.GetValue(entity)
										 where value != null
                                         let ns = value.GetType().Namespace
                                         where ns != null
											&& ns.Contains("System.Collections.Generic")
                                         select value;

                // Get associated controller & registrate entity
                foreach (var field in linkedEntityFields)
                {
                    foreach (var linkedEntity in (IEnumerable)field)
                    {
                        if (_getEntityManager != null)
                        {
                            var controller = _getEntityManager(linkedEntity.GetType());
                            controller.AddEntityToManagedEntitiesCollection(linkedEntity);
                        }
                        else
                        {
                            throw new Exception("Cannot registrate linked entity: Specific delegate is not set.");
                        }
                    }
                }
            }

            return returnValue;
        }

        public EntityController GetEntityController(string guid) => (EntityController)_entityControllers[guid];

        /// <summary>
        /// Registrates a linked entity field so the Controller knows the field to Expand
        /// </summary>
        public void RegistrateLinkedEntityField(string fieldname) => _expandfield = fieldname;

        /// <summary>
        /// Method for returning the correct EntityController
        /// This method is used as a delegate, so that ExactOnlineJsonConverter
        /// knows the associated EntityController of a Linked Entity so it can perform
        /// methods on the EntityController to see if the entity is updated
        /// </summary>
        public EntityController GetEntityController(object o)
        {
            var entityManager = _getEntityManager(o.GetType());
            var id = entityManager.GetIdentifierValue(o);
            return entityManager.GetEntityController(id);
        }
    }
}
