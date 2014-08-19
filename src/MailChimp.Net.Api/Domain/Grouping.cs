using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MailChimp.Net.Api.Domain
{
    public sealed class InterestGroup
    {
        public InterestGroup()
        {
            this.Groups = new List<Group>();
        }

        [JsonProperty("ID")]
        public int ID { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("form_field")]
        public string FormField { get; set; }

        [JsonProperty("groups")]
        public List<Group> Groups { get; set; }
    }

    public sealed class Group
    {

        [JsonProperty("bit")]
        public string Bit { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("display_order")]
        public string DisplayOrder { get; set; }

        [JsonProperty("subscribers")]
        public int? Subscribers { get; set; }

    }
}
