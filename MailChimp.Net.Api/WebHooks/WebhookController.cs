using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Web.Mvc;
using MailChimp.Net.Api.Domain;
using log4net;

namespace MailChimp.Net.Api.WebHooks
{
    public abstract class WebhookController : Controller
    {
        private readonly ILog _log = LogManager.GetLogger("MailChimpApiService");

        [HttpPost]
        public ContentResult Index()
        {
            try
            {
                var form = Request.Form;
                switch (form["type"])
                {
                    case "subscribe":
                        break;
                    case "unsubscribe":
                        break;
                    case "profile":
                        break;
                    case "upemail":
                        break;
                    case "cleaned":
                        break;
                    case "campaign":
                        break;
                }
            }
            catch (Exception exp)
            {
                _log.Error("Webhook Controller Error", exp);
                this.Response.StatusCode = 500;                
            }

            return new ContentResult
            {
                Content = "",
                ContentType = "text/plain",
                ContentEncoding = Encoding.UTF8
            };
        }

        public virtual void Subscribes(DateTime firedAt, string id, string listID, string email, string emailType, Dictionary<string, string> mergeData, string ipOpt, string ipSignUp)
        {
        }

        public virtual void Unsubscribes(DateTime firedAt, string action, string reason, string id, string listID, string email, EmailType emailType, Dictionary<string, string> mergeData, string ipOpt, string campaignId)
        {
        }

        public virtual void ProfileUpdate(DateTime firedAt, string id, string listID, string email, EmailType emailType, Dictionary<string, string> mergeData, string ipOpt)
        {
        }

        public virtual void EmailAddressChange(DateTime firedAt, string listID, string newID, string newEmail, string oldEmail)
        {
        }

        public virtual void CleanedEmail(DateTime firedAt, string listID, string campaignID, string reason, string email)
        {
        }

        public virtual void CampaignSendingStatus(DateTime firedAt, string id, string subject, string status, string reason, string listID)
        {
        }

    }
}
