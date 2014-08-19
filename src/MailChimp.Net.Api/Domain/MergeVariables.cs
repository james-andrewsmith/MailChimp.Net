using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

using MailChimp.Net.Api.Helpers;

namespace MailChimp.Net.Api.Domain
{
    public sealed class MergeTagHelper
    {
        public static string Address(Address address)
        {
            return (string.IsNullOrEmpty(address.Line1) ? string.Empty : address.Line1.Trim()) +
                   "  " +
                   (string.IsNullOrEmpty(address.Line2) ? string.Empty : address.Line2.Trim()) +
                   "  " +
                   (string.IsNullOrEmpty(address.City) ? string.Empty : address.City.Trim()) +
                   "  " +
                   (string.IsNullOrEmpty(address.State) ? string.Empty : address.State.Trim()) +
                   "  " +
                   (string.IsNullOrEmpty(address.Zip) ? string.Empty : address.Zip.Trim()) +
                   "  " +
                   (string.IsNullOrEmpty(address.Country) ? string.Empty : address.Country.Trim());
                   
        }

        public static string Birthday(DateTime birthday)
        {
            return birthday.ToString("MM/dd");
        }

        public static string Date(DateTime date)
        {
            return date.ToString("yyyy-MM-dd");
        }
    }

    [JsonConverter(typeof(MergeVariableConverter))]
    public sealed class MergeVariables
    {

        public MergeVariables()
        {
            Tags = new Dictionary<string, object>();
        }


        [JsonProperty("id")]
        public string Id
        {
            get;
            set;
        }

        [JsonProperty("new-email")]
        public string NewEmail
        {
            get;
            set;
        }

        public Dictionary<string, object> Tags
        {
            get;
            set;
        }

        [JsonProperty("groupings")]
        public List<MergeVariableGrouping> Groupings
        {
            get;
            set;
        }

        [JsonProperty("optin_ip")]
        public string OptInIPAddress
        {
            get;
            set;
        }

        [JsonProperty("optin_time")]
        public string OptInTime
        {
            get;
            set;
        }

        [JsonProperty("mc_location")]
        public Location Location
        {
            get;
            set;
        }

        [JsonProperty("mc_language")]
        public string Language
        {
            get;
            set;
        }

        [JsonProperty("mc_notes")]
        public List<Note> Notes
        {
            get;
            set;
        }
    }

    public class Note
    {
        [JsonProperty("note")]
        public string Content
        {
            get;
            set;
        }

        [JsonProperty("id")]
        public int ID
        {
            get;
            set;
        }

        [JsonProperty("action")]
        public string Action
        {
            get;
            set;
        }

    }

    public class Location
    {
        [JsonProperty("latitude")]
        public string Latitude
        {
            get;
            set;
        }

        [JsonProperty("longitude")]
        public string Longitude
        {
            get;
            set;
        }

        [JsonProperty("anything")]
        public string Anything
        {
            get;
            set;
        }

    }

    public class Address
    {
        public string Line1
        {
            get;
            set;
        }

        public string Line2
        {
            get;
            set;
        }

        public string City
        {
            get;
            set;
        }

        public string State
        {
            get;
            set;
        }

        public string Zip
        {
            get;
            set;
        }

        public string Country
        {
            get;
            set;
        }
         

    }
    
    public class MergeVariableGrouping
    {
        [JsonProperty("id")]
        public int ID
        {
            get;
            set;
        }

        [JsonProperty("name")]
        public string Name
        {
            get;
            set;
        }

        [JsonProperty("groups")]
        public List<string> Groups
        {
            get;
            set;
        }
    }

}
