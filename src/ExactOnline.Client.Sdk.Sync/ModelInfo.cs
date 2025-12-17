using System.Collections;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Reflection;
using ExactOnline.Client.Models;
using ExactOnline.Client.Models.Sync;
using Newtonsoft.Json;

namespace ExactOnline.Client.Sdk.Sync;

public class FieldInfo
{
	public FieldInfo(string name, PropertyInfo property, bool isKey) =>
		(Name, Property, IsKey) = (name, property, isKey);

	public string Name { get; private set; }
	public PropertyInfo Property { get; private set; }
	public bool IsKey { get; private set; }
}

public class ModelInfo
{
	private static readonly Hashtable _modelInfos = [];

	public static ModelInfo For<TModel>() => For(typeof(TModel));

	public static ModelInfo For(Type modelType)
	{
		if (_modelInfos[modelType] is not ModelInfo modelInfo)
		{
			modelInfo = new(modelType);
			_modelInfos.Add(modelType, modelInfo);
		}
		return modelInfo;
	}

	private readonly Type _modelType;
	private readonly Lazy<SupportedActionsSDK> _supportedActions;
	private readonly Lazy<bool> _supportsSync;
	private readonly Lazy<string?> _identifierName;
	private readonly Lazy<Type?> _identifierType;
	private readonly Lazy<LambdaExpression?> _identifierLambda;
	private readonly Lazy<LambdaExpression?> _timestampLambda;
	private readonly Lazy<LambdaExpression?> _timestampCastedToNullableLambda;
	private readonly Lazy<LambdaExpression?> _modifiedLambda;
	private readonly Lazy<FieldInfo[]> _fields;

	public ModelInfo(Type modelType)
	{
		_modelType = modelType;
		_supportedActions = new(() => SupportedActionsSDK.GetByType(modelType));
		_supportsSync = new(() => modelType.IsSubclassOf(typeof(SupportsSync)));
		_identifierName = new(GetIdentifierName);
		_identifierType = new(GetIdentifierType);
		_identifierLambda = new(() => LambdaForProperty(IdentifierName));
		_timestampLambda = new(() => LambdaForProperty(TimestampName));
		_timestampCastedToNullableLambda = new(() => LambdaForPropertyCastedToNullable(TimestampName));
		_modifiedLambda = new(() => LambdaForPropertyCastedToNullable(ModifiedName));
		_fields = new(GetFields);
	}

	public bool SupportsCreate => _supportedActions.Value.CanCreate;
	public bool SupportsRead => _supportedActions.Value.CanRead;
	public bool SupportsUpdate => _supportedActions.Value.CanUpdate;
	public bool SupportsDelete => _supportedActions.Value.CanDelete;
	public bool SupportsBulk => _supportedActions.Value.CanBulkRead;
	public bool SupportsSync => _supportsSync.Value;

	public string? IdentifierName => _identifierName.Value;
	public TId? IdentifierValue<TModel, TId>(TModel entity)
	{
		if (IdentifierName == null)
		{
			return default;
		}

		var idNames = IdentifierName.Split(',');
		if (idNames.Length == 1)
		{
			return (TId)_modelType.GetProperty(idNames[0]).GetValue(entity);
		}
		// We're dealing with a composite id
		TId idValue = (TId)Activator.CreateInstance(IdentifierType);
		var dynamicClass = idValue as DynamicClass;
		foreach (var idName in idNames)
		{
			dynamicClass?.SetDynamicPropertyValue(idName, _modelType.GetProperty(idName).GetValue(entity));
		}
		return idValue;
	}
	public Type? IdentifierType => _identifierType.Value;
	public Expression<Func<TModel, TId>> IdentifierLambda<TModel, TId>() =>
		_identifierLambda.Value as Expression<Func<TModel, TId>> ?? throw new InvalidOperationException("Identifier lambda is not set.");

