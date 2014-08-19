using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MailChimp.Net.Settings;

namespace MailChimp.Net.Api.Helpers
{
    internal static class Urls
    {
        public static string Vip
        {
            get { return "/vip"; }
        }

        public static string User
        {
            get { return "/users"; }
        }

        public static string Template
        {
            get { return "/templates"; }
        }

        public static string Report
        {
            get { return "/reports"; }
        }

        public static string Helper
        {
            get { return "/helper"; }
        }

        public static string Gallery
        {
            get { return "/gallery"; }
        }

        public static string Folder
        {
            get { return "/folders"; }
        }

        public static string ECommerce
        {
            get { return "/ecomm"; }
        }

        public static string Campaign
        {
            get { return "/campaigns"; }
        }

        public static string List
        {
            get { return "/lists"; }
        }

    }
}
