using Microsoft.AspNetCore.Mvc;
using SocialAnalyzer.models;
using SocialAnalyzer.services.TikTok;

namespace SocialAnalyzer.Controllers
{
    public class TikTokController : Controller
    {
        public IActionResult Index()
        {
            //GetMainInfo.GetName("https://www.tiktok.com/@alastor_alina");
            //if(user == null)
            //{
            //    ViewBag.UserName = "user is null";
            //} else
            //ViewBag.UserName = user.userName;

            return View();
        }
    }
}
