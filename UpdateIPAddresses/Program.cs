using System;
using System.Collections.Generic;
using System.Net;
using DomRobot;
using DomRobot.Methods;
using DomRobot.Methods.Account;
using DomRobot.Methods.Nameserver;

namespace UpdateIPAddresses
{
    class Program
    {
        static void Main(string[] args)
        {
            DotNetEnv.Env.Load();
            var debug = args.Length > 0 && args[0].Equals("true");
            Console.WriteLine("Start ip address update:");

            ApiClient client = CreateClient(Environment.GetEnvironmentVariable("username"), Environment.GetEnvironmentVariable("password"), debug: debug);
            
            Console.WriteLine("Get domain entries:");

            List<int> ids = GetIDs2(client);

            Console.WriteLine("Get ip address:");
            
            string ip = GetIp();
            
            Console.WriteLine(ip);
            
            foreach (var id in ids)
            {
                if (requireChange(client, id, ip))
                {
                    ChangeValue(client, id, ip);
                }
            }
            
            Console.WriteLine("Logout");
            
            client.Logout();
        }

        static string GetIp()
        {
            var s =new WebClient().DownloadString(new Uri("https://v6.ident.me/"));
            return s;
        }

        static ApiClient CreateClient(string username, string password, string secret = null, bool debug = false)
        {
            ApiClient client = new ApiClient(ApiClient.LIVE_URL, debug);
            Response<LoginRequest.LoginData> login =client.Login(username, password, secret);
            if (!login.WasSuccessful())
            {
                throw new Exception("Could not connect to API server. Error: " + login.Code + ": " + login.Msg);
            }

            return client;
        }

        static List<int> GetIDs2(ApiClient client)
        {
            Response<InfoRequest.InfoData> response = client.Request(new InfoRequest().Domain("paube.de"));
            List<InfoRequest.InfoData.RecordType > records = response.ResData.Record;
            List<int> ids = new List<int>();
            foreach (var record in records)
            {
                if (record.Name.EndsWith("home.paube.de"))
                {
                    ids.Add(record.Id);
                }
            }

            return ids;
        }

        static bool requireChange(ApiClient client, int id, string ip)
        {
            Response<InfoRequest.InfoData> response = client.Request(new InfoRequest().RecordId(id));
            return !ip.Equals(response.ResData.Record[0].Content);
        }

        static void ChangeValue(ApiClient client, int id, string ip)
        {
            Response<UpdateRecordRequest.UpdateRecordData> response = client.Request(new UpdateRecordRequest(id).Content(ip));

            if (!response.WasSuccessful())
            {
                throw new Exception("Api error while checking the domain status. Code: " + response.Code + ", Message: " + response.Msg);
            }
        }
    }
}