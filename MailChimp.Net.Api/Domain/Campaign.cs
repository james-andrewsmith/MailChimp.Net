using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MailChimp.Net.Api.Domain
{
    public sealed class Campaign
    {
        [JsonProperty("id")]
        public string Id
        {
            get;
            set;
        }

        [JsonProperty("web_id")]
        public int WebId
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

        [JsonProperty("content_type")]
        public string ContentType
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

        [JsonProperty("type")]
        public string Type
        {
            get;
            set;
        }

        [JsonProperty("create_time")]
        public string CreateTime
        {
            get;
            set;
        }

        [JsonProperty("send_time")]
        public string SendTime
        {
            get;
            set;
        }

        [JsonProperty("emails_sent")]
        public int EmailsSent
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

        [JsonProperty("subject")]
        public string Subject
        {
            get;
            set;
        }

        [JsonProperty("to_name")]
        public string ToName
        {
            get;
            set;
        }

        [JsonProperty("archive_url")]
        public string ArchiveUrl
        {
            get;
            set;
        }

        [JsonProperty("inline_css")]
        public bool InlineCss
        {
            get;
            set;
        }

        [JsonProperty("analytics")]
        public string Analytics
        {
            get;
            set;
        }

        [JsonProperty("analytics_tag")]
        public string AnalyticsTag
        {
            get;
            set;
        }

        [JsonProperty("authenticate")]
        public bool Authenticate
        {
            get;
            set;
        }

        [JsonProperty("ecomm360")]
        public string ECommerce360
        {
            get;
            set;
        }

        [JsonProperty("auto_tweet")]
        public string AutoTweet
        {
            get;
            set;
        }

        [JsonProperty("auto_fb_post")]
        public string AutoFbPost
        {
            get;
            set;
        }

        [JsonProperty("auto_footer")]
        public bool AutoFooter
        {
            get;
            set;
        }

        [JsonProperty("timewarp")]
        public bool Timewarp
        {
            get;
            set;
        }

        [JsonProperty("timewarp_schedule")]
        public string TimewarpSchedule
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

        [JsonProperty("is_child")]
        public bool IsChild
        {
            get;
            set;
        }

        [JsonProperty("tests_sent")]
        public string TestsSent
        {
            get;
            set;
        }

        [JsonProperty("tests_remain")]
        public string TestsRemain
        {
            get;
            set;
        }

        [JsonProperty("tracking")]
        public CampaignTracking Tracking
        {
            get;
            set;
        }

        [JsonProperty("segment_text")]
        public string SegmentText
        {
            get;
            set;
        }

        [JsonProperty("segment_opts")]
        public List<CampaignSegmentOptions> SegmentOptions
        {
            get;
            set;
        }

        [JsonProperty("saved_segment")]
        public CampaignSegmentOptions SavedSegment  
        {
            get;
            set;
        }

        [JsonProperty("type_opts")]
        public CampaignTypeOptions TypeOptions
        {
            get;
            set;
        }

        [JsonProperty("comments_total")]
        public int CommentsTotal
        {
            get;
            set;
        }

        [JsonProperty("comments_unread")]
        public int CommentsUnraed
        {
            get;
            set;
        }

        [JsonProperty("summary")]
        public ReportSummary Summary
        {
            get;
            set;
        }


    }

    public sealed class ReportSummary
    {
    }
}
