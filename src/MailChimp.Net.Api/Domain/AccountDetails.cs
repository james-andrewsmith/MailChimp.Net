using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace MailChimp.Net.Api.Domain
{
    public sealed class AccountDetails
    {
        [JsonProperty("username")]
        public string Username
        {
            get;
            set;
        }

        [JsonProperty("user_id")]
        public string UserID
        {
            get;
            set;
        }

        [JsonProperty("is_trial")]
        public bool IsTrial
        {
            get;
            set;
        }

        [JsonProperty("is_approved")]
        public bool IsApproved
        {
            get;
            set;
        }

        [JsonProperty("has_activated")]
        public bool HasActivated
        {
            get;
            set;
        }

        [JsonProperty("timezone")]
        public string Timezone
        {
            get;
            set;
        }

        [JsonProperty("plan_type")]
        public string plan_type
        {
            get;
            set;
        }

        [JsonProperty("plan_low")]
        public int plan_low
        {
            get;
            set;
        }

        [JsonProperty("plan_high")]
        public int plan_high
        {
            get;
            set;
        }

        [JsonProperty("plan_start_date")]
        public string plan_start_date
        {
            get;
            set;
        }

        [JsonProperty("emails_left")]
        public int emails_left
        {
            get;
            set;
        }

        [JsonProperty("pending_monthly")]
        public bool pending_monthly
        {
            get;
            set;
        }

        [JsonProperty("first_payment")]
        public string first_payment
        {
            get;
            set;
        }

        [JsonProperty("last_payment")]
        public string last_payment
        {
            get;
            set;
        }

        [JsonProperty("times_logged_in")]
        public int times_logged_in
        {
            get;
            set;
        }

        [JsonProperty("last_login")]
        public string last_login
        {
            get;
            set;
        }

        [JsonProperty("affiliate_link")]
        public string affiliate_link
        {
            get;
            set;
        }

        [JsonProperty("industry")]
        public string industry
        {
            get;
            set;
        }

        [JsonProperty("contact")]
        public AccountDetailsContact Contact
        {
            get;
            set;
        }


        [JsonProperty("modules")]
        public AccountDetailsModule Modules
        {
            get;
            set;
        }

        [JsonProperty("orders")]
        public AccountDetailsOrder Orders
        {
            get;
            set;
        }

        [JsonProperty("rewards")]
        public AccountDetailsReward Rewards
        {
            get;
            set;
        }

        [JsonProperty("integrations")]
        public AccountDetailsIntegration Integrations
        {
            get;
            set;
        }
    }
}
