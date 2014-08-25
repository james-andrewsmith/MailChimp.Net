===============================
 MailChimp.NET 
===============================

This project is a complete wrapper for the MailChimp API V2 (link), it was orignally forked from Spyros' (https://github.com/sdesyllas) library, and was refactored to include many concepts and snippets from the Jayme Davis' amazing Stripe.Net library. A big shout out to MailChimp for documenting their API so well, I was able to write 95% off this code without running a single request.

It includes:

- Full Service MailChimp API Client
- Async & Await Compatible
- Webhooks Controller / Handler

This API was written to faciliate clean and concise code at all levels.

###### Installation
You can install via NuGet, or download a build from the releases page. 

###### Configuration
You can instanciate a class using your APIKey and/or Datacentre, if these are omited the values from the config section are used: 

- Dynamic Runtime DataCentre & APIKey

```xml
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
  <configSections>
    <section name="MailChimpServiceSettings" type="MailChimp.Net.Settings.MailChimpServiceConfiguration, MailChimp.Net.Settings" />
  </configSections>
  <MailChimpServiceSettings
    apiKey="testapikey-us7"
    subscriberListId="testlistid"
    serviceUrl="https://us7.api.mailchimp.com/2.0/"
    listsRelatedSection="lists"
    helperRelatedSection="helper"/>
</configuration>
```

###### Sample Services

Ping, Subscribe, ECommerce Tranaction

###### Webhooks

WebHooks are implemented for ASP.NET MVC projects via an abstact "WebhookController", this will natively call the virtual functions for each type of event with the parameters already mapped to input variables. 

You're expected to catch any exceptions in your webhook overrides, otherwise the webhook will return a 500 error code and MailChimp will retry the request according to their backoff strategy.

##### Return Objects

Whenever possible the API will return a native object mapped with the values of the response, however a number of API calls in MailChimp result in specific structures to each account. To handle these cases the response always contains the raw JSON and a JSON.net JToken to allow for easy traversal of any response. If an error has occured the raw JSON will contain the JSON for the error.

###### Errors
Whenever possible we will map the error returned from the API to a native MailChimpException. 

3. Code example to subscribe a newsletter with the given groupings and merge vars

```csharp
 IMailChimpApiService mailChimpApiService = new MailChimpApiService(MailChimpServiceConfiguration.Settings.ApiKey);
 
 var subscribeSources = new Grouping {Name = "Subscribe Source"};
 subscribeSources.Groups.Add("Site");

 var couponsGained = new Grouping {Name = "Coupons Gained"};
 couponsGained.Groups.Add("Coupon1");

 var interests = new Grouping {Name = "Interests"};
 interests.Groups.Add("Extreme Games");


 var fields = new Dictionary<string, string>
 {
     {"GENDER", "Male"},
     {"DATEBORN", DateTime.Now.ToString(CultureInfo.InvariantCulture)},
     {"CITY", "Athens"},
     {"COUNTRY", "Greece"}
 };

 var response = mailChimpApiService.Subscribe("test@domain.com", new List() { subscribeSources, couponsGained, interests }, fields, true);
```
