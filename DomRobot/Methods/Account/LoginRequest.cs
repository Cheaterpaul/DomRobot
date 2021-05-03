using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace DomRobot.Methods.Account
{
    public class LoginRequest : Request<LoginRequest.LoginParameter, LoginRequest.LoginData>
    {
        public LoginRequest(string username, string password) : base("account.login", new LoginParameter(username, password))
        {
        }

        public class LoginParameter
        {
            [JsonInclude,JsonPropertyName("user")]
            public string Username { get; }
            [JsonInclude,JsonPropertyName("pass")]
            public string Password { get; }
            [JsonInclude,JsonPropertyName("lang")]
            public string Language { get; }

            public LoginParameter(string username, string password, string language = "de")
            {
                this.Username = username;
                this.Password = password;
                this.Language = language;
            }
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