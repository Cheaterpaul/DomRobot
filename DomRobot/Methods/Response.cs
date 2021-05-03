using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace DomRobot.Methods
{
    public class Response<T>
    {
        
        [JsonPropertyName("code")]
        public int Code { get; set; }
        [JsonPropertyName("msg")]
        public string Msg { get; set; }
        [JsonPropertyName("resData")]
        public T ResData { get; set; }

        public bool WasSuccessful()
        {
            return Code is 1000 or 1001;
        }
    }
}