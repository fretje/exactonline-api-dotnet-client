using System;
using ExactOnline.Client.Sdk.Interfaces;

namespace ExactOnline.Client.Sdk.Delegates
{
    /// <summary>
    /// Delegate for low coupling between Controller and ControllerList
    /// Let the Controller find the associated controller for linked entity field without
    /// knowing what other controllers exist
    /// </summary>
    public delegate IEntityManager ManagerForEntity(Type t);
}
