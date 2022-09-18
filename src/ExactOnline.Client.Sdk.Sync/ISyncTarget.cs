namespace ExactOnline.Client.Sdk.Sync;

public interface ISyncTarget
{
	ISyncTargetController<TModel> ControllerFor<TModel>();
}
