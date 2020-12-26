using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Script.Serialization;

namespace ExactOnline.Client.Sdk.Helpers
{
    /// <summary>
    /// Custom JavaScriptConverter for parsing datetime value correctly
    /// </summary>
    public class JssDateTimeConverter : JavaScriptConverter
    {
        public override IEnumerable<Type> SupportedTypes => new[] { typeof(object) };

        public override object Deserialize(IDictionary<string, object> dictionary, Type type, JavaScriptSerializer serializer)
        {
            var keys = new List<string>(dictionary.Keys);

            foreach (var key in keys)
            {
                var entity = dictionary[key];

                // Check if content is a dictionary > send to this method recursively
                if (entity != null && entity.GetType() == typeof(Dictionary<string, object>))
                {
                    var value = (Dictionary<string, object>)entity;
                    Deserialize(value, type, serializer);
                }
                else
                {
                    var value = entity;
                    if (value != null)
                    {
                        // Set EPOCH datetime
                        var valueType = value.GetType();
                        if (valueType == typeof(DateTime))
                        {
                            var date = (DateTime)entity;
                            var t = date - new DateTime(1970, 1, 1);
                            var timestamp = t.TotalMilliseconds;
                            dictionary[key] = string.Format("/Date({0})/", timestamp);
                        }

                        // For collection within this collection > send to this method recursively
                        if (valueType == typeof(ArrayList))
                        {
                            var dictionaries = ((ArrayList)value).ToArray().Where(x => x.GetType() == typeof(Dictionary<string, object>));

                            foreach (var dict in dictionaries)
                            {
                                Deserialize((Dictionary<string, object>)dict, type, serializer);
                            }
                        }
                    }
                }
            }
            return dictionary;
        }

        public override IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer) => null;
    }
}
