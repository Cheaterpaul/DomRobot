using System;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace DomRobot.Methods.Nameserver
{
    public class UpdateRecordRequest : Request<UpdateRecordRequest.UpdateRecordData>
    {
        public UpdateRecordRequest(string id) : base("nameserver.updateRecord")
        {
            Put("id", id);
        }

        public UpdateRecordRequest Name(string name)
        {
            Put("name", name);
            return this;
        }
        
        public UpdateRecordRequest Type(string type)
        {
            Put("type", type);
            return this;
        }
        
        public UpdateRecordRequest Content(string content)
        {
            Put("content", content);
            return this;
        }
        
        public UpdateRecordRequest Prio(int prio)
        {
            Put("prio", prio);
            return this;
        }
        
        public UpdateRecordRequest Ttl(int ttl)
        {
            Put("ttl", ttl);
            return this;
        }
        
        public UpdateRecordRequest UrlRedirectType(string urlRedirectType)
        {
            Put("urlRedirectType", urlRedirectType);
            return this;
        }
        
        public UpdateRecordRequest UrlRedirectTitle(string urlRedirectTitle)
        {
            Put("urlRedirectTitle", urlRedirectTitle);
            return this;
        }
        
        public UpdateRecordRequest UrlRedirectDescription(string urlRedirectDescription)
        {
            Put("urlRedirectDescription", urlRedirectDescription);
            return this;
        }
        
        public UpdateRecordRequest UrlRedirectFavIcon(string urlRedirectFavIcon)
        {
            Put("urlRedirectFavIcon", urlRedirectFavIcon);
            return this;
        }
        public UpdateRecordRequest UrlRedirectKeywords(string urlRedirectKeywords)
        {
            Put("urlRedirectKeywords", urlRedirectKeywords);
            return this;
        }
        public UpdateRecordRequest UrlAppend(bool urlAppend)
        {
            Put("urlAppend", urlAppend);
            return this;
        }
        public UpdateRecordRequest Testing(bool testing)
        {
            Put("testing", testing);
            return this;
        }
        
        public class UpdateRecordData
        {
            
        }
    }
}