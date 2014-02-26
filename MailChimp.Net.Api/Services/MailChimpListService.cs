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
    public sealed class MailChimpListService : MailChimpService
    {
        
        #region // Constructors //
        
        public MailChimpListService(string apiKey = null, string dataCenter = null)
            : base(apiKey, dataCenter)
        {
        }

        #endregion

        #region // Subscription //


        private Task<ServiceResponse> SubscribeWithMergeVarsAsync(string email, string listId, dynamic mergeVars, bool enableDoubleOptIn)
        {
            var url = Urls.List + "/subscribe.json";
                    
            var subscriber = new Subscriber
            {
                DoubleOptIn = enableDoubleOptIn,
                ListId = listId,
                Email = new Email { EmailValue = email },
                UpdateExisting = true
            };

            if (mergeVars != null)
                subscriber.MergeVars = mergeVars;
            
            return Execute(url, subscriber); 
        }

        public Task<ServiceResponse<Email>> UnsubscribeAsync(Email email, string listID)
        {

            var url = Urls.List + "/unsubscribe.json";
           
            var subscriber = new Subscriber();
            subscriber.Email = email;
            subscriber.UpdateExisting = true;

            return Execute<Email>(url, subscriber.ToString()).ContinueWith(t =>
            {
                if (t.Result.IsSuccesful)
                    t.Result.IsSuccesful = t.Result.Value.EmailValue != null &&
                                           t.Result.Value.Euid != null &&
                                           t.Result.Value.Leid != null;

                return t.Result;
            });
        }

        /// <summary>
        /// http://apidocs.mailchimp.com/api/2.0/lists/batch-subscribe.php
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public Task<ServiceResponse> BatchSubscribeAsync(string id, List<Email> emails, bool doubleOptIn = true, bool updateExisting = false, bool replaceInterests = true)
        {
            
            var url = Urls.List + "/batch-subscribe.json";
            
            var request = new
            {
                id = id,
                double_optin = doubleOptIn,
                update_existing = updateExisting,
                replace_interests = replaceInterests
            };

            return Execute(url, request);

        }

        /// <summary>
        /// http://apidocs.mailchimp.com/api/2.0/lists/batch-unsubscribe.php
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public Task<ServiceResponse> BatchUnsubscribeAsync(string id, List<Email> emails, bool deleteMember = false, bool sendGoodBye = true, bool sendNotify = false)
        {
            
            var url = Urls.List + "/batch-unsubscribe.json";
            
            var request = new
            {
                id = id,
                delete_member = deleteMember,
                send_goodbye = sendGoodBye,
                send_notify = sendNotify
            };

            return Execute(url, request);

        }

        #endregion

        #region // Abuse Reports //

        public ServiceResponse AbuseReports(string id, int start = 0, int limit = 25, string since = null)
        {
            return WaitForServiceResponse(AbuseReportsAsync(id, start, limit, since));
        }

        /// <summary>
        /// http://apidocs.mailchimp.com/api/2.0/lists/abuse-reports.php
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public Task<ServiceResponse> AbuseReportsAsync(string id, int start = 0, int limit = 25, string since = null)
        {
            var url = Urls.List + "/abuse-reports.json";

            var request = new
            {
                id,
                start,
                limit,
                since
            };

            return Execute(url, request);
        }

        #endregion

        #region // Activity //
        public ServiceResponse Activity(string id)
        {
            return WaitForServiceResponse(ActivityAsync(id));
        }

        /// <summary>
        /// http://apidocs.mailchimp.com/api/2.0/lists/activity.php
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public Task<ServiceResponse> ActivityAsync(string id)
        {
         
            var url = Urls.List + "/activity.json";

            var request = new
            {
                id = id
            };

            return Execute(url, request);
        }

        #endregion
         
        #region // Clients //

        public ServiceResponse Clients(string id)
        {
            return WaitForServiceResponse(ClientsAsync(id));
        }

        /// <summary>
        /// http://apidocs.mailchimp.com/api/2.0/lists/clients.php
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public Task<ServiceResponse> ClientsAsync(string id)
        {            
            var url = Urls.List + "/clients.json";
            
            var request = new
            {
                id = id
            };

            return Execute(url, request);
        }

        #endregion

        #region // Growth History //

        public ServiceResponse GrowthHistory(string id = null)
        {
            return WaitForServiceResponse(GrowthHistoryAsync(id));
        }

        /// <summary>
        /// http://apidocs.mailchimp.com/api/2.0/lists/growth-history.php
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public Task<ServiceResponse> GrowthHistoryAsync(string id = null)
        {
            var url = Urls.List + "/growth-history.json";

            var request = new
            {
                id = id
            };

            return Execute(url, request);
        }

        #endregion

        #region // Interest Groups //

        public ServiceResponse InterestGroupAdd(string id, string groupName, int groupingID = 0)
        {
            return WaitForServiceResponse(InterestGroupAddAsync(id, groupName, groupingID));
        }

        /// <summary>
        /// http://apidocs.mailchimp.com/api/2.0/lists/interest-group-add.php
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public Task<ServiceResponse> InterestGroupAddAsync(string id, string groupName, int groupingID = 0)
        {
            
            var url = Urls.List + "/interest-group-add.json";
            
            var request = new
            {
                id = id,
                group_name = groupName,
                grouping_id = groupingID
            };

            return Execute(url, request);
        }

        public ServiceResponse InterestGroupDelete(string id, string groupdName, int groupingID = 0)
        {
            return WaitForServiceResponse(InterestGroupDeleteAsync(id, groupdName, groupingID));
        }

        /// <summary>
        /// http://apidocs.mailchimp.com/api/2.0/lists/interest-group-add.php
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public Task<ServiceResponse> InterestGroupDeleteAsync(string id, string groupName, int groupingID = 0)
        {
            var url = Urls.List + "/interest-group-del.json";

            var request = new
            {
                id = id
            };

            return Execute(url, request);
        }

        public ServiceResponse InterestGroupUpdate(string id, string oldGroupName, string newGroupName, int groupingID = 0)
        {
            return WaitForServiceResponse(InterestGroupUpdateAsync(id, oldGroupName, newGroupName, groupingID));
        }

        /// <summary>
        /// http://apidocs.mailchimp.com/api/2.0/lists/interest-group-update.php
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public Task<ServiceResponse> InterestGroupUpdateAsync(string id, string oldGroupName, string newGroupName, int groupingID = 0)
        {            
            var url = Urls.List + "/interest-group-update.json";
         
            var request = new
            {
                id = id,
                old_name = oldGroupName, 
                new_name = newGroupName,
                grouping_id = groupingID
            };

            return Execute(url, request);
        }

        public ServiceResponse InterestGroupings(string id, bool counts = false)
        {
            return WaitForServiceResponse(InterestGroupingsAsync(id, counts));
        }

        /// <summary>
        /// http://apidocs.mailchimp.com/api/2.0/lists/interest-groupings.php
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public Task<ServiceResponse> InterestGroupingsAsync(string id, bool counts = false)
        {
            
            var url = Urls.List + "/interest-groupings.json";
            
            var request = new
            {
                apikey = _apiKey,
                id = id,
                counts = counts
            };

            return Execute(url, request);
        }

        #endregion

        #region // List //

        public ServiceResponse List(string listID, string listName, string fromName, string fromEmail, string fromSubject, string createdBefore, string createdAfter, bool exact, int start, int limit, string sortField, string sortDirection)
        {
            return WaitForServiceResponse(ListAsync(listID, listName, fromName, fromEmail, fromSubject, createdBefore, createdAfter, exact, start, limit, sortField, sortDirection));
        }       

        /// <summary>
        /// http://apidocs.mailchimp.com/api/2.0/lists/list.php
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public Task<ServiceResponse> ListAsync(string listID, string listName, string fromName, string fromEmail, string fromSubject, string createdBefore, string createdAfter, bool exact, int start, int limit, string sortField, string sortDirection)
        {
            
            var url = Urls.List + "/list.json";

            var request = new
            {
                filters = new
                {
                    list_id = listID,
                    list_name = listName,
                    from_name = fromName,
                    from_email = fromEmail,
                    from_subject = fromSubject,
                    created_before = createdBefore,
                    created_after = createdAfter
                },
                start, 
                limit, 
                sort_field = sortField,
                sort_dir = sortDirection
            };

            return Execute(url, request); 
        }

        #endregion

        #region // Locations //

        /// <summary>
        /// http://apidocs.mailchimp.com/api/2.0/lists/locations.php
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public Task<ServiceResponse> LocationsAsync(string id)
        {
            var url = Urls.List + "/locations.json";

            var request = new
            {
                id = id
            };

            return Execute(url, request);
        }

        #endregion

        #region // Members //

        /// <summary>
        /// http://apidocs.mailchimp.com/api/2.0/lists/member-activity.php
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public Task<ServiceResponse> MemberActivityAsync(string id, List<string> emails)
        {
            
            var url = Urls.List + "/member-activity.json";
            
            var request = new
            {
                
            };

            return Execute(url, request);

        }

        /// <summary>
        /// http://apidocs.mailchimp.com/api/2.0/lists/member-info.php
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public Task<ServiceResponse> MemberInfoAsync(string id, List<string> emails)
        {
            var url = Urls.List + "/member-info.json";

            var request = new
            {
            };

            return Execute(url, request);
        }

        public ServiceResponse UpdateMember(string id, Email email, Dictionary<string, List<string>> mergeVars, EmailType type, bool replaceInterests)
        {
            return WaitForServiceResponse(UpdateMemberAsync(id, email, mergeVars, type, replaceInterests));
        }

        /// <summary>
        /// http://apidocs.mailchimp.com/api/2.0/lists/update-member.php
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public Task<ServiceResponse> UpdateMemberAsync(string id, Email email, Dictionary<string, List<string>> mergeVars, EmailType type, bool replaceInterests)
        {
            var url = Urls.List + "/update-member.json";
            
            var request = new
            {
                id = id,
                email = email, 
                merge_vars = mergeVars,
                email_type = type,
                replace_interests = replaceInterests
            };

            return Execute(url, request); 
        }

        #endregion

        #region // Merge Variables or Tags... //

        /// <summary>
        /// http://apidocs.mailchimp.com/api/2.0/lists/merge-var-add.php
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public Task<ServiceResponse> MergeVariableAddAsync(string id, string tag, string name, string fieldType = "text", bool required = false, bool @public = true, bool show = true, int order = 0, string defaultValue = "", string helpText = "", List<string> choices = null, string dateFormt = "MM/DD", string phoneFormat = "US", string defaultCountry = "US")
        {
            
            var url = Urls.List + "/merge-var-add.json";
            
            var request = new
            {
            };

            return Execute(url, request);
        }

        /// <summary>
        /// http://apidocs.mailchimp.com/api/2.0/lists/merge-var-del.php
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public Task<ServiceResponse> MergeVarDeleteAsync(string id, string tag)
        {            
            var url = Urls.List + "/merge-var-del.json";
            
            var request = new
            {
                id = id,
                tag = tag
            };

            return Execute(url, request); 
        }

        /// <summary>
        /// http://apidocs.mailchimp.com/api/2.0/lists/merge-var-reset.php
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public Task<ServiceResponse> MergeVarResetAsync(string id, string tag)
        {
            
            var url = Urls.List + "/merge-var-reset.json";
            
            var request = new
            {
                id = id,
                tag = tag
            };

            return Execute(url, request);             
        }
        
        /// <summary>
        /// http://apidocs.mailchimp.com/api/2.0/lists/merge-var-set.php
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public Task<ServiceResponse> MergeVarSetAsync(string id, string tag, string value)
        {           
            var url = Urls.List + "/merge-var-set.json";

            var request = new
            {
                tag = tag
            };

            return Execute(url, request);
        }

        /// <summary>
        /// http://apidocs.mailchimp.com/api/2.0/lists/merge-var-update.php
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public Task<ServiceResponse> MergeVarUpdateAsync(string id, string tag, string fieldType = "text", bool required = false, bool @public = true, bool show = true, int order = 0, string defaultValue = "", string helpText = "", List<string> choices = null, string dateFormt = "MM/DD", string phoneFormat = "US", string defaultCountry = "US")
        {
            var url = Urls.List + "/merge-var-set.json";

            var request = new
            {
                apikey = _apiKey,
                tag = tag
            };

            return Execute(url, request);
        }
        
        /// <summary>
        /// http://apidocs.mailchimp.com/api/2.0/lists/merge-vars.php
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public Task<ServiceResponse> MergeVarsAsync(string id)
        {
            var url = Urls.List + "/merge-vars.json";

            var request = new
            {
                id = id
            };

            return Execute(url, request);
        }

        #endregion

        #region // Segments //

        /// <summary>
        /// http://apidocs.mailchimp.com/api/2.0/lists/merge-vars.php
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public Task<ServiceResponse> SegmentAddAsync(string id, string type, string name, string match = null, List<string> conditions = null)
        {
            var url = Urls.List + "/segment-add.json";
            
            var request = new
            {
                apikey = _apiKey,
                id = id,
                opts = new
                {
                    type = type,
                    name = name,
                    segment_opts = new
                    {
                        match = match,
                        conditions = conditions
                    }
                }
            };

            return Execute(url, request);
        }

        /// <summary>
        /// http://apidocs.mailchimp.com/api/2.0/lists/segment-del.php
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public Task<ServiceResponse> SegmentDeleteAsync(string id, string type, string name, string match = null, List<string> conditions = null)
        {
            var url = Urls.List + "/segment-del.json";

            var request = new
            {
                apikey = _apiKey,
                id = id,
                opts = new
                {
                    type = type,
                    name = name,
                    segment_opts = new
                    {
                        match = match,
                        conditions = conditions
                    }
                }
            };

            return Execute(url, request);
        }

        public ServiceResponse SegmentTest(string id, string savedSegementID, string match, List<string> conditions)
        {
            return WaitForServiceResponse(SegmentTestAsync(id, savedSegementID, match, conditions));
        }

        /// <summary>
        /// http://apidocs.mailchimp.com/api/2.0/lists/segment-test.php
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public Task<ServiceResponse> SegmentTestAsync(string id, string savedSegementID, string match, List<string> conditions)
        {
           
            var url = Urls.List + "/segment-test.json";

            var request = new
            {
                list_id = id,
                options = new
                {
                    saved_segment_id = savedSegementID,
                    match, 
                    conditions
                }
            };

            return Execute(url, request);
        }

        public ServiceResponse SegmentUpdate(string id, string segmentID, string name = null, string match = null, List<Condition> conditions = null)
        {
            return WaitForServiceResponse(SegmentUpdateAsync(id, segmentID, name, match, conditions));
        }

        /// <summary>
        /// http://apidocs.mailchimp.com/api/2.0/lists/segment-update.php
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public Task<ServiceResponse> SegmentUpdateAsync(string id, string segmentID, string name = null, string match = null, List<Condition> conditions = null)
        {            
            var url = Urls.List + "/segment-update.json";
            
            var request = new
            {
                id = id,
                seg_id = segmentID,
                opts = new
                {
                    name = name,
                    segment_opts = new
                    {
                        match = match,
                        conditions = conditions
                    }
                }
            };

            return Execute(url, request); 
        }

        public ServiceResponse Segments(string id, string type)
        {
            return WaitForServiceResponse(SegmentsAsync(id, type));
        }
       
        /// <summary>
        /// http://apidocs.mailchimp.com/api/2.0/lists/segments.php
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public Task<ServiceResponse> SegmentsAsync(string id, string type)
        {
            
            var url = Urls.List + "/segments.json";
            
            var request = new
            {
                id,
                type
            };

            return Execute(url, request); 

        }

        #endregion         

        #region // Webhooks //

        public ServiceResponse WebhookAdd(string id, string url, bool subscribe, bool unsubscribe, bool profile, bool cleaned, bool upemail, bool campaign, bool user, bool admin, bool api)
        {
            return WaitForServiceResponse(WebhookAddAsync(id, url, subscribe, unsubscribe, profile, cleaned, upemail, campaign, user, admin, api));
        }

        /// <summary>
        /// http://apidocs.mailchimp.com/api/2.0/lists/webhook-add.php
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public Task<ServiceResponse> WebhookAddAsync(string id, string url, bool subscribe, bool unsubscribe, bool profile, bool cleaned, bool upemail, bool campaign, bool user, bool admin, bool api)
        {                        
            var request = new
            {
                id = id,
                url = url,
                actions = new 
                {
                    subscribe,
                    unsubscribe,
                    profile,
                    cleaned,
                    upemail,
                    campaign
                },
                sources = new
                {
                    user,
                    admin,
                    api
                }
            };

            return Execute(Urls.List + "/webhook-add.json", request);
        }

        public ServiceResponse WebhookDelete(string id, string url)
        {
            return WaitForServiceResponse(WebhookDeleteAsync(id, url));
        }

        /// <summary>
        /// http://apidocs.mailchimp.com/api/2.0/lists/webhook-del.php
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public Task<ServiceResponse> WebhookDeleteAsync(string id, string url)
        {            
            var request = new
            {
                id,
                url
            };

            return Execute(Urls.List + "/webhook-delete.json", request);
        }

        public ServiceResponse Webhooks(string id)
        {
            return WaitForServiceResponse(WebhooksAsync(id));
        }

        /// <summary>
        /// http://apidocs.mailchimp.com/api/2.0/lists/webhooks.php
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public Task<ServiceResponse> WebhooksAsync(string id)
        {
            var url = Urls.List + "/webhooks.json";

            var request = new
            {
                id = id
            };

            return Execute(url, request); 
        }

        #endregion

    }
}
