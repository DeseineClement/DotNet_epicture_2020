using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Epicture.ImgurAPI.API.Models
{
    public class GallerySearch
    {
        public string id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public int datetime { get; set; }
        public string type { get; set; }
        public bool animated { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public int size { get; set; }
        public int views { get; set; }
        public double bandwidth { get; set; }
        public string deletehash { get; set; }
        public string link { get; set; }
        public string gifv { get; set; }
        public string mp4 { get; set; }
        public int mp4_size { get; set; }
        public bool looping { get; set; }
        public string vote { get; set; }
        public bool favorite { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool nsfw { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int comment_count { get; set; }
        public string topic { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int topic_id { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string section { get; set; }
        public string account_url { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int account_id { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int ups { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int downs { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int points { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int score { get; set; }
        public bool is_album { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<Image> images { get; set; }
    }
}
