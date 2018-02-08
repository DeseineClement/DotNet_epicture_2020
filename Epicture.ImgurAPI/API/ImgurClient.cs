using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.ServiceModel.Security;
using System.Text;
using System.Threading.Tasks;
using Epicture.ImgurAPI.Enums;
using Epicture.ImgurAPI.API.Models;
using Epicture.ImgurAPI.API.Responses;
using Newtonsoft.Json;

namespace Epicture.ImgurAPI.API
{
    public class ImgurClient : AAPIClient
    {
        protected string UserName { get; set; }

        private static Dictionary<FILE_TYPE, string> fileTypes = new Dictionary<FILE_TYPE, string>()
        {
            {FILE_TYPE.JPG, "jpg"},
            {FILE_TYPE.PNG, "png"},
            {FILE_TYPE.GIF, "gif"}
        };

        private static Dictionary<SORT_TYPE, string> sortTypes = new Dictionary<SORT_TYPE, string>()
        {
            {SORT_TYPE.TIME, "time"},
            {SORT_TYPE.TOP, "top"},
            {SORT_TYPE.VIRAL, "viral"}
        };

        public ImgurClient(string accessToken, string userName) : base(accessToken)
        {
            UserName = userName;
        }

        protected override async Task<string> Get(string url)
        {
            string ret;
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", this.AccessToken);
                using (HttpResponseMessage response = await client.GetAsync(url))
                {
                    using (HttpContent content = response.Content)
                    {
                        ret = await content.ReadAsStringAsync();
                    }
                }
            }

            return ret;
        }

        protected override async Task<string> Delete(string url)
        {
            string ret;
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", this.AccessToken);
                using (HttpResponseMessage response = await client.DeleteAsync(url))
                {
                    using (HttpContent content = response.Content)
                    {
                        ret = await content.ReadAsStringAsync();
                    }
                }
            }
            return ret;
        }

        protected override async Task<string> Post(string url)
        {
            string ret;
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", this.AccessToken);
                using (HttpResponseMessage response = await client.PostAsync(url, null))
                {
                    using (HttpContent content = response.Content)
                    {
                        ret = await content.ReadAsStringAsync();
                    }
                }
            }

            return ret;
        }

        private static PicturesResult FormatGalleryResponseToPictureResult(GallerySearchResponse response)
        {
            List<PictureResult> picturesResult = response.data.ToList().Select(image =>
            {
                string url = image.is_album
                    ? image.images[0].link
                    : image.link;

                string id = image.is_album
                    ? image.images[0].id
                    : image.id;

                return new PictureResult()
                {
                    Name = image.title,
                    Description = image.description,
                    Height = image.height,
                    Width = image.width,
                    Url = url,
                    Id = id
                };
            }).ToList();

            return new PicturesResult()
            {
                Result = picturesResult,
                Success = true
            };
        }

        public override async Task<PicturesResult> Search(string query, string fileType, string sortType, string size)
        {
            if (String.IsNullOrEmpty(query))
            {
                throw new Exception("Query param cannot be empty.");
            }
            StringBuilder uri = new StringBuilder("https://api.imgur.com/3/gallery/search");
            uri.AppendFormat("/{0}?", WebUtility.UrlEncode(sortType));
            uri.AppendFormat("q_any={0}", WebUtility.UrlEncode(query));
            if (!String.Equals(fileType, "any file format"))
            {
                uri.AppendFormat("&q_type={0}", WebUtility.UrlEncode(fileType));
            }

            if (!String.Equals(size, "any size"))
            {
                uri.AppendFormat("&q_size_px={0}", WebUtility.UrlEncode(size));
            }

            string jsonString = await this.Get(uri.ToString());

            GallerySearchResponse response = JsonConvert.DeserializeObject<GallerySearchResponse>(jsonString);

            if (!response.success)
            {
                return new PicturesResult() {
                    Result = null,
                    Success = false
                };
            }

            return FormatGalleryResponseToPictureResult(response);
        }

        public override async Task<PicturesResult> FetchHomeImages()
        {
            string jsonString = await this.Get("https://api.imgur.com/3/gallery/hot/viral/");

            GallerySearchResponse response = JsonConvert.DeserializeObject<GallerySearchResponse>(jsonString);

            if (!response.success)
            {
                return new PicturesResult()
                {
                    Result = null,
                    Success = false
                };
            }

            return FormatGalleryResponseToPictureResult(response);
        }

        public override async Task AddImageToFavorite(PictureResult selectedPicture)
        {
            await this.Post($"https://api.imgur.com/3/image/{selectedPicture.Id}/favorite");
        }

        public override async Task RemoveImageFromFavorite(PictureResult selectedPicture)
        {
            await this.Delete($"https://api.imgur.com/3/image/{selectedPicture.Id}/favorite");
        }

        public override async Task<PicturesResult> FetchFavoriteImages()
        {
            string jsonString = await this.Get($"https://api.imgur.com/3/account/{this.UserName}/favorites/");

            GallerySearchResponse response = JsonConvert.DeserializeObject<GallerySearchResponse>(jsonString);

            if (!response.success)
            {
                return new PicturesResult()
                {
                    Result = null,
                    Success = false
                };
            }

            return FormatGalleryResponseToPictureResult(response);
        }
    }
}
