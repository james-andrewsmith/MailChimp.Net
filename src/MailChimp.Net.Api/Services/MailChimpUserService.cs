using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks; 

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using MailChimp.Net.Settings;
using MailChimp.Net.Api.Domain;
using MailChimp.Net.Api.Helpers;

namespace MailChimp.Net.Api.Services
{
    public sealed class MailChimpUserService : MailChimpService
    {
        #region // Constructors // 
         
        public MailChimpUserService(string apiKey = null, string dataCenter = null)
            : base(apiKey, dataCenter)
        {
        } 

        #endregion

        #region // Invite //

        /// <summary>
        /// http://apidocs.mailchimp.com/api/2.0/users/invite.php
        /// </summary>
        /// <returns></returns>
        public Task<MailChimpServiceResponse> InviteAsync(string email, Role role = Role.Viewer, string message = null)
        {
            var url = Urls.User + "/invite.json";

            var request = new
            {
                email = email,
                role = role,
                message = message
            };

            return Execute(url, request);
        }

        #endregion

        #region // Invite Resend //

        /// <summary>
        /// http://apidocs.mailchimp.com/api/2.0/users/invite-resend.php
        /// </summary>
        /// <returns></returns>
        public Task<MailChimpServiceResponse> InviteResendAsync(string email)
        {
            var url = Urls.User + "/invite-resend.json";
            var request = new
            {
                email = email
            };
            return Execute(url, request);
        }

        #endregion
        
        #region // Invite Revoke //

        /// <summary>
        /// http://apidocs.mailchimp.com/api/2.0/users/invite-revoke.php
        /// </summary>
        /// <returns></returns>
        public Task<MailChimpServiceResponse> InviteRevokeAsync(string email)
        {
            var url = Urls.User + "/invite-revoke.json";
            var request = new
            {
                email = email
            };
            return Execute(url, request);
        }

        #endregion

        #region // Invites //

        /// <summary>
        /// http://apidocs.mailchimp.com/api/2.0/users/invites.php
        /// </summary>
        /// <returns></returns>
        public Task<MailChimpServiceResponse> InvitesAsync()
        {
            var url = Urls.User + "/invites.json";
            return Execute(url);
        }

        #endregion
        
        #region // Login Revoke //

        /// <summary>
        /// http://apidocs.mailchimp.com/api/2.0/users/login-revoke.php
        /// </summary>
        /// <returns></returns>
        public Task<MailChimpServiceResponse> LoginRevokeAsync(string username)
        {
            var url = Urls.User + "/login-revoke.json";
            var request = new
            {
                username = username
            };
            return Execute(url, request);
        }

        #endregion

        #region // Logins //

        /// <summary>
        /// http://apidocs.mailchimp.com/api/2.0/users/logins.php
        /// </summary>
        /// <returns></returns>
        public Task<MailChimpServiceResponse<List<User>>> LoginsAsync(string username)
        {
            var url = Urls.User + "/logins.json";
            return Execute<List<User>>(url);
        }

        #endregion

        #region // Profile //

        /// <summary>
        /// http://apidocs.mailchimp.com/api/2.0/users/profile.php
        /// </summary>
        /// <returns></returns>
        public Task<MailChimpServiceResponse<User>> ProfileAsync(string username)
        {
            var url = Urls.User + "/profile.json";
            return Execute<User>(url);
        }

        #endregion
    }
}
