using OneSignal.RestAPIv3.Client;
using OneSignal.RestAPIv3.Client.Resources;
using OneSignal.RestAPIv3.Client.Resources.Notifications;
using OneSignalPush.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneSignalPush.Helper
{
    public class OneSignalPushNotificationHelper
    {

        public static async Task<string> OneSignalPushNotification(CreateNotificationModel request, Guid appId, string restKey)
        {
            var client = new OneSignalClient(restKey);
            var opt = new NotificationCreateOptions()
            {
                AppId = appId,
                IncludedSegments = new string[] { "Subscribed Users" }
            };
            opt.Headings.Add(LanguageCodes.English, request.Title);
            opt.Contents.Add(LanguageCodes.English, request.Content);

            try
            {
                NotificationCreateResult result = await client.Notifications.CreateAsync(opt);
                return result.Id;
            }

            catch (Exception ex)
            {
                throw;
            }


        }


    }
}
