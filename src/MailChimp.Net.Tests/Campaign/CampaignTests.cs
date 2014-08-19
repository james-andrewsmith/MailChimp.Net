using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using MailChimp.Net.Api;
using MailChimp.Net.Api.Domain;
using MailChimp.Net.Api.Helpers;
using MailChimp.Net.Api.Services;
using MailChimp.Net.Settings;

namespace MailChimp.Net.Tests
{
    [TestFixture]
    public class CampaignTests
    {
        [Test]
        public void ListCampaigns()
        {
            MailChimpCampaignService mccs = new MailChimpCampaignService(MailChimpServiceConfiguration.Settings.ApiKey);
            
            var list = mccs.List(new CampaignFilter { });
            
            Assert.IsTrue(list.IsSuccesful);            
        }

        [Test]
        public void CreateCampaign()
        {
            MailChimpCampaignService mccs = new MailChimpCampaignService(MailChimpServiceConfiguration.Settings.ApiKey);

            var campaign = mccs.Create(CampaignType.Regular, new ContentOption
            {

            });

            Assert.IsTrue(campaign);
        }
    }
}
