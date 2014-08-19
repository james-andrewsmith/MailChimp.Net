using System;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Web.Mvc;
using MailChimp.Net.Api.Domain;
using log4net;

namespace MailChimp.Net.Api.WebHooks
{

    /// <summary>
    /// Implements an endpoint for receiving webhooks from the MailChimp API
    /// <see cref="http://apidocs.mailchimp.com/webhooks/"/>
    /// </summary>
    public abstract class WebhookController : Controller
    {
        private readonly ILog _log = LogManager.GetLogger("MailChimpApiService");
        
        public ContentResult Index()
        {
            try
            {
                var form = Request.Form; 

                switch (form["type"])
                {
                    case "subscribe":
                        Subscribes(form);
                        break;
                    case "unsubscribe":
                        Unsubscribes(form);
                        break;
                    case "profile":
                        ProfileUpdates(form);
                        break;
                    case "upemail":
                        EmailAddressChange(form);
                        break;
                    case "cleaned":
                        CleanedEmails(form);
                        break;
                    case "campaign":
                        CampaignSending(form);
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

        #region // Unsubscribes //

        private void Unsubscribes(NameValueCollection form)
        {
            DateTime firedAt = DateTime.Now;
            string action, reason, id, listID, email, campaignID, ipOpt;
            action = reason = id = listID = email = campaignID = ipOpt = string.Empty;

            EmailType emailType = EmailType.Html;
            Dictionary<string, string> mergeData = new Dictionary<string,string>();
            
            for(int i = 0; i < form.Keys.Count; i++)
            {
                string key = form.Keys[i], value = form[i];

                switch(key)
                {                        
                    case "type":
                        // do nothing, we already know this
                        break;
                    case "fired_at":
                        firedAt = DateTime.Parse(value);
                        break;
                    case "data[action]":
                        action = value;
                        break;
                    case "data[reason]":
                        reason = value;
                        break;
                    case "data[id]":
                        id = value;
                        break;
                    case "data[list_id]":
                        listID = value;
                        break;
                    case "data[email]":
                        email = value;
                        break;
                    case "data[email_type]":
                        emailType = (EmailType)Enum.Parse(typeof(EmailType), value, true);
                        break;
                    case "data[ip_opt]":
                        ipOpt = value;
                        break;
                    case "data[campaign_id]":
                        campaignID = value;
                        break;
                    default:
                        if (key.StartsWith("data[merges]"))
                        {
                            mergeData.Add(key.Substring("data[merges]".Length).Trim('[', ']'), value);
                        }
                        break;
                }

            }

            OnUnsubscribe(firedAt, action, reason, id, listID, email, emailType, mergeData, ipOpt, campaignID);
        }

        public virtual void OnUnsubscribe(DateTime firedAt, string action, string reason, string id, string listID, string email, EmailType emailType, Dictionary<string, string> mergeData, string ipOpt, string campaignID)
        {
        }

        #endregion

        #region // Subsscribes //

        private void Subscribes(NameValueCollection form)
        {
            DateTime firedAt = DateTime.Now;
            string id, listID, email, ipSignUp, ipOpt;
            id = listID = email = ipSignUp = ipOpt = string.Empty;

            EmailType emailType = EmailType.Html;
            Dictionary<string, string> mergeData = new Dictionary<string, string>();

            for (int i = 0; i < form.Keys.Count; i++)
            {
                string key = form.Keys[i], value = form[i];

                switch (key)
                {
                    case "type":
                        // do nothing, we already know this
                        break;
                    case "fired_at":
                        firedAt = DateTime.Parse(value);
                        break; 
                    case "data[id]":
                        id = value;
                        break;
                    case "data[list_id]":
                        listID = value;
                        break;
                    case "data[email]":
                        email = value;
                        break;
                    case "data[email_type]":
                        emailType = (EmailType)Enum.Parse(typeof(EmailType), value, true);
                        break;
                    case "data[ip_opt]":
                        ipOpt = value;
                        break;
                    case "data[ip_signup]":
                        ipSignUp = value;
                        break;
                    default:
                        if (key.StartsWith("data[merges]"))
                        {
                            mergeData.Add(key.Substring("data[merges]".Length).Trim('[', ']'), value);
                        }
                        break;
                }

            }

            OnSubscribe(firedAt, id, listID, email, emailType, mergeData, ipOpt, ipSignUp);
        }

        public virtual void OnSubscribe(DateTime firedAt, string id, string listID, string email, EmailType emailType, Dictionary<string, string> mergeData, string ipOpt, string ipSignUp)
        {
        }

        #endregion

        #region // Profile Update //

        private void ProfileUpdates(NameValueCollection form)
        {
            DateTime firedAt = DateTime.Now;
            string id, listID, email, ipSignUp, ipOpt;
            id = listID = email = ipOpt = string.Empty;

            EmailType emailType = EmailType.Html;
            Dictionary<string, string> mergeData = new Dictionary<string, string>();

            for (int i = 0; i < form.Keys.Count; i++)
            {
                string key = form.Keys[i], value = form[i];

                switch (key)
                {
                    case "type":
                        // do nothing, we already know this
                        break;
                    case "fired_at":
                        firedAt = DateTime.Parse(value);
                        break;
                    case "data[id]":
                        id = value;
                        break;
                    case "data[list_id]":
                        listID = value;
                        break;
                    case "data[email]":
                        email = value;
                        break;
                    case "data[email_type]":
                        emailType = (EmailType)Enum.Parse(typeof(EmailType), value, true);
                        break;
                    case "data[ip_opt]":
                        ipOpt = value;
                        break; 
                    default:
                        if (key.StartsWith("data[merges]"))
                        {
                            mergeData.Add(key.Substring("data[merges]".Length).Trim('[', ']'), value);
                        }
                        break;
                }

            }

            OnProfileUpdate(firedAt, id, listID, email, emailType, mergeData, ipOpt);
        }

        public virtual void OnProfileUpdate(DateTime firedAt, string id, string listID, string email, EmailType emailType, Dictionary<string, string> mergeData, string ipOpt)
        {
        }

        #endregion

        #region // Email Address Change //

        private void EmailAddressChange(NameValueCollection form)
        {
            DateTime firedAt = DateTime.Now;
            string newID, listID, newEmail, oldEmail;
            newID = listID = newEmail = oldEmail = string.Empty;
              
            for (int i = 0; i < form.Keys.Count; i++)
            {
                string key = form.Keys[i], value = form[i];

                switch (key)
                {
                    case "type":
                        // do nothing, we already know this
                        break;
                    case "fired_at":
                        firedAt = DateTime.Parse(value);
                        break;
                    case "data[list_id]":
                        listID = value;
                        break;
                    case "data[new_id]":
                        newID = value;
                        break;
                    case "data[new_email]":
                        newEmail = value;
                        break;
                    case "data[old_email]":
                        oldEmail = value;
                        break;
                }

            }

            OnEmailAddressChange(firedAt, listID, newID, newEmail, oldEmail);
        }

        public virtual void OnEmailAddressChange(DateTime firedAt, string listID, string newID, string newEmail, string oldEmail)
        {
        }

        #endregion

        #region // Cleaned Email //

        private void CleanedEmails(NameValueCollection form)
        {
            DateTime firedAt = DateTime.Now;
            string listID, campaignID, reason, email;
            listID = campaignID = reason = email = string.Empty;
             

            for (int i = 0; i < form.Keys.Count; i++)
            {
                string key = form.Keys[i], value = form[i];

                switch (key)
                {
                    case "type":
                        // do nothing, we already know this
                        break;
                    case "fired_at":
                        firedAt = DateTime.Parse(value);
                        break;
                    case "data[list_id]":
                        listID = value;
                        break;
                    case "data[campaign_id]":
                        campaignID = value;
                        break;
                    case "data[reason]":
                        reason = value;
                        break;
                    case "data[email]":
                        email = value;
                        break;
                }

            }

            OnCleanedEmail(firedAt, listID, campaignID, reason, email);
        }

        public virtual void OnCleanedEmail(DateTime firedAt, string listID, string campaignID, string reason, string email)
        {
        }

        #endregion

        #region // Campaign Sending //

        private void CampaignSending(NameValueCollection form)
        {
            DateTime firedAt = DateTime.Now;
            string id, subject, status, reason, listID;
            id = subject = status = reason = listID = string.Empty;

            for (int i = 0; i < form.Keys.Count; i++)
            {
                string key = form.Keys[i], value = form[i];

                switch (key)
                {
                    case "type":
                        // do nothing, we already know this
                        break;
                    case "fired_at":
                        firedAt = DateTime.Parse(value);
                        break;
                    case "data[id]":
                        id = value;
                        break;
                    case "data[subject]":
                        subject = value;
                        break;
                    case "data[status]":
                        status = value;
                        break;
                    case "data[reason]":
                        reason = value;
                        break;
                    case "data[list_id]":
                        listID = value;
                        break;
                }

            }

            OnCampaignSendingStatus(firedAt, id, subject, status, reason, listID);
        }

        public virtual void OnCampaignSendingStatus(DateTime firedAt, string id, string subject, string status, string reason, string listID)
        {
        }

        #endregion 

    }
}
