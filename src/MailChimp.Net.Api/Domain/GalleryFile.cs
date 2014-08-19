using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace MailChimp.Net.Api.Domain
{
    public sealed class GalleryFile
    {
        [JsonProperty("name")]
        public string Name
        {
            get;
            set;
        }

        [JsonProperty("time")]
        public string Time
        {
            get;
            set;
        }

        [JsonProperty("size")]
        public int Size
        {
            get;
            set;
        }

        [JsonProperty("full")]
        public string Full
        {
            get;
            set;
        }

        [JsonProperty("thumb")]
        public string Thumb
        {
            get;
            set;
        }

    }
}
