using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DomRobot.Methods.Nameserver
{
    public class InfoRequest : Request<InfoRequest.InfoData>
    {
        public InfoRequest(string domain) : base("nameserver.info")
        {
            Put("domain", domain);
        }

        public class InfoData
        {
            [JsonInclude,JsonPropertyName("roId")]
            public int RoId { get; set; }
            [JsonInclude,JsonPropertyName("domain")]
            public string Domain { get; set; }
            [JsonInclude,JsonPropertyName("type")]
            public string Type { get; set; }
            [JsonInclude,JsonPropertyName("masterIp")]
            public string MasterIp { get; set; }
            [JsonInclude,JsonPropertyName("lastZoneCheck")]
            public string LastZoneCheck { get; set; }
            [JsonInclude,JsonPropertyName("slaveDns")]
            public List<SlaveDnsType> SlaveDns { get; set; }
            [JsonInclude,JsonPropertyName("SOAserial")]
            public string SoAserial { get; set; }
            [JsonInclude,JsonPropertyName("count")]
            public int Count { get; set; }
            [JsonInclude,JsonPropertyName("record")]
            public List<RecordType> Record { get; set; }
            
            public class SlaveDnsType
            {
                [JsonInclude,JsonPropertyName("name")]
                public string Name { get; set; }
                [JsonInclude,JsonPropertyName("ip")]
                public string Ip { get; set; }
            }
            
            public class RecordType
            {
                [JsonInclude,JsonPropertyName("id")]
                public int Id { get; set;}
                [JsonInclude,JsonPropertyName("name")]
                public string Name { get; set;}
                [JsonInclude,JsonPropertyName("type")]
                public string Type { get;set; }
                [JsonInclude,JsonPropertyName("content")]
                public string Content { get; set;}
                [JsonInclude,JsonPropertyName("ttl")]
                public int Ttl { get; set;}
                [JsonInclude,JsonPropertyName("prio")]
                public int Prio { get; set;}
                [JsonInclude,JsonPropertyName("urlRedirectType")]
                public string UrlRedirectType { get;set; }
                [JsonInclude,JsonPropertyName("urlRedirectTitle")]
                public string UrlRedirectTitle { get;set; }
                [JsonInclude,JsonPropertyName("urlRedirectDescription")]
                public string UrlRedirectDescription { get; set;}
                [JsonInclude,JsonPropertyName("urlRedirectKeywords")]
                public string UrlRedirectKeywords { get;set; }
                [JsonInclude,JsonPropertyName("urlRedirectFavIcon")]
                public string UrlRedirectFavIcon { get; set;}
                [JsonInclude,JsonPropertyName("urlAppend")]
                public bool UrlAppend { get;set; }
            }
        }
        
    }
}