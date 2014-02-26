using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailChimp.Net.Settings
{
    public class MailChimpServiceConfiguration : ConfigurationSection
    {
        // ReSharper disable InconsistentNaming
        private static readonly MailChimpServiceConfiguration _settings = ConfigurationManager.GetSection("MailChimpServiceSettings") as MailChimpServiceConfiguration;
        // ReSharper restore InconsistentNaming

        public static MailChimpServiceConfiguration Settings
        {
            get
            {
                return _settings;
            }
        }

        [ConfigurationProperty("apiKey", DefaultValue = "testkey")]
        public string ApiKey
        {
            get { return (string)this["apiKey"]; }
            set { this["apiKey"] = value; }
        }

        [ConfigurationProperty("dataCenter", DefaultValue = "testkey")]
        public string DataCenter
        {
            get { return (string)this["dataCenter"]; }
            set { this["dataCenter"] = value; }
        }             
    }
}
