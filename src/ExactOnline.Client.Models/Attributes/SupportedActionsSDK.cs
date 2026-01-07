using System.Reflection;

namespace ExactOnline.Client.Models;

public sealed class SupportedActionsSDK(
	bool canCreate,
	bool canRead,
	bool canUpdate,
	bool canDelete,
	bool canBulkRead = false,
	bool allowsEmptySelect = false) : Attribute
{
	public bool CanCreate { get; } = canCreate;
	public bool CanRead { get; } = canRead;
	public bool CanUpdate { get; } = canUpdate;
	public bool CanDelete { get; } = canDelete;

	public bool CanBulkRead { get; } = canBulkRead;

	public bool AllowsEmptySelect { get; } = allowsEmptySelect;

	public static SupportedActionsSDK GetByType(Type type)
	{
		var actions = type.GetCustomAttribute<SupportedActionsSDK>();
		actions ??= new(false, false, false, false);
		return actions;
	}
}
