using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace MailChimp.Net.Api.Domain
{
    public sealed class Condition
    {
        [JsonProperty("field")]
        public string Field
        {
            get;
            set;
        }

        [JsonProperty("op")]
        public string Operation
        {
            get;
            set;
        }

        [JsonProperty("value")]
        public string Value
        {
            get;
            set;
        }

        [JsonProperty("extra")]
        public string Extra
        {
            get;
            set;
        }

    }
}
