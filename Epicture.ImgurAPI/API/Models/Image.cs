using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Epicture.ImgurAPI.API.Models
{
    public class Image
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
        public string name { get; set; }
        public string section { get; set; }
        public string link { get; set; }
        public string gifv { get; set; }
        public string mp4 { get; set; }
        public int mp4_size { get; set; }
        public bool looping { get; set; }
        public bool favorite { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool nsfw { get; set; }
        public string vote { get; set; }
        public bool in_gallery { get; set; }
    }
}
