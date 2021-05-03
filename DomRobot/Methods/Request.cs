using System.Text.Json.Serialization;

namespace DomRobot.Methods
{

    // ReSharper disable once UnusedTypeParameter
    public class Request<T,TZ>
    {
        [JsonPropertyName("method")]
        public string Method { get; }
        [JsonPropertyName("params")]
        public T Parameter { get; }

        public Request(string method, T parameter)
        {
            Method = method;
            Parameter = parameter;
        }
    }
}