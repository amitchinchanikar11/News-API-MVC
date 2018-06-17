using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiProject.Models
{
    public class NewsDataModel
    {
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }
        [JsonProperty(PropertyName = "section")]
        public string Section { get; set; }
        [JsonProperty(PropertyName = "subsection")]
        public string Subsection { get; set; }
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }
        [JsonProperty(PropertyName = "updated_date")]
        public string Updated_date { get; set; }
    }
}