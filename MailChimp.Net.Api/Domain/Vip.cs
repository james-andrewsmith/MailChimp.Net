using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace MailChimp.Net.Api.Domain
{
    public sealed class Vip
    {
        [JsonProperty("list_id")]
        public string ListID
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
    }
}
