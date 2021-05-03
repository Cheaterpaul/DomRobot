using System.Text;
using System.Text.Json.Serialization;
using OtpNet;

namespace DomRobot.Methods.Account
{
    public class UnlockRequest : Request<UnlockRequest.UnlockParameter, UnlockRequest.UnlockData>
    {
        public UnlockRequest(UnlockParameter parameter) : base("account.unlock", parameter)
        {
        }

        public class UnlockParameter
        {
            [JsonPropertyName("tan")]
            public string tan { get; }

            public UnlockParameter(string sharedSecret)
            {
                this.tan = new Totp(Encoding.UTF8.GetBytes(sharedSecret)).ComputeTotp();
            }
        }

        public class UnlockData
        {
            
        }
    }
}