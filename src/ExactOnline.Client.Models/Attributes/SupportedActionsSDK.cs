using System;
using System.Reflection;

namespace ExactOnline.Client.Models
{
	public sealed class SupportedActionsSDK : Attribute
	{
		public bool CanCreate { get; private set; }
		public bool CanRead { get; private set; }
		public bool CanUpdate { get; private set; }
		public bool CanDelete { get; private set; }

		public bool CanBulkRead { get; private set; }

		public bool AllowsEmptySelect { get; private set; }

		public SupportedActionsSDK(
			bool canCreate,
			bool canRead,
			bool canUpdate,
			bool canDelete,
			bool canBulkRead = false,
			bool allowsEmptySelect = false)
		{
			CanCreate = canCreate;
			CanRead = canRead;
			CanUpdate = canUpdate;
			CanDelete = canDelete;

			CanBulkRead = canBulkRead;

			AllowsEmptySelect = allowsEmptySelect;
		}

		public static SupportedActionsSDK GetByType(Type type)
		{
			var actions = (SupportedActionsSDK)type.GetCustomAttribute(typeof(SupportedActionsSDK));
			if (actions == null)
			{
				actions = new SupportedActionsSDK(false, false, false, false);
			}
			return actions;
		}
	}
}
