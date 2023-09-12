using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using DomRobot;
using DomRobot.Methods.Nameserver;
using DotNetEnv;

namespace UpdateIPAddresses;

public static class Program
{
    private static void Main(string[] args)
    {
        Env.Load();
        var debug = args.Length > 0 && args[0].Equals("true");
        Console.WriteLine("Start ip address update:");
        var client = CreateClient(Environment.GetEnvironmentVariable("username"), Environment.GetEnvironmentVariable("password"), debug: debug);

        Console.WriteLine("Get domain entries:");
        var ids = GetIDs2(client);

        Console.WriteLine("Get ip address:");
        var ip = GetIp();

        Console.WriteLine(ip);

        foreach (var id in ids.Where(id => RequireChange(client, id, ip)))
        {
            ChangeValue(client, id, ip);
        }

        Console.WriteLine("Logout");

        client.Logout();
    }

    private static string GetIp()
    {
        return new WebClient().DownloadString(new Uri("https://v6.ident.me/"));
    }

    private static ApiClient CreateClient(string username, string password, string secret = null, bool debug = false)
    {
        var client = new ApiClient(ApiClient.LIVE_URL, debug);
        var login = client.Login(username, password, secret);
        if (!login.WasSuccessful()) throw new Exception("Could not connect to API server. Error: " + login.Code + ": " + login.Msg);

        return client;
    }

    private static IEnumerable<int> GetIDs2(ApiClient client)
    {
        var domain = Environment.GetEnvironmentVariable("domain");
        var response = client.Request(new InfoRequest().Domain(domain));
        var records = response.ResData.Record;

        var targets = Environment.GetEnvironmentVariable("target_domain").Split(',').Select(x => $"{x}.{domain}");
        return records.Where(x => targets.Any(y => x.Name.EndsWith(y))).Select(x => x.Id);
    }

    private static bool RequireChange(ApiClient client, int id, string ip)
    {
        var response = client.Request(new InfoRequest().RecordId(id));
        return !ip.Equals(response.ResData.Record[0].Content);
    }

    private static void ChangeValue(ApiClient client, int id, string ip)
    {
        var response = client.Request(new UpdateRecordRequest(id).Content(ip));

        if (!response.WasSuccessful()) throw new Exception("Api error while checking the domain status. Code: " + response.Code + ", Message: " + response.Msg);
    }
}