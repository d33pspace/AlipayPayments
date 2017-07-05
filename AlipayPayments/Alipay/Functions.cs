using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlipayCore
{
    public static class Functions
    {
        // Convert Object to Dictionary
        public static IDictionary<string, object> ToDictionary(object source)
        {
            var dictionary = new Dictionary<string, object>();
            foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(source))
            {
                object value = property.GetValue(source);
                dictionary.Add(property.Name, value);
            }
            return dictionary;
        }

        // Convert Json String to Object
        public static T GetObjectByJson<T>(string argJson)
        {
            argJson = "{'data':" + argJson + "}";
            var replacedJson = argJson.Replace('"', '\'');
            var json = Newtonsoft.Json.Linq.JObject.Parse(replacedJson);
            var dicts = JsonConvert.SerializeObject(json["data"]);
            var result = JsonConvert.DeserializeObject<T>(
                dicts,
                new JsonSerializerSettings()
                {
                    MissingMemberHandling = MissingMemberHandling.Ignore,
                    NullValueHandling = NullValueHandling.Ignore
                });
            return result;
        }
    }
}
