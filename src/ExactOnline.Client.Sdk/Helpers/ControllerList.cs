using System.Collections;
using ExactOnline.Client.Sdk.Controllers;
using ExactOnline.Client.Sdk.Interfaces;

namespace ExactOnline.Client.Sdk.Helpers;

/// <summary>
/// Manages instances of controllers
/// </summary>
public class ControllerList(IApiConnector connector, string baseurl)
{
	private readonly IApiConnector _connector = connector;
	private readonly string _baseUrl = baseurl;
	private readonly Hashtable _controllers = [];
	private readonly Dictionary<string, string> _services = new Services().ServicesDictionary;

	/// <summary>
	/// Method for getting the correct EntityManager. This method is used as a Delegate
	/// </summary>
	public IEntityManager GetEntityManager(Type type)
	{
		var method = typeof(ControllerList).GetMethod(nameof(GetController));
		var genericMethod = method.MakeGenericMethod(type);
		return (IEntityManager)genericMethod.Invoke(this, null);
	}

	/// <summary>
	/// Returns an instance of Controller with the specified type
	/// </summary>
	public IController<T> GetController<T>() where T : class
	{
		var typename = typeof(T).FullName;
		var controller = (Controller<T>)_controllers[typename];

		// If not exists: create
		if (controller is null)
		{
			ApiConnection connection =
				typename == typeof(Client.Models.Current.Me).FullName
					? new(_connector, "system/Me", _baseUrl)
					: _services.TryGetValue(typename, out string value)
						? new(_connector, value, _baseUrl)
						: throw new InvalidOperationException("Specified entity is not known in Exact Online. Please check the reference documentation");

			controller = new(connection, GetEntityManager);

			_controllers.Add(typename, controller);
		}

		return controller;
	}
}
