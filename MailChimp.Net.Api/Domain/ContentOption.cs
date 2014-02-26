using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace MailChimp.Net.Api.Domain
{
    public sealed class ContentOption
    {

        [JsonProperty("view")]
        public string View
        {
            get;
            set;
        }

        [JsonProperty("email")]
        public Email Email
        {
            get;
            set;
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
