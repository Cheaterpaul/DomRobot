using System;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace DomRobot.Methods.Nameserver
{
    public class UpdateRecordRequest : Request<UpdateRecordRequest.UpdateRecordParameter, UpdateRecordRequest.UpdateRecordData>
    {
        public UpdateRecordRequest(UpdateRecordParameter parameter) : base("nameserver.updateRecord", parameter)
        {
        }

        public class UpdateRecordParameter
        {
            [JsonInclude,JsonPropertyName("id")]
            public string Id { get; set;}
            [JsonInclude,JsonPropertyName("name")]
            public string Name { get; set;}
            [JsonInclude,JsonPropertyName("type")]
            public string Type { get; set;}
            [JsonInclude,JsonPropertyName("content")]
            public string Content { get;set; }
            [JsonInclude,JsonPropertyName("prio")]
            public int Prio { get; set;}
            [JsonInclude,JsonPropertyName("ttl")]
            public int Ttl { get; set;}
            [JsonInclude,JsonPropertyName("urlRedirectType")]
            public string UrlRedirectType { get; set;}
            [JsonInclude,JsonPropertyName("urlRedirectTitle")]
            public string UrlRedirectTitle { get; set;}
            [JsonInclude,JsonPropertyName("urlRedirectDescription")]
            public string UrlRedirectDescription { get;set; }
            [JsonInclude,JsonPropertyName("urlRedirectFavIcon")]
            public string UrlRedirectFavIcon { get; set;}
            [JsonInclude,JsonPropertyName("urlRedirectKeywords")]
            public string UrlRedirectKeywords { get;set; }

            [JsonInclude, JsonPropertyName("urlAppend")]
            public Boolean UrlAppend { get; set; }
            [JsonInclude,JsonPropertyName("testing")]
            public Boolean Testing { get; set;}

            public UpdateRecordParameter(string id, string name = null, string type = null, string content = null, int prio = default, int ttl = default, string urlRedirectType = null, string urlRedirectTitle = null, string urlRedirectDescription = null, string urlRedirectFavIcon = null, string urlRedirectKeywords = null, Boolean urlAppend = null, Boolean testing = null)
            {
                Id = id;
                Name = name;
                Type = type;
                Content = content;
                Prio = prio;
                Ttl = ttl;
                UrlRedirectType = urlRedirectType;
                UrlRedirectTitle = urlRedirectTitle;
                UrlRedirectDescription = urlRedirectDescription;
                UrlRedirectFavIcon = urlRedirectFavIcon;
                UrlRedirectKeywords = urlRedirectKeywords;
                UrlAppend = urlAppend;
                Testing = testing;
            }
        }

       // public record String(string s);

        public record Boolean(bool boolean);
        
        public class UpdateRecordData
        {
            
        }
    }
}