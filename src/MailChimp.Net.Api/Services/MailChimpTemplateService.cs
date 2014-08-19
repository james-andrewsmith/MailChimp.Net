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
    public sealed class MailChimpTemplateService : MailChimpService
    {
        #region // Constructors //          

        public MailChimpTemplateService(string apiKey = null, string dataCenter = null)
            : base(apiKey, dataCenter)
        {
        }

        #endregion

        #region // Add //

        /// <summary>
        /// http://apidocs.mailchimp.com/api/2.0/templates/add.php
        /// </summary>
        /// <returns></returns>
        public Task<MailChimpServiceResponse> AddAsync(string name, string html, int folderID = 0)
        {
            var url = Urls.Template + "/add.json";

            var request = new
            {
                name = name,
                html = html,
                fid = folderID
            };

            return Execute(url, request); 
        }

        #endregion

        #region // Delete //

        /// <summary>
        /// http://apidocs.mailchimp.com/api/2.0/templates/del.php
        /// </summary>
        /// <returns></returns>
        public Task<MailChimpServiceResponse> DeleteAsync(int templateID)
        {
            var url = Urls.Template + "/del.json";

            var request = new { tid = templateID };

            return Execute(url, request);
        }

        #endregion

        #region // Delete //

        /// <summary>
        /// http://apidocs.mailchimp.com/api/2.0/templates/info.php
        /// </summary>
        /// <returns></returns>
        public Task<MailChimpServiceResponse> InfoAsync(int templateID, string type = null)
        {
            
            var url = Urls.Template + "/info.json";

            var request = new
            {
                tid = templateID,
                type = type
            };

            return Execute(url, request); 
        }

        #endregion

        #region // List //

        /// <summary>
        /// http://apidocs.mailchimp.com/api/2.0/templates/list.php
        /// </summary>
        /// <returns></returns>
        public Task<MailChimpServiceResponse> ListAsync(bool custom, bool gallery, bool basic, string category = null, string folderID = null, bool includeInactive = false, bool inactiveOnly = false)
        {
            var url = Urls.Template + "/info.json";

            var request = new 
            {
                custom = custom
            };

            return Execute(url, request);
        }

        #endregion
        
        #region // UnDelete //

        /// <summary>
        /// http://apidocs.mailchimp.com/api/2.0/templates/undel.php
        /// </summary>
        /// <returns></returns>
        public Task<MailChimpServiceResponse> UnDeleteAsync(int templateID)
        {
            var url = Urls.Template + "/undel.json";

            var request = new
            {
                tid = templateID
            };

            return Execute(url, request);
        }

        #endregion

        #region // UnDelete //

        /// <summary>
        /// http://apidocs.mailchimp.com/api/2.0/templates/update.php
        /// </summary>
        /// <returns></returns>
        public Task<MailChimpServiceResponse> UpdateAsync(int templateID)
        {
            var url = Urls.Template + "/update.json";

            var request = new
            {
                tid = templateID
            };

            return Execute(url, request);
        }

        #endregion
    }
}
