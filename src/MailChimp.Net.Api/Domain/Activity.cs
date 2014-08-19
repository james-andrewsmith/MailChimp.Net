using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace MailChimp.Net.Api.Domain
{
    public sealed class Activity
    {
        [JsonProperty("action")]
        public string Action
        {
            get;
            set;
        }

        [JsonProperty("timestamp")]
        public string Timestamp
        {
            get;
            set;
        }

        [JsonProperty("url")]
        public string Url
        {
            get;
            set;
        }

        [JsonProperty("unique_id")]
        public string UniqueID
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

        [JsonProperty("list_name")]
        public string ListName
        {
            get;
            set;
        }

        [JsonProperty("list_id")]
        public string ListID
        {
            get;
            set;
        }

        [JsonProperty("email")]
        public string Email
        {
            get;
            set;
        }

        [JsonProperty("fname")]
        public string FirstName
        {
            get;
            set;
        }

        [JsonProperty("cc")]
        public string CountryCode
        {
            get;
            set;
        }

        [JsonProperty("lname")]
        public string LastName
        {
            get;
            set;
        }

        [JsonProperty("member_rating")]
        public int MemberRating
        {
            get;
            set;
        }

        [JsonProperty("member_since")]
        public string MemberSince
        {
            get;
            set;
        }

        [JsonProperty("geo")]
        public Geo Geo
        {
            get;
            set;
        }

    }
}
