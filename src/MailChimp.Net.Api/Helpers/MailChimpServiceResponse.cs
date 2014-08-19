using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MailChimp.Net.Api.Domain
{
    public class MailChimpServiceResponse
    {
        public string RequestedUrl
        {
            get;
            set;
        }

        public string RequestedData
        {
            get;
            set;
        }

        public bool IsSuccesful 
        { 
            get; 
            set; 
        }

        public string Data
        {
            get;
            set;
        }

        public JToken Json 
        { 
            get; 
            set; 
        }

        public Exception Exception
        {
            get;
            set;
        }
    }

    public class MailChimpServiceResponse<T> : MailChimpServiceResponse
    {
        public MailChimpServiceResponse(MailChimpServiceResponse original) : this(original, null)
        {
        }

        public MailChimpServiceResponse(MailChimpServiceResponse original, string property)
        {

            base.RequestedUrl = original.RequestedUrl;
            base.RequestedData = original.RequestedData;
            base.IsSuccesful = original.IsSuccesful;
            base.Data = original.Data;
            base.Json = original.Json;
            base.Exception = original.Exception;

            if (string.IsNullOrEmpty(property))
            {
                // typeof(T).IsAssignableFrom(typeof(IList)) ? JsonConvert.De
                Value = JsonConvert.DeserializeObject<T>(base.Data);
            }
            else
            {
                Value = base.Json[property].ToObject<T>();
            }
        }

        public T Value
        {
            get;
            set;
        }
    }
}
