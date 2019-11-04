using System;
using System.Reflection;

public class SupportedActionsSDK : Attribute
{
    public bool CanCreate { get; private set; }
    public bool CanRead { get; private set; }
    public bool CanUpdate { get; private set; }
    public bool CanDelete { get; private set; }

    public bool CanBulkRead { get; private set; }

    public SupportedActionsSDK(bool canCreate, bool canRead, bool canUpdate, bool canDelete)
    {
        CanCreate = canCreate;
        CanRead = canRead;
        CanUpdate = canUpdate;
        CanDelete = canDelete;
    }
    public SupportedActionsSDK(bool canCreate, bool canRead, bool canUpdate, bool canDelete, bool canBulkRead) : this(canCreate, canRead, canUpdate, canDelete)
    {
        CanBulkRead = CanBulkRead;
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

