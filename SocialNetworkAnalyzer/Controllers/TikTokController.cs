using Microsoft.AspNetCore.Mvc;
using SocialAnalyzer.models;
using SocialAnalyzer.services.TikTok;
using SocialNetworkAnalyzer.Models;

namespace SocialAnalyzer.Controllers
{
    public class TikTokController : Controller
    {
        [HttpPost]
        public IActionResult Index(string name)
        {
            TikTokUser user = GetMainTikTokInfo.GetName("https://www.tiktok.com/@" + name).Result;
            if (user == null)
            {
                return View("Shared/Error");
            }
            else
            return View(user);
        }

    }
}
