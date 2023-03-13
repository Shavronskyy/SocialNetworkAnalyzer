using Microsoft.AspNetCore.Mvc;
using SocialAnalyzer.models;
using SocialAnalyzer.services.TikTok;
using SocialNetworkAnalyzer.Models;
using SocialNetworkAnalyzer.Services.Instagram;

namespace SocialNetworkAnalyzer.Controllers
{
    public class InstagramController : Controller
    {
        public IActionResult Index()
        {
            InstagramUser user = GetMainInstagramInfo.GetName("https://www.instagram.com/shavronskyy/").Result;
            if (user == null)
            {
                return View("Shared/Error");
            }
            else
                return View(user);
        }
    }
}