	public static string TimestampName => "Timestamp";
	public long? TimestampValue<TModel>(TModel entity) =>
		(long?)_modelType.GetProperty(TimestampName)?.GetValue(entity);
	public Expression<Func<TModel, long>> TimestampLambda<TModel>() =>
		_timestampLambda.Value as Expression<Func<TModel, long>> ?? throw new InvalidOperationException("Timestamp lambda is not set.");
	public Expression<Func<TModel, long?>> TimestampCastedToNullableLambda<TModel>() =>
		_timestampCastedToNullableLambda.Value as Expression<Func<TModel, long?>> ?? throw new InvalidOperationException("Timestamp casted to nullable lambda is not set.");

	public static string ModifiedName => "Modified";
	public bool HasModifiedProperty => _modifiedLambda.Value != null;
	public Expression<Func<TModel, DateTime?>> ModifiedLambda<TModel>() =>
		_modifiedLambda.Value as Expression<Func<TModel, DateTime?>> ?? throw new InvalidOperationException("Modified lambda is not set.");

	public FieldInfo[] Fields(bool forSync = false) => forSync ? FieldsForSync() : [.. _fields.Value.Where(f => f.Name != "Timestamp")];
	public string[] FieldNames(bool forSync = false) => [.. Fields(forSync).Select(f => f.Name)];

	public bool HasDeletedEntityType =>
		_modelType == typeof(Client.Models.CRM.Account) ||
		_modelType == typeof(Client.Models.CRM.Address) ||
		_modelType == typeof(Client.Models.CRM.Contact) ||
		_modelType == typeof(Client.Models.CRM.Quotation) ||
		_modelType == typeof(Client.Models.Documents.Document) ||
		_modelType == typeof(Client.Models.Documents.DocumentAttachment) ||
		_modelType == typeof(Client.Models.Financial.GLAccount) ||
		_modelType == typeof(Client.Models.FinancialTransaction.TransactionLine) ||
		_modelType == typeof(Client.Models.Logistics.SalesItemPrice) ||
		_modelType == typeof(Client.Models.Logistics.Item) ||
		_modelType == typeof(Client.Models.SalesOrder.SalesOrder) ||
		_modelType == typeof(Client.Models.SalesInvoice.SalesInvoice);
	public EntityType DeletedEntityType =>
		_modelType == typeof(Client.Models.CRM.Account) ? EntityType.Accounts
		: _modelType == typeof(Client.Models.CRM.Address) ? EntityType.Addresses
		: _modelType == typeof(Client.Models.CRM.Contact) ? EntityType.Contacts
		: _modelType == typeof(Client.Models.CRM.Quotation) ? EntityType.Quotations
		: _modelType == typeof(Client.Models.Documents.Document) ? EntityType.Documents
		: _modelType == typeof(Client.Models.Documents.DocumentAttachment) ? EntityType.Attachments
		: _modelType == typeof(Client.Models.Financial.GLAccount) ? EntityType.GLAccounts
		: _modelType == typeof(Client.Models.FinancialTransaction.TransactionLine) ? EntityType.GLTransactions
		: _modelType == typeof(Client.Models.Logistics.SalesItemPrice) ? EntityType.ItemPrices
		: _modelType == typeof(Client.Models.Logistics.Item) ? EntityType.Items
		: _modelType == typeof(Client.Models.SalesOrder.SalesOrder) ? EntityType.SalesOrders
		: _modelType == typeof(Client.Models.SalesInvoice.SalesInvoice) ? EntityType.SalesTransactions
		//: typeof(TEntity) == typeof(PaymentTerm) ? EntityType.PaymentTerms
		//: typeof(TEntity) == typeof(TimeCostTransaction) ? EntityType.TimeCostTransactions
		: throw new Exception($"EntityType {_modelType.Name} has no sync delete support.");

