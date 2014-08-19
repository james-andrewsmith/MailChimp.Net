using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MailChimp.Net.Settings;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using log4net;
using MailChimp.Net.Api.Domain;
using MailChimp.Net.Api.Helpers;

namespace MailChimp.Net.Api.Services
{
     
    public sealed class MailChimpECommerceService : MailChimpService
    {

        #region // Constructors //

        public MailChimpECommerceService(string apiKey = null, string dataCenter = null)
            : base(apiKey, dataCenter)
        {
        }

        #endregion

        #region // OrderAdd //

        public MailChimpServiceResponse OrderAdd(Order order)
        {
            return WaitForServiceResponse(OrderAddAsync(order));
        }

        public Task<MailChimpServiceResponse> OrderAddAsync(Order order)
        {
            var url = Urls.ECommerce + "/order-add.json";

            var request = new
            {
                order = order
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

        #region // Order Delete //

        public MailChimpServiceResponse OrderDelete(string storeID, string orderID)
        {
            return WaitForServiceResponse(OrderDeleteAsync(storeID, orderID));
        }

        public Task<MailChimpServiceResponse> OrderDeleteAsync(string storeID, string orderID)
        {
            var url = Urls.ECommerce + "/order-del.json";
            
            var request = new {
                store_id = storeID,
                order_id = orderID
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

        #region // Orders //

        public MailChimpServiceResponse Orders(string campaignID, int start = 0, int limit = 25, string since = null)
        {
            return WaitForServiceResponse(OrdersAsync(campaignID, start, limit, since));
        }

        /// <summary>
        /// http://apidocs.mailchimp.com/api/2.0/ecomm/orders.php
        /// </summary>
        /// <param name="campaignID"></param>
        /// <param name="start"></param>
        /// <param name="limit"></param>
        /// <param name="since"></param>
        /// <returns></returns>
        public Task<MailChimpServiceResponse> OrdersAsync(string campaignID, int start = 0, int limit = 25, string since = null)
        {
            var url = Urls.ECommerce + "/orders.json";

            var request = new
            {
                cid = campaignID,
                start = start, 
                limit = limit, 
                since = since
            };

            return Execute(url, request); 
        }

        #endregion

    }
}
