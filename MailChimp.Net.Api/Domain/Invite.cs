using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace MailChimp.Net.Api.Domain
{
    public sealed class Invite
    {
        [JsonProperty("email")]
        public string Email
        {
            get;
            set;
        }
        [JsonProperty("role")]
        public string Role
        {
            get;
            set;
        }
        [JsonProperty("sent_at")]
        public string SentAt
        {
            get;
            set;
        }
        [JsonProperty("expiration")]
        public string Expiration
        {
            get;
            set;
        }
        [JsonProperty("msg")]
        public string Message
        {
            get;
            set;
        }
    }
}