	private string? GetIdentifierName() =>
		(Attribute.GetCustomAttributes(_modelType)
			.Where(x => x.GetType() == typeof(DataServiceKey))
			.FirstOrDefault()
		as DataServiceKey)
		?.DataServiceKeyName;

	private Type? GetIdentifierType()
	{
		if (IdentifierName == null)
		{
			return null;
		}
		var idNames = IdentifierName.Split(',');
		return idNames.Length == 1
			? _modelType.GetProperty(idNames[0]).PropertyType
			: GetCompositeIdType(idNames);
	}

	private Type GetCompositeIdType(string[] idNames) =>
		DynamicClassFactory.CreateType(
			[.. idNames
				.Select(name =>
					new DynamicProperty(name, _modelType.GetProperty(name).PropertyType))],
			false);

	// Generates an expression for "entity => entity.propertyName" or "entity => new { entity.propertyName1, entity.propertyName2 }" when dealing with a composite id
	private LambdaExpression? LambdaForProperty(string? propertyName)
	{
		if (propertyName == null)
		{
			return null;
		}
		var propNames = propertyName.Split(',');
		Type propType;
		string expression;
		if (propNames.Length == 1)
		{
			var propertyInfo = _modelType.GetProperty(propertyName);
			if (propertyInfo == null)
			{
				return null;
			}
			propType = propertyInfo.PropertyType;
			expression = propertyName;
		}
		else // we're dealing with a composite id property
		{
			if (IdentifierType is null)
			{
				return null;
			}
			propType = IdentifierType;
			expression = $"new ({propertyName})";
		}
		return DynamicExpressionParser.ParseLambda(_modelType, propType, expression);
	}

	// Generates an expression for "entity => (TProperty?) entity.propertyName" when the property is not nullable, otherwise "entity => entity.propertyName"
	private LambdaExpression? LambdaForPropertyCastedToNullable(string? propertyName)
	{
		if (propertyName == null)
		{
			return null;
		}
		var propertyInfo = _modelType.GetProperty(propertyName);
		if (propertyInfo == null)
		{
			return null;
		}
		if (!propertyInfo.PropertyType.IsValueType || Nullable.GetUnderlyingType(propertyInfo.PropertyType) != null)
		{
			// Property is already nullable, no need to cast
			return LambdaForProperty(propertyName);
		}
		var nullableType = typeof(Nullable<>).MakeGenericType(propertyInfo.PropertyType);
		return DynamicExpressionParser.ParseLambda(_modelType, nullableType, propertyName);
	}

	private FieldInfo[] GetFields() =>
		[.. from p in _modelType.GetProperties()
			where p.PropertyType == typeof(string) || !typeof(IEnumerable).IsAssignableFrom(p.PropertyType)
			let fieldName = p.GetCustomAttribute<JsonPropertyAttribute>()?.PropertyName ?? p.Name
			select new FieldInfo(
				fieldName,
				p,
				IdentifierName?.Split(',')?.Any(idName => idName == fieldName) ?? false)];

	private FieldInfo[] FieldsForSync() =>
		[.. _fields.Value.Where(field =>
			!(_modelType == typeof(Client.Models.Manufacturing.ShopOrderMaterialPlanDetail) &&
					field.Name == "Calculator" ||
			  _modelType == typeof(Client.Models.CRM.Quotation) &&
					field.Name == "QuotationLines" ||
			  _modelType == typeof(Client.Models.SalesInvoice.SalesInvoice) &&
					field.Name == "SalesInvoiceLines" ||
			  _modelType == typeof(Client.Models.SalesOrder.GoodsDelivery) &&
					field.Name == "GoodsDeliveryLines" ||
			  _modelType == typeof(Client.Models.SalesOrder.SalesOrder) &&
					field.Name == "SalesOrderLines" ||
			  _modelType == typeof(Client.Models.SalesOrder.SalesOrderLine) &&
					(field.Name == "QuantityDelivered" || field.Name == "QuantityInvoiced" || field.Name == "Margin")))];
}
