using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Epicture.ImgurAPI.API.Models
{
    public class GalleryAlbum
    {
        public string id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public int datetime { get; set; }
        public string cover { get; set; }
        public int cover_width { get; set; }
        public int cover_height { get; set; }
        public string account_url { get; set; }
        public int account_id { get; set; }
        public string privacy { get; set; }
        public string layout { get; set; }
        public int views { get; set; }
        public string link { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int ups { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int downs { get; set; }
        public int points { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int score { get; set; }
        public bool is_album { get; set; }
        public string vote { get; set; }
        public bool favorite { get; set; }
        public bool nsfw { get; set; }
        public int comment_count { get; set; }
        public string topic { get; set; }
        public int topic_id { get; set; }
        public int images_count { get; set; }
        public List<Image> images { get; set; }
        public bool in_gallery { get; set; }
    }
}
