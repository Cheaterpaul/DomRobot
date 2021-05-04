using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using DomRobot.Methods;
using DomRobot.Methods.Account;

namespace DomRobot
{
    public class ApiClient
    {
        public const string VERSION = "0.1";
        public const string LIVE_URL = "https://api.domrobot.com";
        public const string OTE_URL = "https://api.ote.domrobot.com";

        private readonly string _apiUrl;
        private readonly ApiType _apiType = ApiType.JsonRpc;
        private readonly bool _debugMode;

        private readonly HttpClient _httpClient;

        public ApiClient(string apiUrl, bool debugMode = false)
        {
            _apiUrl = apiUrl;
            _debugMode = debugMode;

            _httpClient = new HttpClient();
        }

        public Response<LoginRequest.LoginData> Login(string username, string password, string sharedSecret = null)
        {
            Response<LoginRequest.LoginData> response = Task.Run(async () => await CallApi(new LoginRequest(username, password))).Result;

            if (!response.WasSuccessful() || response.ResData.Tfa.Equals("0")) return response;
            if (sharedSecret == null)
            {
                throw new ArgumentException("Api requests two factor authentication but no shared secret is given.");
            }

            var tfaResponse = Task.Run(async () => await CallApi(new UnlockRequest(sharedSecret))).Result;
            if (!tfaResponse.WasSuccessful())
            {
                throw new Exception("2FA Failed with code: " + tfaResponse.Code+", message: " + tfaResponse.Msg);
            }
            return response;
        }

        public void Logout()
        {
            Task.Run(async () => await CallApi(new LogoutRequest()));
        }

        public Response<T> Request<T>(Request<T> request)
        {
            return Task.Run(async () => await CallApi(request)).Result;
        }

        private async Task<Response<T>> CallApi<T>(Request<T> request)
        {
            var json = JsonSerializer.Serialize(request, new JsonSerializerOptions(){IgnoreNullValues = true});
            if (_debugMode)
            {
                Console.WriteLine("Send:");
                Console.WriteLine(json);
            }
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            //data.Headers.Add("User-Agent", "DomRobot/" + VERSION + " (C#)");

            var response = await _httpClient.PostAsync(_apiUrl + _apiType.Path, data);

            string result = response.Content.ReadAsStringAsync().Result;
            if (_debugMode)
            {
                Console.WriteLine("Receive:");
                Console.WriteLine(result);
            }
            
            var resultObj = JsonSerializer.Deserialize<Response<T>>(result, new JsonSerializerOptions{IncludeFields = true});
            if (resultObj == null)
            {
                throw new Exception("Deserialization error");
            }
            return resultObj;
        }
    }
}