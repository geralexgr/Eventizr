using eventizr.Models;
using eventizr.Services;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace eventizr.Helpers
{
    public class StringsHelper
    {

       
        public string CreateTokenRequestUrl() {
			var url = "https://graph.facebook.com/oauth/access_token?" +
                "client_id=" +  Constants.Messages.FB_APP_ID +
			"&client_secret=" + Constants.Messages.FB_APP_SECRET +
			"&grant_type=client_credentials";
            return url;
        }


        public async Task<string> CreatePageRequestUrl(string page) {
            FbToken token = await new FbService().GetFbToken();
            if (token != null)
            {
                var url = "https://graph.facebook.com/" + page + "?fields=id,link,name,about,category,single_line_address,picture.width(600).height(600)" + "&access_token=" + token.AccessToken;
                return url;
            } else
            {
                return "error";
            }
            
        }

        public async Task<string> CreateEventsRequest(string page)
        {
            FbToken token = await new FbService().GetFbToken();

            if (token != null)
            {
                DateTime dtime = DateTime.Now.AddHours(-7);
                //DateTime dtime = DateTime.Today.AddHours(-2);
                long timeStamp = ((DateTimeOffset)dtime).ToUnixTimeSeconds();

                var url = "https://graph.facebook.com/" + page + "/events" +
                    "?fields=description,id,name,start_time,cover,owner,place" +
                    "&since=" + timeStamp + "&access_token=" + token.AccessToken; 
                return url;
            }
            else
            {
                return "error";
            }
           

        }



        public string FbPageRegex(string url)
        {
            if (url[url.Length - 1] != '/') url = url + "/";

            Regex regex = new Regex(@"facebook.com\/[^\s]+\/", RegexOptions.None);
            Match match = regex.Match(url);
            if (match.Success)
            {
                if (match.Value.Equals("facebook.com/"))
                {
                    return "error";
                } else
                {
                    var page = match.Value.Replace("facebook.com/", "");
                    page = page.Replace("/", "");
                    if (page.Contains("?")) page = page.Substring(0, page.IndexOf("?"));                                       
                    return page;
                }
            } else
            {
                return "error";
            }
        }

    }
}
