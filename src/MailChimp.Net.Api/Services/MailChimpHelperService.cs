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
    public sealed class MailChimpHelperService : MailChimpService
    {
        #region // Constructors // 
        
        public MailChimpHelperService(string apiKey = null, string dataCenter = null)
            : base(apiKey, dataCenter)
        {
        }

        #endregion

        #region // Ping //

        /// <summary>
        /// https://us2.api.mailchimp.com/2.0/helper/ping
        /// </summary>
        /// <returns></returns>
        public Task<MailChimpServiceResponse> PingAsync()
        {
         
            var url = Urls.Helper + "/ping.json";

            return Execute(url, new { }).ContinueWith(t =>
            {
                if (t.Result.IsSuccesful)
                    t.Result.IsSuccesful = t.Result
                                            .Json["msg"]
                                            .ToString()
                                            .ToLowerInvariant()
                                            .Contains("everything is");

                return t.Result;
            });             
        }

        #endregion

        #region // Account Details //

        /// <summary>
        /// http://apidocs.mailchimp.com/api/2.0/helper/account-details.php
        /// </summary>
        /// <returns></returns>
        public Task<MailChimpServiceResponse<AccountDetails>> AccountDetailsAsync(List<string> exclude = null)
        {            
            var url = Urls.Helper + "/account-details.json";

            var request = new { };

            return Execute<AccountDetails>(url, request);
        }

        #endregion

        #region // Campaigns for Email //

        /// <summary>
        /// http://apidocs.mailchimp.com/api/2.0/helper/campaigns-for-email.php
        /// </summary>
        /// <returns></returns>
        public Task<MailChimpServiceResponse> CampaignsForEmailAsync(Email email, string listID = null)
        {            
            var url = Urls.Helper + "/campaigns-for-email.json";

            var request = new
            {
                email = email,
                options = new
                {
                    list_id = listID
                }
            };

            return Execute(url, request);             
        }

        #endregion

        #region // Chimp Chatter //

        /// <summary>
        /// http://apidocs.mailchimp.com/api/2.0/helper/chimp-chatter.php
        /// </summary>
        /// <returns></returns>
        public Task<MailChimpServiceResponse> ChimpChatterAsync(Email email, string listID = null)
        {
            
            var url = Urls.Helper + "/chimp-chatter.json";

            var request = new
            {
                email = email,
                options = new
                {
                    list_id = listID
                }
            };

            return Execute(url, request);

        }

        #endregion

        #region // Generate Text //

        /// <summary>
        /// http://apidocs.mailchimp.com/api/2.0/helper/generate-text.php
        /// </summary>
        /// <returns></returns>
        public Task<MailChimpServiceResponse> GenerateTextAsync(string type, string html, string campaignID, string userTemplateID, string baseTemplateID, string galleryTemplateID, string sourceUrl)
        {
            // get the url
            var url = Urls.Helper + "/generate-text.json";

            // prepare request
            var request = new
            {
                type = type,
                content = new
                {
                    html = html, 
                    cid = campaignID, 
                    user_template_id = userTemplateID, 
                    base_template_id = baseTemplateID,
                    gallery_template_id = galleryTemplateID,
                    url = url
                }
            };

            return Execute(url, request);
        }

        #endregion

        #region // Inline CSS //

        /// <summary>
        /// http://apidocs.mailchimp.com/api/2.0/helper/inline-css.php
        /// </summary>
        /// <returns></returns>
        public Task<MailChimpServiceResponse> InlineCssAsync(string html, bool stripCss = false)
        {            
            var url = Urls.Helper + "/inline-css.json";

            var request = new
            {
                html = html,
                strip_css = stripCss
            };

            return Execute(url, request);             
        }

        #endregion

        #region // Lists for Email //

        /// <summary>
        /// http://apidocs.mailchimp.com/api/2.0/helper/lists-for-email.php
        /// </summary>
        /// <returns></returns>
        public Task<MailChimpServiceResponse> ListsForEmailAsync(Email email)
        {           

            var url = Urls.Helper + "/lists-for-email.json";

            var request = new
            {
                email = email
            };

            return Execute(url, request);

        }

        #endregion

        #region // Search Campaigns //

        /// <summary>
        /// http://apidocs.mailchimp.com/api/2.0/helper/search-campaigns.php
        /// </summary>
        /// <returns></returns>
        public Task<MailChimpServiceResponse<List<Campaign>>> SearchCampaignsAsync(string query, int offset, string snipStart, string snipEnd)
        {
            
            var url = Urls.Helper + "/search-campaigns.json";
            
            var request = new
            {
                query = query, 
                offset = offset, 
                snip_start = snipStart, 
                snip_end = snipEnd
            };

            return Execute<List<Campaign>>(url, request);
        }

        #endregion

        #region // Search Members //

        /// <summary>
        /// http://apidocs.mailchimp.com/api/2.0/helper/search-members.php
        /// </summary>
        /// <returns></returns>
        public Task<MailChimpServiceResponse> SearchMembersAsync(string query, string id = null, int offset = 0)
        {            
            var url = Urls.Helper + "/search-members.json";

            var request = new
            {
                query = query,
                id = id,
                offset = offset                
            };

            return Execute(url, request);
        }

        #endregion

        #region // Verified Domains //

        /// <summary>
        /// http://apidocs.mailchimp.com/api/2.0/helper/verified-domains.php
        /// </summary>
        /// <returns></returns>
        public Task<MailChimpServiceResponse> VerifiedDomainsAsync(string query, string id = null, int offset = 0)
        {
            var url = Urls.Helper + "/verified-domains.json";

            var request = new {};

            return Execute(url, request);
        }

        #endregion
    }
}
