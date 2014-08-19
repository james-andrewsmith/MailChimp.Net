using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MailChimp.Net.Api.Domain
{
    public sealed class CampaignFilter
    {
        [JsonProperty("campaign_id")]
        public string CampaignId
        {
            get;
            set;
        }

        [JsonProperty("parent_id")]
        public string ParentId
        {
            get;
            set;
        }

        [JsonProperty("list_id")]
        public string ListId
        {
            get;
            set;
        }

        [JsonProperty("folder_id")]
        public int FolderId
        {
            get;
            set;
        }

        [JsonProperty("template_id")]
        public int TemplateId
        {
            get;
            set;
        }

        [JsonProperty("status")]
        public string Status
        {
            get;
            set;
        }

        [JsonProperty("type")]
        public CampaignType Type
        {
            get;
            set;
        }

        [JsonProperty("from_name")]
        public string FromName
        {
            get;
            set;
        }

        [JsonProperty("from_email")]
        public string FromEmail
        {
            get;
            set;
        }

        [JsonProperty("title")]
        public string Title
        {
            get;
            set;
        }

        [JsonProperty("subject")]
        public string Subject
        {
            get;
            set;
        }

        [JsonProperty("sendtime_start")]
        public string SendtimeStart
        {
            get;
            set;
        }

        [JsonProperty("sendtime_end")]
        public string SendtimeEnd
        {
            get;
            set;
        }

        [JsonProperty("user_segment")]
        public bool UserSegment
        {
            get;
            set;
        }

        [JsonProperty("exact")]
        public bool Exact
        {
            get;
            set;
        }

    }
}
