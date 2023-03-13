using Microsoft.AspNetCore.Mvc;
using SocialAnalyzer.models;
using SocialAnalyzer.services.TikTok;

namespace SocialNetworkAnalyzer.Controllers
{
    public class TelegramController : Controller
    {
        public IActionResult Index()
        {
            TelegramUser user = GetMainTelegramInfo.GetName("https://uk.tgstat.com/en/channel/@V_Zelenskiy_official/stat").Result;
            if (user == null)
            {
                return View("Shared/Error");
            }
            else
                return View(user);
        }
    }
}
