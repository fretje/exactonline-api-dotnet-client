using System.Collections;
using System.Reflection;

namespace ExactOnline.Client.Sdk.Sync;

public abstract class SyncTargetBase : ISyncTarget
{
	private readonly Hashtable _controllers = [];
	private readonly Type? _controllerType;
	private readonly object[]? _controllerArgs;

	protected SyncTargetBase()
	{ }

	protected SyncTargetBase(Type controllerType, params object[] controllerArgs)
	{
		if (!controllerType.ContainsGenericParameters ||
			controllerType.GetTypeInfo().GenericTypeParameters.Length != 1 ||
			controllerType.GetConstructors().FirstOrDefault(c => ConstructorTakesArgs(c, controllerArgs)) == null)
		{
			throw new Exception("Must provide an open generic type with 1 type parameters (TModel) and a constructor that takes the provided controllerArgs.");
		}
		_controllerType = controllerType;
		_controllerArgs = controllerArgs;
	}

	public ISyncTargetController<TModel> ControllerFor<TModel>()
	{
		if (_controllers[typeof(TModel)] is not ISyncTargetController<TModel> controller)
		{
			controller = CreateControllerFor<TModel>();
			_controllers.Add(typeof(TModel), controller);
		}
		return controller;
	}

	protected virtual ISyncTargetController<TModel> CreateControllerFor<TModel>() =>
		_controllerType == null
			? throw new Exception("Must override CreateControllerFor<TModel> method, or provide a correct controllerType in the constructor.")
			: (ISyncTargetController<TModel>)Activator.CreateInstance(
				  _controllerType.MakeGenericType(typeof(TModel)), _controllerArgs);

	private static bool ConstructorTakesArgs(ConstructorInfo constructor, object[] args)
	{
		var parameters = constructor.GetParameters();
		if (parameters.Length != args.Length)
		{
			return false;
		}
		for (int i = 0; i < parameters.Length; i++)
		{
			var parameterType = parameters[i].ParameterType;
			var arg = args[i];
			if (arg == null && parameterType.IsValueType && Nullable.GetUnderlyingType(parameterType) == null ||
				arg != null && !parameterType.IsAssignableFrom(arg.GetType()))
			{
				return false;
			}
		}
		return true;
	}
}
