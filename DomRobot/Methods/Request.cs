using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Xml;

namespace DomRobot.Methods
{

    // ReSharper disable once UnusedTypeParameter
    public class Request<T>
    {
        [JsonInclude, JsonPropertyName("method")]
        public string Method { get; set; }

        [JsonInclude, JsonPropertyName("params")]
        public Dictionary<string, object> Parameter { get; set; } = new();

        public Request(string method)
        {
            Method = method;
        }

        public void Put(string key, object value)
        {
            Parameter.Add(key, value);
        }
    }
}