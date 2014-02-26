using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using MailChimp.Net.Settings;
using MailChimp.Net.Api.Domain;
using MailChimp.Net.Api.Helpers;

namespace MailChimp.Net.Api.Services
{
    public sealed class MailChimpCampaignService : MailChimpService
    {

        #region // Constructors // 
        
        public MailChimpCampaignService(string apiKey = null, string dataCenter = null)
            : base(apiKey, dataCenter)
        {
        }

        #endregion

        #region // Content //

        /// <summary>
        /// http://apidocs.mailchimp.com/api/2.0/campaigns/content.php
        /// </summary>
        /// <returns></returns>
        public Task<ServiceResponse> ContentAsync(string campaignID, ContentOption option)
        {
            var url = Urls.Campaign + "content.json";

            var request = new
            {
                cid = campaignID,
                options = option
            };

            return Execute(url, request); 
        }

        #endregion

        #region // Create //

        /// <summary>
        /// http://apidocs.mailchimp.com/api/2.0/campaigns/create.php
        /// </summary>
        /// <returns></returns>
        public Task<ServiceResponse> CreateAsync(CampaignType type, ContentOption contentOption)
        {
            var url = Urls.Campaign + "create.json";

            var request = new
            {
                type = type,
                // options = option,
                content = contentOption,
                // segment_opts = segmentOptions,
                // type_opts = typeOptions,
                // auto = autoReponders
            };

            return Execute(url, request); 
        }

        #endregion

        #region // Delete //

        /// <summary>
        /// http://apidocs.mailchimp.com/api/2.0/campaigns/delete.php
        /// </summary>
        /// <returns></returns>
        public Task<ServiceResponse> DeleteAsync(string campaignID)
        {
            var url = Urls.Campaign + "delete.json";            

            var request = new 
            { 
                cid = campaignID
            };

            return Execute(url, request); 
        }

        #endregion

        #region // List //

        public ServiceResponse List(CampaignFilter filter, int start = 0, int limit = 25, string sortField = "", string sortDirection = "")
        {
            return WaitForServiceResponse(ListAsync(filter, start, limit, sortField, sortDirection));
        }

        /// <summary>
        /// http://apidocs.mailchimp.com/api/2.0/campaigns/list.php
        /// </summary>
        /// <returns></returns>
        public Task<ServiceResponse> ListAsync(CampaignFilter filter, int start = 0, int limit = 25, string sortField = "", string sortDirection = "")
        {
            var url = Urls.Campaign + "list.json";            

            var request = new { 
                filters = filter, 
                start,
                limit,
                sort_field = sortField,
                sort_dir = sortDirection
            };

            return Execute(url, request); 
        }

        #endregion

        #region // Pause //

        /// <summary>
        /// http://apidocs.mailchimp.com/api/2.0/campaigns/pause.php
        /// </summary>
        /// <returns></returns>
        public Task<ServiceResponse> PauseAsync(string campaignID)
        {
            var url = Urls.Campaign + "pause.json";            

            var request = new { 
                cid = campaignID
            };

            return Execute(url, request); 
        }

        #endregion
        
        #region // Ready //

        /// <summary>
        /// http://apidocs.mailchimp.com/api/2.0/campaigns/ready.php
        /// </summary>
        /// <returns></returns>
        public Task<ServiceResponse> ReadyAsync(string campaignID)
        {
            var url = Urls.Campaign + "ready.json";            

            var request = new { 
                cid = campaignID
            };
            
            return Execute(url, request); 
        }

        #endregion
        
        #region // Replicate //

        /// <summary>
        /// http://apidocs.mailchimp.com/api/2.0/campaigns/replicate.php
        /// </summary>
        /// <returns></returns>
        public Task<ServiceResponse> ReplicateAsync(string campaignID)
        {
            var url = Urls.Campaign + "pause.json";            

            var request = new {
                cid = campaignID
            };

            return Execute(url, request); 
        }

        #endregion
        
