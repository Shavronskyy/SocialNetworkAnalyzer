using HtmlAgilityPack;
using SocialAnalyzer.models;
using SocialNetworkAnalyzer.Models;

namespace SocialNetworkAnalyzer.Services.Instagram
{
    public class GetMainInstagramInfo
    {
        public static async Task<InstagramUser> GetName(string url)
        {
            InstagramUser user = new InstagramUser();
            try
            {
                HtmlWeb web = new HtmlWeb();
                HtmlDocument doc = web.Load(url);
                //user.userImg = doc.DocumentNode.SelectNodes(".//img[@class='x6umtig x1b1mbwd xaqea5y xav7gou xk390pu x5yr21d xpdipgo xdj266r x11i5rnm xat24cr x1mh8g0r xexx8yu x4uap5 x18d9i69 xkhd6sd x11njtxf xh8yej3']")
                //    .First()
                //    .Attributes["src"].Value;
                user.userName = doc.DocumentNode.SelectSingleNode(".//div[@class='x6s0dn4 x78zum5 x1q0g3np xs83m0k xeuugli x1n2onr6']//h2[@class='x1lliihq x1plvlek xryxfnj x1n2onr6 x193iq5w xeuugli x1fj9vlw x13faqbe x1vvkbs x1s928wv xhkezso x1gmr53x x1cpjm7i x1fgarty x1943h6x x1i0vuye x1ms8i2q xo1l8bm x5n08af x10wh9bi x1wdrske x8viiok x18hxmgj']").InnerText;
                //user.userDescription = doc.DocumentNode.SelectSingleNode(".//div[@class='col-12 col-sm-7 col-md-8 col-lg-6']//p[@class='card-text mt-3']").InnerText;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return user;
        }
    }
}
