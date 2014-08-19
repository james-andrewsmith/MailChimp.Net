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
    public sealed class MailChimpGalleryService : MailChimpService
    {

        #region // Constructors // 

        public MailChimpGalleryService(string apiKey = null, string dataCenter = null)
            : base(apiKey, dataCenter)
        {
        }

        #endregion

        #region // List //

        public MailChimpServiceResponse<List<GalleryFile>> List(string type = null, int start = 0, int limit = 25, string sortBy = "time", string sortDirection = "desc", string searchTerm = null)
        {
            return WaitForServiceResponse(ListAsync(type, start, limit, sortBy, sortDirection, searchTerm));
        }


        /// <summary>
        /// https://us2.api.mailchimp.com/2.0/helper/ping
        /// </summary>
        /// <returns></returns>
        public Task<MailChimpServiceResponse<List<GalleryFile>>> ListAsync(string type = null, int start = 0, int limit = 25, string sortBy = "time", string sortDirection = "desc", string searchTerm = null)
        {   
            // prepare URL
            var url = Urls.Gallery + "/list.json";

            // prepare & validate request
            var request = new
            {
                opts = new 
                {
                    type, 
                    start,
                    limit, 
                    sort_by = sortBy,
                    sort_dir = sortDirection,
                    search_term = searchTerm
                }
            };

            // run against APi
            return Execute<List<GalleryFile>>(url, request);
        }

        #endregion

    }
}
