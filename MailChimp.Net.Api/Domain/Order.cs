using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MailChimp.Net.Api.Domain
{

    public sealed class Order
    {
        [JsonProperty("id")]
        public string ID { get; set; }

        [JsonProperty("campaign_id")]
        public string CampaignID { get; set; }

        [JsonProperty("email_id")]
        public string EmailID { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("total")]
        public double Total { get; set; }

        [JsonProperty("order_date")]
        public string OrderDate { get; set; }

        [JsonProperty("shipping")]
        public double Shipping { get; set; }

        [JsonProperty("tax")]
        public double Tax { get; set; }

        [JsonProperty("store_id")]
        public string StoreID { get; set; }

        [JsonProperty("store_name")]
        public string StoreName { get; set; }

        [JsonProperty("items")]
        public List<OrderItem> items { get; set; }        

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
