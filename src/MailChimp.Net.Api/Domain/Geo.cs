using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace MailChimp.Net.Api.Domain
{
    public sealed class Geo
    {
        [JsonProperty("latitude")]
        public string Latitude
        {
            get;
            set;
        }

        [JsonProperty("longitude")]
        public string Longitude
        {
            get;
            set;
        }

        [JsonProperty("gmtoff")]
        public string GmtOffset
        {
            get;
            set;
        }         

        [JsonProperty("dstoff")]
        public string DayLightSavingOffset
        {
            get;
            set;
        }

        [JsonProperty("timezone")]
        public string Timezone
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

        [JsonProperty("region")]
        public string Region
        {
            get;
            set;
        }
    }
}
