using System.Text.Json.Serialization;

// ReSharper disable MemberCanBePrivate.Global

namespace DomRobot.Methods
{
    public class Response<T>
    {
        
        [JsonPropertyName("code")]
        public int Code { get; }
        [JsonPropertyName("msg")]
        public string Msg { get; }
        [JsonPropertyName("resData")]
        public T ResData { get; }

        public bool WasSuccessful()
        {
            return Code is 1000 or 1001;
        }
    }
}