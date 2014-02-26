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
                apiKey = MailChimpServiceConfiguration.Settings.DataCenter;

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

        protected static ServiceResponse WaitForServiceResponse(Task<ServiceResponse> t)
        {
            Task.WaitAll(t);
            var response = t.Result;
            if (t.Result.Exception != null) throw t.Result.Exception;
            return t.Result;
        }

        protected static ServiceResponse<T> WaitForServiceResponse<T>(Task<ServiceResponse<T>> t)
        {
            Task.WaitAll(t);
            var response = t.Result;
            if (t.Result.Exception != null) throw t.Result.Exception;
            return t.Result;
        }

        #endregion

        #region // Execute //

        protected Task<ServiceResponse<T>> Execute<T>(string url, object request)
        {
            return Execute(url, request).ContinueWith(t =>
            {
                return new ServiceResponse<T>(t.Result);
            });            
        }

        protected Task<ServiceResponse<T>> Execute<T>(string url)
        {
            return Execute(url).ContinueWith(t =>
            {
                return new ServiceResponse<T>(t.Result);
            }); 
        }

        protected Task<ServiceResponse<T>> Execute<T>(string url, string request)
        {
            return Execute(url, request).ContinueWith(t =>
            {
                return new ServiceResponse<T>(t.Result);
            });            
        }

        protected Task<ServiceResponse> Execute(string url, object request)
        {
            return Execute(url, JsonConvert.SerializeObject(request));
        }

        protected Task<ServiceResponse> Execute(string url)
        {
            return Execute(url, "{}");
        }

        protected Task<ServiceResponse> Execute(string url, string request)
        {
            // get the return object and the URL 
            var response = new ServiceResponse();
            response.RequestedUrl = "https://" + _dataCenter + url;

            // parse the json to ensure it's valid, also add the API
            // key which is required for every call
            var json = JObject.Parse(request);
            json.AddFirst(JToken.Parse("\"apikey\": \"" + _apiKey + "\""));            
            response.RequestedData = json.ToString();

            var bytes = Encoding.UTF8.GetBytes(response.RequestedData);
               
            using (var client = new WebClient())
            {
                client.Headers.Add("Content-Type", "application/json");
                return client.UploadDataTaskAsync(url, bytes)
                             .ContinueWith(t =>
                             {
                                 try
                                 {
                             
                                     response.Data = Encoding.UTF8.GetString(client.UploadData(response.RequestedUrl, bytes));
                                 }
                                 catch (WebException exception)
                                 {
                                     using (Stream stream = exception.Response.GetResponseStream())
                                     using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                                     {
                                         response.Data = reader.ReadToEnd();
                                     }
                                     _log.Error(exception);
                                     response.IsSuccesful = false;
                             
                                     // try to turn this into a MailChimpException, otherwise fallback to current
                                     // exception with the response stream
                                     response.Exception = MailChimpException.TryParse(response.Data, exception);
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
                                     response.Json = JObject.Parse(response.Data);
                                 }
                             
                                 return response;
                             });

                }          
        }


        #endregion 

    }
}
