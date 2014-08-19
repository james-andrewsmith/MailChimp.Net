using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MailChimp.Net.Api.Domain
{
    public sealed class Subscriber
    {

        [JsonProperty("id")]
        public string ListId 
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

        [JsonProperty("email_type")]
        public string EmailType 
        { 
            get; 
            set; 
        }

        [JsonProperty("double_optin", DefaultValueHandling=DefaultValueHandling.Include)]
        public bool DoubleOptIn 
        { 
            get; 
            set; 
        }

        [JsonProperty("update_existing", DefaultValueHandling = DefaultValueHandling.Include)]
        public bool UpdateExisting 
        { 
            get; 
            set; 
        }

        [JsonProperty("replace_interests", DefaultValueHandling = DefaultValueHandling.Include)]
        public bool ReplaceInterests 
        { 
            get; 
            set; 
        }

        [JsonProperty("send_welcome", DefaultValueHandling = DefaultValueHandling.Include)]
        public bool SendWelcome 
        { 
            get; 
            set; 
        }

        [JsonProperty("merge_vars")]
        public MergeVariables MergeVars 
        { 
            get; 
            set; 
        }
 
    }
}
