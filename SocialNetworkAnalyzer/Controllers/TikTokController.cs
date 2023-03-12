using Microsoft.AspNetCore.Mvc;
using SocialAnalyzer.models;
using SocialAnalyzer.services.TikTok;

namespace SocialAnalyzer.Controllers
{
    public class TikTokController : Controller
    {
        public IActionResult Index()
        {
            string username = GetMainInfo.GetName("https://www.tiktok.com/@alastor_alina").Result.ToString();
            if (username == null)
            {
                ViewBag.UserName = "user is null";
            }
            else
                ViewBag.UserName = username;

            return View();
        }
    }
}
