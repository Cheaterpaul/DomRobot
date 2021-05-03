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
            [JsonPropertyName("user")]
            public string Username { get; }
            [JsonPropertyName("pass")]
            public string Password { get; }
            [JsonPropertyName("lang")]
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
                [JsonPropertyName("customerId")]
                public int CustomerId { get; }
                [JsonPropertyName("accountId")]
                public int AccountId { get; }
                [JsonPropertyName("tfa")]
                public string Tfa { get; }
                [JsonPropertyName("builddate")]
                public string Builddate { get; }
                [JsonPropertyName("version")]
                private string Version { get; }
        }
    }
}