using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebApiProject.Models;
using WebApiProject.Services;

namespace WebApiProject.Controllers
{
    public class NewsController : ApiController
    {
        // GET: api/News

        //public IHttpActionResult GetNewsData()
        //{
        //    var allnews = GetData();
        //    return Ok(allnews);
        //}
        [HttpGet]
        public async Task<List<NewsDataModel>> GetData()

        {
            var allNews = await NewsService.GetNews();
            return allNews.ToList();
        }
    }
}
