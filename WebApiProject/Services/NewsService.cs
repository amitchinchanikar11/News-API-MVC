using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Caching;
using System.Threading.Tasks;
using System.Web;

using WebApiProject.Models;

namespace WebApiProject.Services
{
    public class NewsService
    {
        const double CACHETIMEOUT = 240.0;

        public static async Task<List<NewsDataModel>> GetNews()
        {

            ObjectCache cache = MemoryCache.Default;
            var news = cache["NYCNews"] as List<NewsDataModel>;
            var apiUrl = "https://api.nytimes.com/svc/news/v3/content/all/all.json?api-key=ce54c880b23e4c8cb597cca5ec6189fe";

            if (news == null)
            {
                CacheItemPolicy policy = new CacheItemPolicy
                {
                    AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(CACHETIMEOUT)
                };
                using (HttpClient httpClient = new HttpClient())
                {
                    // Await the response from the cient API
                    HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        var jsonstring = await response.Content.ReadAsStringAsync();
                        var test = (JObject)JsonConvert.DeserializeObject(jsonstring);
                        news = JsonConvert.DeserializeObject<List<NewsDataModel>>(test["results"].ToString());
                    }

                }
                // And now cache the data
                cache.Set("NYCNews", news, policy);
            }
            return news;
        }

    }
}