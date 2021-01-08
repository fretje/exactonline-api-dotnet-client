using ExactOnline.Client.Sdk.Controllers;
using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ExactOnline.Client.Sdk.Sync
{
	public static class ExactOnlineClientExtensions
	{
		private static readonly MethodInfo _synchronizeWithMethod = GetMethod(nameof(SynchronizeWith));
		private static readonly MethodInfo _synchronizeWithAsyncMethod = GetMethod(nameof(SynchronizeWithAsync));

		private static MethodInfo GetMethod(string methodName) =>
			typeof(ExactOnlineClientExtensions)
				.GetMethods(BindingFlags.Public | BindingFlags.Static)
				.Single(m => m.Name == methodName && m.GetGenericArguments().Length == 1);

		public static SyncResult SynchronizeWith(this ExactOnlineClient client, ISyncTarget syncTarget, Type modelType, params string[] fields) =>
			client.InvokeMethod<SyncResult>(_synchronizeWithMethod, syncTarget, modelType, fields);

		public static Task<SyncResult> SynchronizeWithAsync(this ExactOnlineClient client, ISyncTarget syncTarget, Type modelType, params string[] fields) =>
			client.InvokeMethod<Task<SyncResult>>(_synchronizeWithAsyncMethod, syncTarget, modelType, fields);

		private static TReturn InvokeMethod<TReturn>(this ExactOnlineClient client, MethodInfo method, ISyncTarget syncTarget, Type modelType, params string[] fields) =>
			// here we call SynchronizeWith or SynchronizeWithAsync<TModel>(query, syncTarget, fields) with the right TModel for modelType
			(TReturn)method
				.MakeGenericMethod(modelType)
				.Invoke(null, new object[] { client, syncTarget, fields });

		public static SyncResult SynchronizeWith<TModel>(this ExactOnlineClient client, ISyncTarget syncTarget, params string[] fields)
			where TModel : class =>
			client.For<TModel>().Select(fields).SynchronizeWith(syncTarget, client);

		public static Task<SyncResult> SynchronizeWithAsync<TModel>(this ExactOnlineClient client, ISyncTarget syncTarget, params string[] fields)
			where TModel : class =>
			client.For<TModel>().Select(fields).SynchronizeWithAsync(syncTarget, client);
	}
}
