using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MailChimp.Net.Api.Domain
{
    public sealed class Folder
    {
        [JsonProperty("folder_id")]
        public int ID { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("date_created")]
        public DateTime Created { get; set; }

        [JsonProperty("type")]
        public FolderType Type { get; set; }

        [JsonProperty("cnt")]
        public int Count { get; set; }
    }
}
