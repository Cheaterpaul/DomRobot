namespace DomRobot.Methods.Account
{
    public class LogoutRequest : Request<LogoutRequest.LogoutParameter, LogoutRequest.LogoutData>
    {
        public LogoutRequest() : base("account.logout", new LogoutParameter())
        {
        }

        public class LogoutParameter
        {
            
        }

        public class LogoutData
        {
            
        }
    }
}