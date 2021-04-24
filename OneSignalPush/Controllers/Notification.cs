using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using OneSignalPush.Helper;
using OneSignalPush.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneSignalPush.Controllers
{
    public class Notification : Controller
    {
        private readonly IConfiguration _configuration;

        public Notification(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateNotification(CreateNotificationModel request)
        {
            Guid appId = Guid.Parse(_configuration.GetSection(AppSettingKey.OneSignalAppId).Value);
            string restKey = _configuration.GetSection(AppSettingKey.OneSignalRestKey).Value;
            string result = await OneSignalPushNotificationHelper.OneSignalPushNotification(request, appId, restKey);
            return RedirectToAction("Index", "Notification");
        }


    }
}
