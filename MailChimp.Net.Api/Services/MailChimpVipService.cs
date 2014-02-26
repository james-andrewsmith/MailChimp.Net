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
    public sealed class MailChimpVipService : MailChimpService
    {
        #region // Constructors // 
         
        public MailChimpVipService(string apiKey = null, string dataCenter = null)
            : base(apiKey, dataCenter)
        {
        } 

        #endregion

        #region // Activity //

        /// <summary>
        /// http://apidocs.mailchimp.com/api/2.0/vip/activity.php
        /// </summary>
        /// <returns></returns>
        public Task<ServiceResponse<List<Activity>>> ActivityAsync()
        {
            var url = Urls.Vip + "/activity.json";
            return Execute<List<Activity>>(url);
        }

        #endregion

        #region // Add //

        /// <summary>
        /// http://apidocs.mailchimp.com/api/2.0/vip/add.php
        /// </summary>
        /// <returns></returns>
        public Task<ServiceResponse> AddAsync(string id, List<Email> emails)
        {
            var url = Urls.Vip + "/add.json";

            var request = new
            {
                id,
                emails
            };

            return Execute(url, request);
        }

        #endregion
        
        #region // Delete //

        /// <summary>
        /// http://apidocs.mailchimp.com/api/2.0/vip/add.php
        /// </summary>
        /// <returns></returns>
        public Task<ServiceResponse> DeleteAsync(string id, List<Email> emails)
        {
            var url = Urls.Vip + "/delete.json";

            var request = new
            {
                id, 
                emails
            };

            return Execute(url, request);
        }

        #endregion

        #region // Members //

        /// <summary>
        /// http://apidocs.mailchimp.com/api/2.0/vip/members.php
        /// </summary>
        /// <returns></returns>
        public Task<ServiceResponse<List<Vip>>> MembersAsync(string id, List<Email> emails)
        {
            var url = Urls.Vip + "/members.json";
            return Execute<List<Vip>>(url);
        }

        #endregion
    }
}
