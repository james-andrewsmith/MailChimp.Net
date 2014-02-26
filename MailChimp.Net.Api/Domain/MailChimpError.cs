using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailChimp.Net.Api.Domain
{
    public sealed class MailChimpError
    {
        public string Status
        {
            get;
            set;
        }

        public int Code
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string Error
        {
            get;
            set;
        }
    }
}
