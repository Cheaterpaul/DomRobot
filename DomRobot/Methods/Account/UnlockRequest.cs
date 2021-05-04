using System.Text;
using System.Text.Json.Serialization;
using OtpNet;

namespace DomRobot.Methods.Account
{
    public class UnlockRequest : Request<UnlockRequest.UnlockData>
    {
        public UnlockRequest(string totp) : base("account.unlock")
        {
            Put("tan", new Totp(Encoding.UTF8.GetBytes(totp)).ComputeTotp());
        }

        public class UnlockData
        {
            
        }
    }
}