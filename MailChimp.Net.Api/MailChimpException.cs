using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using MailChimp.Net.Api.Domain;

namespace MailChimp.Net.Api
{
    [Serializable]
    public class MailChimpException : ApplicationException
    { 
        public MailChimpError MailChimpError { get; set; }

        public MailChimpException() 
		{ 
		}

        public MailChimpException(MailChimpError mailChimpError)
            : base(mailChimpError.Name)
		{ 
			MailChimpError = mailChimpError;
		}

        public static Exception TryParse(string json, Exception fallback)
        {
            try
            {
                return new MailChimpException(JsonConvert.DeserializeObject<MailChimpError>(json));
            }
            catch
            {
                return fallback;
            }
        }
    }
}
