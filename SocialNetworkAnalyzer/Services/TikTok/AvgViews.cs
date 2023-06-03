using AngleSharp.Css;
using HtmlAgilityPack;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using System;

namespace SocialNetworkAnalyzer.Services.TikTok
{
    public class AvgViews
    {
        public int GetAvgViews(HtmlNodeCollection videoViews)
        {
            List<int> avgViewsCount = new List<int>();
            foreach (var views in videoViews)
            {
                string view = views.InnerText;
                if (view.EndsWith('K'))
                {
                    avgViewsCount.Add(ViewsHaveKEnding(view));
                }
                else if (view.EndsWith('M'))
                {
                    avgViewsCount.Add(ViewsHaveMEnding(view));
                }
                else avgViewsCount.Add(Convert.ToInt32(view));
            }  
            return (int)avgViewsCount.Average();
        }
        public int ViewsHaveKEnding(string views)
        {
            int num;
            bool containDot = true;
            if (!views.Contains('.'))
            {
                containDot = true;
            }
            if (int.TryParse(views.Replace(".", "").Replace("K", ""), out num))
            {
                num = containDot ? num *= 100 : num *= 1000;
            }
            return num;
        }
        public int ViewsHaveMEnding(string views)
        {
            int num;
            bool containDot = true;
            if (!views.Contains('.'))
            {
                containDot = true;
            }
            if (int.TryParse(views.Replace(".", "").Replace("M", ""), out num))
            {
                num = containDot ? num *= 100000 : num *= 1000000;
            }
            return num;
        }
    }
}
