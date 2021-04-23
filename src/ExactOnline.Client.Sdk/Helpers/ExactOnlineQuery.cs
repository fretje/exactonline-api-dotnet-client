using ExactOnline.Client.Models;
using ExactOnline.Client.Sdk.Enums;
using ExactOnline.Client.Sdk.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ExactOnline.Client.Sdk.Helpers
{
    public class ExactOnlineQuery<T>
    {
        private readonly IController<T> _controller;

        private string _select;
        private readonly List<string> _and = new List<string>();
        private string _skip;
        private string _expand;
        private string _top;
        private string _orderby;
        private string _where;
        private string _skipToken;

        /// <summary>
        /// Creates a new instance of ExactOnlineQuery
        /// </summary>
        public ExactOnlineQuery(IController<T> controller) =>
            _controller = controller ?? throw new ArgumentNullException(nameof(controller));

        /// <summary>
        /// Creates a 'where' clause for the query
        /// </summary>
        public ExactOnlineQuery<T> Where<TProperty>(Expression<Func<T, TProperty>> property, TProperty value, OperatorEnum @operator = OperatorEnum.Eq) =>
            Where($"{TransformExpressionToODataFormat(property.Body)}+{@operator.ToString().ToLower()}+{ToODataParameter(value)}");

        /// <summary>
        /// Creates a 'where' clause for the query
        /// </summary>
        public ExactOnlineQuery<T> Where(string filter)
        {
            if (string.IsNullOrEmpty(filter))
            {
                throw new ArgumentException("Query 'where' operator cannot be empty");
            }

            _where = "$filter=" + filter;

            return this;
        }

        /// <summary>
        /// Appends an 'and' clause to the query. This method can't be called before a where clause is set.
        /// </summary>
        public ExactOnlineQuery<T> And<TProperty>(Expression<Func<T, TProperty>> property, TProperty value, OperatorEnum @operator = OperatorEnum.Eq) =>
            And($"{TransformExpressionToODataFormat(property.Body)}+{@operator.ToString().ToLower()}+{ToODataParameter(value)}");

        /// <summary>
        /// Appends an 'and' clause to the query. This method can't be called before a where clause is set.
        /// </summary>
        public ExactOnlineQuery<T> And(string and)
        {
            if (string.IsNullOrEmpty(and))
            {
                throw new ArgumentException("Query 'and' operator cannot be empty");
            }
            if (string.IsNullOrEmpty(_where))
            {
                throw new ArgumentException("Query 'and' operator cannot be used before 'where' operator is set");
            }

            _and.Add(and);

            return this;
        }

        /// <summary>
        /// Specify the fields to get from the API
        /// </summary>
        /// <param name="properties">The properties to select</param>
        public ExactOnlineQuery<T> Select(params Expression<Func<T, object>>[] properties) =>
            Select(fields: properties.Select(x => TransformExpressionToODataFormat(x.Body)).ToArray());

        /// <summary>
        /// Specify the field(s) to get from the API
        /// </summary>
        /// <param name="fields">The field(s) to get</param>
        public ExactOnlineQuery<T> Select(params string[] fields)
        {
            if (fields != null && fields.Length > 0)
            {
                var select = string.Join(",", fields);

                if (string.IsNullOrEmpty(_select))
                {
                    _select = "$select=" + select;
                }
                else
                {
                    _select += ',' + select;
                }
            }
            return this;
        }

        /// <summary>
        /// Specify the number of records to get from the API
        /// </summary>
        /// <param name="top"></param>
        public ExactOnlineQuery<T> Top(int top)
        {
            _top = string.Format("$top={0}", top);
            return this;
        }

        /// <summary>
        /// Paging: Specify the number of records that must be skipped
        /// </summary>
        /// <param name="skip"></param>
        public ExactOnlineQuery<T> Skip(int skip)
        {
            _skip = string.Format("$skip={0}", skip);
            return this;
        }

        /// <summary>
        /// Specify the field to order by
        /// </summary>
        /// <param name="orderby"></param>
        public ExactOnlineQuery<T> OrderBy(Expression<Func<T, object>> orderby) =>
            OrderBy(TransformExpressionToODataFormat(orderby.Body));

        /// <summary>
        /// Specify the field(s) to order by
        /// </summary>
        /// <param name="orderby"></param>
        public ExactOnlineQuery<T> OrderBy(params string[] orderby)
        {
            if (orderby != null && orderby.Length > 0)
            {
                var orderbyclause = string.Join(",", orderby);

                if (string.IsNullOrEmpty(_orderby))
                {
                    _orderby = "$orderby=" + orderbyclause;
                }
                else
                {
                    _orderby += ',' + orderbyclause;
                }
            }
            return this;
        }

        /// <summary>
        /// Field to Expand with coupled entities
        /// </summary>
        public ExactOnlineQuery<T> Expand(string expand)
        {
            _controller.RegistrateLinkedEntityField(expand);
            _expand = "$expand=" + expand;
            return this;
        }

        /// <summary>
        /// Count the amount of entities in the the entity
        /// </summary>
        public int Count() => _controller.Count(BuildODataQuery(false));

        /// <summary>
        /// Count the amount of entities in the the entity
        /// </summary>
        public Task<int> CountAsync() => _controller.CountAsync(BuildODataQuery(false));

        /// <summary>
        /// Returns a List of entities using the specified query
        /// </summary>
        public List<T> Get() => Get(EndpointTypeEnum.Single);

        /// <summary>
        /// Returns a List of entities using the specified query
        /// <param name="endpointType">Which endpoint type to use.</param>
        /// </summary>
        public List<T> Get(EndpointTypeEnum endpointType)
        {
            var skipToken = string.Empty;
            return Get(ref skipToken, endpointType);
        }

        /// <summary>
        /// Returns a List of entities using the specified query.
        /// </summary>
        /// <param name="skipToken">The variable to store the skiptoken in</param>
        public List<T> Get(ref string skipToken) => Get(ref skipToken, EndpointTypeEnum.Single);

        /// <summary>
        /// Returns a List of entities using the specified query.
        /// </summary>
        /// <param name="skipToken">The variable to store the skiptoken in</param>
        /// <param name="endpointType">Which endpoint type to use.</param>
        public List<T> Get(ref string skipToken, EndpointTypeEnum endpointType)
        {
            AddSkipToken(skipToken);
            return _controller.Get(BuildODataQuery(true), ref skipToken, endpointType);
        }

        /// <summary>
        /// Returns a List of entities using the specified query.
        /// </summary>
        /// <param name="skipToken">The variable to store the skiptoken in</param>
        /// <param name="endpointType">Which endpoint type to use.</param>
        public Task<Models.ApiList<T>> GetAsync(string skiptoken = "", EndpointTypeEnum endpointType = EndpointTypeEnum.Single)
        {
            AddSkipToken(skiptoken);
            return _controller.GetAsync(BuildODataQuery(true), endpointType);
        }

		private void AddSkipToken(string skipToken)
		{
			if (!string.IsNullOrEmpty(skipToken))
			{
				_skipToken = string.Format("$skiptoken={0}", skipToken);
			}
		}

		/// <summary>
		/// Returns one instance of an entity using the specified identifier
		/// </summary>
		public T GetEntity(string identifier)
        {
            if (string.IsNullOrEmpty(identifier))
            {
                throw new ArgumentException("Get entity: Identifier cannot be empty");
            }
            return _controller.GetEntity(identifier, BuildODataQuery(false));
        }

        /// <summary>
        /// Returns one instance of an entity using the specified identifier
        /// </summary>
        public Task<T> GetEntityAsync(string identifier)
        {
            if (string.IsNullOrEmpty(identifier))
            {
                throw new ArgumentException("Get entity: Identifier cannot be empty");
            }
            return _controller.GetEntityAsync(identifier, BuildODataQuery(false));
        }

        /// <summary>
        /// Returns one instance of an entity using the specified identifier
        /// </summary>
        public T GetEntity(Guid identifier)
        {
            if (identifier == Guid.Empty)
            {
                throw new ArgumentException("Get entity: Identifier cannot be empty");
            }
            return _controller.GetEntity(identifier.ToString(), BuildODataQuery(false));
        }

        /// <summary>
        /// Returns one instance of an entity using the specified identifier
        /// </summary>
        public Task<T> GetEntityAsync(Guid identifier)
        {
            if (identifier == Guid.Empty)
            {
                throw new ArgumentException("Get entity: Identifier cannot be empty");
            }
            return _controller.GetEntityAsync(identifier.ToString(), BuildODataQuery(false));
        }

        /// <summary>
        /// Returns one instance of an entity using the specified identifier
        /// </summary>
        public T GetEntity(int identifier) =>
            _controller.GetEntity(identifier.ToString(CultureInfo.InvariantCulture), BuildODataQuery(false));

        /// <summary>
        /// Returns one instance of an entity using the specified identifier
        /// </summary>
        public Task<T> GetEntityAsync(int identifier) =>
            _controller.GetEntityAsync(identifier.ToString(CultureInfo.InvariantCulture), BuildODataQuery(false));

        /// <summary>
        /// Updates the specified entity
        /// </summary>
        public bool Update(T entity) =>
            entity == null
                ? throw new ArgumentException("Update entity: Entity cannot be null")
                : _controller.Update(entity);

        /// <summary>
        /// Updates the specified entity
        /// </summary>
        public Task<bool> UpdateAsync(T entity) =>
            entity == null
                ? throw new ArgumentException("Update entity: Entity cannot be null")
                : _controller.UpdateAsync(entity);

        /// <summary>
        /// Deletes the specified entity
        /// </summary>
        public bool Delete(T entity) =>
            entity == null
                ? throw new ArgumentException("Delete entity: Entity cannot be null")
                : _controller.Delete(entity);

        /// <summary>
        /// Deletes the specified entity
        /// </summary>
        public Task<bool> DeleteAsync(T entity) =>
            entity == null
                ? throw new ArgumentException("Delete entity: Entity cannot be null")
                : _controller.DeleteAsync(entity);

        /// <summary>
        /// Inserts the specified entity into Exact Online
        /// </summary>
        public bool Insert(ref T entity) =>
            entity == null
                ? throw new ArgumentException("Insert entity: Entity cannot be null")
                : _controller.Create(ref entity);

        /// <summary>
        /// Inserts the specified entity into Exact Online
        /// </summary>
        public Task<T> InsertAsync(T entity) =>
            entity == null
                ? throw new ArgumentException("Insert entity: Entity cannot be null")
                : _controller.CreateAsync(entity);

        /// <summary>
        /// Transforms a given C# expression to an OData-compliant expression
        /// </summary>
        private string TransformExpressionToODataFormat(Expression e)
        {
            MemberExpression me = null;

            if (e is MemberExpression)
            {
                me = e as MemberExpression;
            }
            else if (e is UnaryExpression ue)
            {
                me = ue.Operand as MemberExpression;
            }

            if (me != null)
            {
                return me.Member.Name;
            }

            var listArguments = new List<string>();

            if (!(e is MethodCallExpression mce))
            {
                throw new ArgumentException($"Invalid expression '{e}': Lambda expression should resolve a property on model type '{nameof(T)}' (with optional extension method calls).", nameof(e));
            }

            foreach (var argument in mce.Arguments)
            {
                if (argument is ConstantExpression)
                {
                    var ce = argument as ConstantExpression;
                    listArguments.Add(ToODataParameter(ce.Value));
                }
            }

            string arguments = null;
            if (listArguments.Count > 0)
            {
                arguments = "," + string.Join(",", listArguments);
            }

            return $"{mce.Method.Name.ToLower()}({TransformExpressionToODataFormat(mce.Object)}{arguments})";
        }

        /// <summary>
        /// Formats any given value to it's OData-compliant string representation.
        /// </summary>
        private static string ToODataParameter(object value)
        {
            string _value = null;

            if (value != null)
            {
                var type = value.GetType();
                type = Nullable.GetUnderlyingType(type) ?? type;

				_value = type == typeof(string) || type == typeof(char) ? $"'{value}'"
					: type == typeof(Guid) ? $"guid'{value}'"
					: type == typeof(DateTime) ? $"datetime'{value:o}'"
					: type == typeof(bool) ? value.ToString().ToLower()
					: type == typeof(long) ? $"{value}L"
					: type.IsEnum ? $"{value:D}" // need the numerical value of enums, not the name!
					: type == typeof(long) || type == typeof(ulong) ? $"{value}L" // longs need an "L" attached
					: value.ToString();
			}

			return _value;
		}

		/// <summary>
		/// Builds the full OData query from all its individual parts
		/// </summary>
		private string BuildODataQuery(bool selectIsMandatory)
		{
			var queryParts = new List<string>();

			if (!string.IsNullOrEmpty(_where))
			{
				if (_and != null && _and.Count > 0)
				{
					_where += string.Format("+and+{0}", string.Join("+and+", _and));
				}
				queryParts.Add(_where);
			}

			// Add $select
			if (!string.IsNullOrEmpty(_select))
			{
				queryParts.Add(_select);
			}
			else if (selectIsMandatory && !SupportedActionsSDK.GetByType(typeof(T)).AllowsEmptySelect)
			{
				throw new Exception("You have to specify which fields you want to select");
			}

			// Add $skip
			if (!string.IsNullOrEmpty(_skip))
			{
				queryParts.Add(_skip);
			}

			// Add $expand
			if (!string.IsNullOrEmpty(_expand))
			{
				queryParts.Add(_expand);
			}

			// Add top
			if (!string.IsNullOrEmpty(_top))
			{
				queryParts.Add(_top);
			}

			// Add $skipToken
			if (!string.IsNullOrEmpty(_skipToken))
			{
				queryParts.Add(_skipToken);
			}

			// Add orderby
			if (!string.IsNullOrEmpty(_orderby))
			{
				queryParts.Add(_orderby);
			}

			return string.Join("&", queryParts);
		}
	}
}
