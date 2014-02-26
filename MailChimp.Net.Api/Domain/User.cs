using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace MailChimp.Net.Api.Domain
{
    public sealed class User
    {
        [JsonProperty("id")]
        public int ID
        {
            get;
            set;
        }
        [JsonProperty("username")]
        public string Username
        {
            get;
            set;
        }
        [JsonProperty("name")]
        public string Name
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
        [JsonProperty("role")]
        public string Role
        {
            get;
            set;
        }
        [JsonProperty("avatar")]
        public string Avatar
        {
            get;
            set;
        }
        [JsonProperty("global_user_id")]
        public int GlobalUserId
        {
            get;
            set;
        }
        [JsonProperty("dc_unique_id")]
        public string DataCentreUniqueID
        {
            get;
            set;
        }
    }
}
