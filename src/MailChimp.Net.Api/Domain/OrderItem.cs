using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MailChimp.Net.Api.Domain
{

    public class OrderItem
    {
        [JsonProperty("line_num")]
        public int LineNumber { get; set; }

        [JsonProperty("product_id")]
        public int ProductID { get; set; }

        [JsonProperty("sku")]
        public string SKU { get; set; }

        [JsonProperty("product_name")]
        public string ProductName { get; set; }

        [JsonProperty("category_id")]
        public int CategoryID { get; set; }

        [JsonProperty("category_name")]
        public string CategoryName { get; set; }

        [JsonProperty("qty")]
        public int Quantity { get; set; }

        [JsonProperty("cost")]
        public double Cost { get; set; }
           
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
