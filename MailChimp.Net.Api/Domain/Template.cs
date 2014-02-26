using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace MailChimp.Net.Api.Domain
{
    public sealed class Template
    {
        [JsonProperty("default_content")]
        public string DefaultContent
        {
            get;
            set;
        }

        [JsonProperty("sections")]
        public string Sections
        {
            get;
            set;
        }

        [JsonProperty("source")]
        public string Source
        {
            get;
            set;
        }

        [JsonProperty("preview")]
        public string Preview
        {
            get;
            set;
        }
    }
}