        #region // Resume //

        /// <summary>
        /// http://apidocs.mailchimp.com/api/2.0/campaigns/resume.php
        /// </summary>
        /// <returns></returns>
        public Task<ServiceResponse> ResumeAsync(string campaignId)
        {
            var url = Urls.Campaign + "resume.json";            

            var request = new { 
                cid = campaignId
            };

            return Execute(url, request); 
        }

        #endregion
        
        #region // Schedule Batch //

        /// <summary>
        /// http://apidocs.mailchimp.com/api/2.0/campaigns/schedule-batch.php
        /// </summary>
        /// <returns></returns>
        public Task<ServiceResponse> ScheduleBatchAsync(string campaignID)
        {
            var url = Urls.Campaign + "schedule-batch.json";            

            var request = new { 
                cid = campaignID
            };

            return Execute(url, request); 
        }

        #endregion
         
        #region // Segment Test //

        /// <summary>
        /// http://apidocs.mailchimp.com/api/2.0/campaigns/segment-test.php
        /// </summary>
        /// <returns></returns>
        public Task<ServiceResponse> SegmentTestAsync(string campaignId)
        {
            var url = Urls.Campaign + "pause.json";            

            var request = new {
                apikey = _apiKey,
                cid = campaignId
            };

            return Execute(url, request); 
        }

        #endregion
        
        #region // Send //

        /// <summary>
        /// http://apidocs.mailchimp.com/api/2.0/campaigns/send.php
        /// </summary>
        /// <returns></returns>
        public Task<ServiceResponse> SendAsync(string campaignID)
        {
            var url = Urls.Campaign + "send.json";            

            var request = new { 
                cid = campaignID
            };

            return Execute(url, request); 
        }

        #endregion

        #region // Send Test //

        /// <summary>
        /// http://apidocs.mailchimp.com/api/2.0/campaigns/send-test.php
        /// </summary>
        /// <returns></returns>
        public Task<ServiceResponse> SendTestAsync(string campaignID, List<string> testEmails = null, Nullable<EmailType> sendType = null)
        {
            var url = Urls.Campaign + "send-test.json";            

            var request = new { 
                cid = campaignID
            };

            return Execute(url, request); 
        }

        #endregion

        #region // Template Content //

        /// <summary>
        /// http://apidocs.mailchimp.com/api/2.0/campaigns/template-content.php
        /// </summary>
        /// <returns></returns>
        public Task<ServiceResponse> TemplateContentAsync(string campaignId)
        {            
            var url = Urls.Campaign + "template-content.json";            

            var request = new {
                cid = campaignId
            };

            return Execute(url, request);
        }

        #endregion
        
        #region // Unschedule //

        /// <summary>
        /// http://apidocs.mailchimp.com/api/2.0/campaigns/unschedule.php
        /// </summary>
        /// <returns></returns>
        public Task<ServiceResponse> UnscheduleAsync(string campaignID)
        {            
            // get the url
            var url = Urls.Campaign + "unschedule.json";            

            // prepare the request
            var request = new 
            {
                cid = campaignID
            };

            // return task 
            return Execute(url, request);             
        }

        #endregion
        
        #region // Update //

        /// <summary>
        /// http://apidocs.mailchimp.com/api/2.0/campaigns/update.php
        /// </summary>
        /// <returns></returns>
        public ServiceResponse Update(string campaignID, string name, List<string> value)
        {
            return WaitForServiceResponse(UpdateAsync(campaignID, name, value));
        }

        /// <summary>
        /// http://apidocs.mailchimp.com/api/2.0/campaigns/update.php
        /// </summary>
        /// <returns></returns>
        public Task<ServiceResponse> UpdateAsync(string campaignID, string name, List<string> value)
        {
            // get the url
            var url = Urls.Campaign + "update.json";            

            // format in a request
            var request = new 
            {
                cid = campaignID
            };

            // get task
            return Execute(url, request);
        }

        #endregion
        
    }
}
