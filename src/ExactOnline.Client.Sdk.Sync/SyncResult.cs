using ExactOnline.Client.Sdk.Enums;
using System;

namespace ExactOnline.Client.Sdk.Sync
{
	public class SyncResult
	{
		public SyncResult(Type modelType, EndpointTypeEnum endpointType) =>
			(ModelType, EndpointType) = (modelType, endpointType);

		public Type ModelType { get; }
		public EndpointTypeEnum EndpointType { get; }
		public int RecordsRead { get; set; }
		public int RecordsInsertedOrUpdated { get; set; }
		public int RecordsDeletedRead { get; set; }
		public int RecordsDeleted { get; set; }

		public override string ToString() => $"SYNCHRONIZED '{ModelType.Name}' using {EndpointType} endpoint: " + Environment.NewLine +
			$"{RecordsRead,10} records read" + Environment.NewLine +
			$"{RecordsInsertedOrUpdated,10} records inserted or updated" + Environment.NewLine +
			$"{RecordsDeletedRead,10} records read to delete" + Environment.NewLine +
			$"{RecordsDeleted,10} records deleted";
	}
}
