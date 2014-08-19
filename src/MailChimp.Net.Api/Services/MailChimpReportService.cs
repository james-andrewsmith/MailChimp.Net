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
    public sealed class MailChimpReportService : MailChimpService
    {

        #region // Constructors // 

        public MailChimpReportService(string apiKey = null, string dataCenter = null)
            : base(apiKey, dataCenter)
        {
        }
        
        #endregion

        #region // Abuse //
        
        /// <summary>
        /// https://us2.api.mailchimp.com/2.0/helper/ping
        /// </summary>
        /// <returns></returns>
        public MailChimpServiceResponse Abuse(string campaignID, int start = 0, int limit = 100, string since = null)
        {
            return WaitForServiceResponse(AbuseAsync(campaignID, start, limit, since));
        }

        /// <summary>
        /// https://us2.api.mailchimp.com/2.0/helper/ping
        /// </summary>
        /// <returns></returns>
        public Task<MailChimpServiceResponse> AbuseAsync(string campaignID, int start = 0, int limit = 100, string since = null)
        {

            var url = Urls.Report + "/abuse.json";

            var request = new
            {
                cid = campaignID,
                opts = new
                {
                    start = start, 
                    limit = limit, 
                    since = since
                }
            };

            return Execute(url, request);

        }

        #endregion

        #region // Advice //

        /// <summary>
        /// http://apidocs.mailchimp.com/api/2.0/reports/advice.php
        /// </summary>
        /// <returns></returns>
        public MailChimpServiceResponse Advice(string campaignID, int start = 0, int limit = 25, string since = null)
        {
            return WaitForServiceResponse(AdviceAsync(campaignID, start, limit, since));
        }

        /// <summary>
        /// http://apidocs.mailchimp.com/api/2.0/reports/advice.php
        /// </summary>
        /// <returns></returns>
        public Task<MailChimpServiceResponse> AdviceAsync(string campaignID, int start = 0, int limit = 100, string since = null)
        {
            
            var url = Urls.Report + "/advice.json";

            var request = new
            {
                cid = campaignID                
            };

            return Execute(url, request);

        }

        #endregion

        #region // Bounce Message //

        /// <summary>
        /// http://apidocs.mailchimp.com/api/2.0/reports/bounce-message.php
        /// </summary>
        /// <returns></returns>
        public Task<MailChimpServiceResponse> BounceMessageAsync(string campaignID, Email email)
        {
            
            var url = Urls.Report + "/bounce-message.json";

            var request = new
            {
                cid = campaignID,
                email = email
            };

            return Execute(url, request);

        }

        #endregion

        #region // Click Detail //

        /// <summary>
        /// http://apidocs.mailchimp.com/api/2.0/reports/click-detail.php
        /// </summary>
        /// <returns></returns>
        public Task<MailChimpServiceResponse> ClickDetailAsync(string campaignID, int tid, int start = 0, int limit = 100, string sortField = "clicks", string sortDirection = "asc")
        {
            
            var url = Urls.Report + "/click-detail.json";
            
            var request = new
            {
                apikey = _apiKey,
                cid = campaignID,
                tid = tid,
                opts = new {
                    start = start, 
                    limit = limit, 
                    sort_field = sortField,
                    sort_dir = sortDirection
                }
            };

            return Execute(url, request);
        }

        #endregion


        #region // Clicks //

        /// <summary>
        /// http://apidocs.mailchimp.com/api/2.0/reports/click-detail.php
        /// </summary>
        /// <returns></returns>
        public Task<MailChimpServiceResponse> ClicksAsync(string campaignID)
        {
            
            var url = Urls.Report + "/clicks.json";

            var request = new
            {
                apikey = _apiKey,
                cid = campaignID 
            };

            return Execute(url, request);
        }

        #endregion

        #region // Domain Performance //

        /// <summary>
        /// http://apidocs.mailchimp.com/api/2.0/reports/domain-performance.php
        /// </summary>
        /// <returns></returns>
        public Task<MailChimpServiceResponse> DomainPerformanceAsync(string campaignID)
        {
            
            var url = Urls.Report + "/domain-performance.json";
            
            var request = new
            {
                cid = campaignID
            };

            return Execute(url, request);
        }

        #endregion

        #region // ECommerce Orders //

        /// <summary>
        /// http://apidocs.mailchimp.com/api/2.0/reports/ecomm-orders.php
        /// </summary>
        /// <returns></returns>
        public Task<MailChimpServiceResponse> ECommerceOrdersAsync(string campaignID, int start = 0, int limit = 100, string since = null)
        {
            
            var url = Urls.Report + "/ecomm-orders.json";
            
            var request = new
            {
                cid = campaignID,
                opts = new
                {
                    start = start, 
                    limit = limit, 
                    since = since
                }
            };

            return Execute(url, request);             
        }

        #endregion

        #region // EEP Orders //

        /// <summary>
        /// http://apidocs.mailchimp.com/api/2.0/reports/eepurl.php
        /// </summary>
        /// <returns></returns>
        public Task<MailChimpServiceResponse> EepUrlAsync(string campaignID)
        {
            
            var url = Urls.Report + "/eepurl.json";
            
            var request = new
            {
                cid = campaignID
            };

            return Execute(url, request);

        }

        #endregion


        #region // Geo Opens //

        /// <summary>
        /// http://apidocs.mailchimp.com/api/2.0/reports/geo-opens.php
        /// </summary>
        /// <returns></returns>
        public Task<MailChimpServiceResponse> GeoOpensAsync(string campaignID)
        {
            
            var url = Urls.Report + "/geo-opens.json";
            
            var request = new
            {
                cid = campaignID
            };

            return Execute(url, request);

        }

        #endregion

        #region // Google Analytics //

        /// <summary>
        /// http://apidocs.mailchimp.com/api/2.0/reports/google-analytics.php
        /// </summary>
        /// <returns></returns>
        public Task<MailChimpServiceResponse> GoogleAnalyticsAsync(string campaignID)
        {
            
            var url = Urls.Report + "/google-analytics.json";
            
            var request = new
            {
                cid = campaignID
            };

            return Execute(url, request); 

        }

        #endregion

        #region // Member Activity //

        /// <summary>
        /// http://apidocs.mailchimp.com/api/2.0/reports/member-activity.php
        /// </summary>
        /// <returns></returns>
        public Task<MailChimpServiceResponse> MemberActivityAsync(string campaignID, List<Email> emails)
        {
            
            var url = Urls.Report + "/member-activity.json";
            
            var request = new
            {
                cid = campaignID,
                emails = emails
            };

            return Execute(url, request);
        }

        #endregion

        #region // Not Opened //

        /// <summary>
        /// http://apidocs.mailchimp.com/api/2.0/reports/not-opened.php
        /// </summary>
        /// <returns></returns>
        public Task<MailChimpServiceResponse> NotOpenedAsync(string campaignID, int start = 0, int limit = 100)
        {

            var url = Urls.Report + "/member-activity.json";

            var request = new
            {
                cid = campaignID,
                opts = new
                {
                    start = start,
                    limit = limit
                }
            };

            return Execute(url, request);
        }

        #endregion         

        #region // Opened //

        /// <summary>
        /// http://apidocs.mailchimp.com/api/2.0/reports/opened.php
        /// </summary>
        /// <returns></returns>
        public Task<MailChimpServiceResponse> OpenedAsync(string campaignID, int start = 0, int limit = 100, string sortField = "opened", string sortDirection = "asc")
        {
            
            var url = Urls.Report + "/opened.json";
            
            var request = new
            {
                cid = campaignID,
                opts = new
                {
                    start = start,
                    limit = limit,
                    sort_field = sortField,
                    sort_dir = sortDirection
                }
            };

            return Execute(url, request);
        }

        #endregion

        #region // Sent To //

        /// <summary>
        /// http://apidocs.mailchimp.com/api/2.0/reports/sent-to.php
        /// </summary>
        /// <returns></returns>
        public Task<MailChimpServiceResponse> SentToAsync(string campaignID, string status = null, int start = 0, int limit = 100)
        {
            
            var url = Urls.Report + "/sent-to.json";
            
            var request = new
            {
                cid = campaignID,
                opts = new
                {
                    status = status,
                    start = start,
                    limit = limit
                }
            };

            return Execute(url, request);
        }

        #endregion

        #region // Share //

        /// <summary>
        /// http://apidocs.mailchimp.com/api/2.0/reports/share.php
        /// </summary>
        /// <returns></returns>
        public Task<MailChimpServiceResponse> ShareAsync(string campaignID, List<string> toEmail = null, int themeID = 0, string cssUrl = null)
        {
         
            var url = Urls.Report + "/share.json";
         
            var request = new
            {
                cid = campaignID,
                opts = new
                {
                    to_email = toEmail,
                    theme_id = themeID,
                    css_url = cssUrl
                }
            };

            return Execute(url, request);

        }

        #endregion

        #region // Summary //

        /// <summary>
        /// http://apidocs.mailchimp.com/api/2.0/reports/summary.php
        /// </summary>
        /// <returns></returns>
        public Task<MailChimpServiceResponse> SummaryAsync(string campaignID)
        {            
            var url = Urls.Report + "/summary.json";
            
            var request = new
            {
                cid = campaignID
            };

            return Execute(url, request); 
        }

        #endregion

        #region // Unsubscribes //

        /// <summary>
        /// http://apidocs.mailchimp.com/api/2.0/reports/unsubscribes.php
        /// </summary>
        /// <returns></returns>
        public Task<MailChimpServiceResponse> UnsubscribesAsync(string campaignID, int start = 0, int limit = 25)
        {            
            var url = Urls.Report + "/unsubscribes.json";
            
            var request = new
            {
                cid = campaignID,
                opts = new
                {
                    start = start, 
                    limit = limit
                }
            };

            return Execute(url, request);
        }

        #endregion
    }
}
