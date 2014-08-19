using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Threading.Tasks;

using log4net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using MailChimp.Net.Settings;
using MailChimp.Net.Api.Domain;
using MailChimp.Net.Api.Helpers;

namespace MailChimp.Net.Api.Services
{
    public abstract class MailChimpService
    {

        #region // Constructors //

        public MailChimpService(string apiKey = null, string dataCenter = null)
        {
            if (string.IsNullOrEmpty(apiKey))
                apiKey = MailChimpServiceConfiguration.Settings.ApiKey;

            if (string.IsNullOrEmpty(dataCenter))
                dataCenter = MailChimpServiceConfiguration.Settings.DataCenter;

            _apiKey = apiKey;
            _dataCenter = dataCenter;
        }

        #endregion

        #region // Properties //

        protected readonly ILog _log = LogManager.GetLogger("MailChimpApiService");
        protected readonly string _dataCenter;
        protected readonly string _apiKey;

        #endregion

        #region // Async to Sync Helper //

        protected static MailChimpServiceResponse WaitForServiceResponse(Task<MailChimpServiceResponse> t)
        {
            Task.WaitAll(t);
            var response = t.Result;
            if (t.Result.Exception != null) throw t.Result.Exception;
            return t.Result;
        }

        protected static MailChimpServiceResponse<T> WaitForServiceResponse<T>(Task<MailChimpServiceResponse<T>> t)
        {
            Task.WaitAll(t);
            var response = t.Result;
            if (t.Result.Exception != null) throw t.Result.Exception;
            return t.Result;
        }

        #endregion

        #region // Execute //

        protected Task<MailChimpServiceResponse<T>> Execute<T>(string url, object request)
        {
            return Execute(url, request).ContinueWith(t =>
            {
                return new MailChimpServiceResponse<T>(t.Result);
            });            
        }

        protected Task<MailChimpServiceResponse<T>> Execute<T>(string url)
        {
            return Execute(url).ContinueWith(t =>
            {
                return new MailChimpServiceResponse<T>(t.Result);
            }); 
        }

        protected Task<MailChimpServiceResponse<T>> Execute<T>(string url, string request)
        {
            return Execute(url, request).ContinueWith(t =>
            {
                return new MailChimpServiceResponse<T>(t.Result);
            });            
        }

        protected Task<MailChimpServiceResponse> Execute(string url, object request)
        {
            return Execute(url, JsonConvert.SerializeObject(request, Formatting.None, _settings));
        }

        protected Task<MailChimpServiceResponse> Execute(string url)
        {
            return Execute(url, "{}");
        }


        private readonly static JsonSerializerSettings _settings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            DefaultValueHandling = DefaultValueHandling.Ignore 
        };

        protected static object NullWhenEmpty(object json)
        {
            return "{}" == JsonConvert.SerializeObject(json, _settings) ? null : json;
        }

        protected Task<MailChimpServiceResponse> Execute(string url, string request)
        {
            // get the return object and the URL 
            var response = new MailChimpServiceResponse();
            response.RequestedUrl = "https://" + _dataCenter + ".api.mailchimp.com/2.0" + url;

            // parse the json to ensure it's valid, also add the API
            // key which is required for every call
            var json = JObject.Parse(request);
            json["apikey"] = _apiKey;
            response.RequestedData = json.ToString();


            Func<Task<byte[]>, MailChimpServiceResponse> continueWith = t =>
            {                 
                try
                {
                    if (t.IsFaulted)
                    {
                        var exception = t.Exception.Flatten().GetBaseException();
                        response.Exception = exception;

                        if (exception is WebException)
                        {
                            var we = (WebException)exception;
                            try 
                            {
                                using (var stream = we.Response.GetResponseStream()) 
                                using (var reader = new StreamReader(stream)) 
                                { 
                                    response.Data = reader.ReadToEnd();
                                    response.Exception = MailChimpException.TryParse(response.Data, exception);
                                }                                
                            } 
                            catch 
                            {
                                // Oh, well, we tried
                            }

                            // try to turn this into a VendException, otherwise fallback to current
                            // exception with the response stream
                            _log.DebugFormat("MailChimpService Call {0} : {1}, response json : {2}", url, request, response.Data);
                        }
                        _log.Error(exception);
                        return response;
                    }

                    response.IsSuccesful = true;
                    response.Data = Encoding.UTF8.GetString(t.Result);
                    response.Json = JToken.Parse(response.Data);

                    if (response.Json.Type == JTokenType.Object &&
                        response.Json["status"] != null &&
                        response.Json["status"].ToString() == "error")
                    {
                        response.IsSuccesful = false;
                        response.Exception = new MailChimpException(JsonConvert.DeserializeObject<MailChimpError>(response.Data));
                    }
                     
                }
                catch (Exception exception)
                {                    
                    _log.Error(exception);
                    response.IsSuccesful = false;
                    response.Exception = exception;
                }
                finally
                {
                    
                    _log.DebugFormat("MailChimpService Call {0} : {1}, response json : {2}", url, request, response.Data);                                 
                }

                return response;
            };


            using (var client = new WebClient())
            { 
                 
                var bytes = Encoding.UTF8.GetBytes(response.RequestedData);
                client.Headers.Add("Content-Type", "application/json");

                return client.UploadDataTaskAsync(response.RequestedUrl, bytes)
                             .ContinueWith(continueWith);
                         
            }          
        }


        #endregion 

    }
}
