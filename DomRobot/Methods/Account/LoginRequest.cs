using System.Text.Json.Serialization;

namespace DomRobot.Methods.Account
{
    public class LoginRequest : Request<LoginRequest.LoginData>
    {
        public LoginRequest(string username, string password) : base("account.login")
        {
            Put("user", username);
            Put("pass", password);
        }

        public class LoginData
        {
                [JsonInclude, JsonPropertyName("customerId")]
                public int CustomerId { get; set; }
                [JsonInclude, JsonPropertyName("accountId")]
                public int AccountId { get; set; }
                [JsonInclude, JsonPropertyName("tfa")]
                public string Tfa { get; set; }
                [JsonInclude, JsonPropertyName("builddate")]
                public string Builddate { get; }
                [JsonInclude, JsonPropertyName("version")]
                public string Version { get; }
        }
    }
}