using System;

namespace ExactOnline.Client.Models.CRM
{
    [SupportedActionsSDK(false, true, false, false)]
    [DataServiceKey("ID")]
    public class AddressState
    {
        /// <summary>Country code</summary>
        public string Country { get; set; }
        /// <summary>Description of state prefixed with the code</summary>
        public string DisplayValue { get; set; }
        /// <summary>Primary key</summary>
        public Guid ID { get; set; }
        /// <summary>Latitude</summary>
        public double? Latitude { get; set; }
        /// <summary>Longitude</summary>
        public double? Longitude { get; set; }
        /// <summary>State name</summary>
        public string Name { get; set; }
        /// <summary>State code</summary>
        public string State { get; set; }
    }
}
