namespace DomRobot.Methods.Account
{
    public class LogoutRequest : Request<LogoutRequest.LogoutData>
    {
        public LogoutRequest() : base("account.logout")
        {
        }

        public class LogoutData
        {
            
        }
    }
}