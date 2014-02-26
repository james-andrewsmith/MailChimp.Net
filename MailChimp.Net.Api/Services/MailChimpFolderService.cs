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
    public sealed class MailChimpFolderService : MailChimpService
    {
        #region // Constructors // 
        
        public MailChimpFolderService(string apiKey = null, string dataCenter = null)
            : base(apiKey, dataCenter)
        {
        }
        
        #endregion

        #region // Add //

        /// <summary>
        /// http://apidocs.mailchimp.com/api/2.0/folders/add.php
        /// </summary>
        /// <returns></returns>
        public ServiceResponse Add(string name, FolderType type)
        {
            return WaitForServiceResponse(AddAsync(name, type));
        }

        /// <summary>
        /// http://apidocs.mailchimp.com/api/2.0/folders/add.php
        /// </summary>
        /// <returns></returns>
        public Task<ServiceResponse> AddAsync(string name, FolderType type)
        {
            var url = Urls.Folder + "/add.json";

            var request = new
            {
                name = name, 
                type = Enum.GetName(typeof(FolderType), type).ToLowerInvariant()
            };

            return Execute(url, request).ContinueWith(t =>
            {
                // add an extra level of validation 
                if (t.Result.IsSuccesful)
                    t.Result.IsSuccesful = t.Result.Json["complete"]
                                                   .ToObject<bool>();

                return t.Result;
            }); 
        }

        #endregion

        #region // Delete //

        /// <summary>
        /// http://apidocs.mailchimp.com/api/2.0/folders/del.php
        /// </summary>
        /// <returns></returns>
        public Task<ServiceResponse> Delete(string name, int id, FolderType type)
        {
            var url = Urls.Folder + "/del.json";

            var request = new
            {
                fid = id,
                type = type
            };

            return Execute(url, request);
        }

        #endregion

        #region // List //

        /// <summary>
        /// http://apidocs.mailchimp.com/api/2.0/folders/list.php
        /// </summary>
        /// <returns></returns>
        public Task<ServiceResponse<List<Folder>>> ListAsync(FolderType type)
        {
            var url = Urls.Folder + "/list.json";

            var request = new
            {
                type = type
            };

            return Execute<List<Folder>>(url, request);
        }

        #endregion

        #region // Update //

        public ServiceResponse Update(int id, string name, FolderType type)
        {
            return WaitForServiceResponse(UpdateAsync(id, name, type));
        }

        /// <summary>
        /// http://apidocs.mailchimp.com/api/2.0/folders/update.php
        /// </summary>
        /// <returns></returns>
        public Task<ServiceResponse> UpdateAsync(int id, string name, FolderType type)
        {
            var url = Urls.Folder + "/update.json";

            var request = new
            {
                fid = id, 
                name,
                type
            };

            return Execute(url, request);
        }

        #endregion
    }
}
