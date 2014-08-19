using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace MailChimp.Net.Api.Domain
{
    public sealed class CampaignTypeOptions
    {
        public CampaignRssOptions Rss
        {
            get;
            set;
        }

        public CampaignABSplit ABSplit
        {
            get;
            set;
        }

        public CampaignAuto Auto
        {
            get;
            set;
        }
    }

    public sealed class CampaignABSplit
    {
    }

    public sealed class CampaignAuto
    {
    }

    public class CampaignRssOptions
    {
        [JsonProperty("url")]
        public string url
        {
            get;
            set;
        }

        [JsonProperty("schedule")]
        public string schedule
        {
            get;
            set;
        }

        [JsonProperty("schedule_hour")]
        public string schedule_hour
        {
            get;
            set;
        }

        [JsonProperty("schedule_weekday")]
        public string schedule_weekday
        {
            get;
            set;
        }


        [JsonProperty("schedule_monthday")]
        public string schedule_monthday
        {
            get;
            set;
        }

        [JsonProperty("days")]
        public CampaignSchedule Days
        {
            get;
            set;
        }
    }

    public sealed class CampaignSchedule
    {

        [JsonProperty("1")]
        public bool Monday
        {
            get;
            set;
        }

        [JsonProperty("2")]
        public bool Tuesday
        {
            get;
            set;
        }

        [JsonProperty("3")]
        public bool Wednesday
        {
            get;
            set;
        }

        [JsonProperty("4")]
        public bool Thursday
        {
            get;
            set;
        }

        [JsonProperty("5")]
        public bool Friday
        {
            get;
            set;
        }

        [JsonProperty("6")]
        public bool Saturday
        {
            get;
            set;
        }
         
        [JsonProperty("7")]
        public bool Sunday
        {
            get;
            set;
        }
    }
}
