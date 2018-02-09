using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.ServiceModel.Security;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Web.Http;
using Epicture.ImgurAPI.Enums;
using Epicture.ImgurAPI.API.Models;
using Epicture.ImgurAPI.API.Responses;
using Newtonsoft.Json;
using HttpClient = System.Net.Http.HttpClient;
using HttpResponseMessage = System.Net.Http.HttpResponseMessage;

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
                using (HttpResponseMessage response = await client.GetAsync(new Uri(url)))
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
                using (HttpResponseMessage response = await client.DeleteAsync(new Uri(url)))
                {
                    using (HttpContent content = response.Content)
                    {
                        ret = await content.ReadAsStringAsync();
                    }
                }
            }
            return ret;
        }

        protected override async Task<string> Post(string url, HttpContent data)
        {
            string ret;
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", this.AccessToken);
                using (HttpResponseMessage response = await client.PostAsync(new Uri(url), data))
                {
                    using (HttpContent content = response.Content)
                    {
                        ret = await content.ReadAsStringAsync();
                    }
                }
            }

            return ret;
        }

        private static PicturesResult FormatResponseToPictureResult(GallerySearchResponse response)
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

        private static PicturesResult FormatResponseToPictureResult(ImageResponse response)
        {
            List<PictureResult> picturesResults = response.data.ToList().Select(image =>
            {
                return new  PictureResult()
                {
                    Name = image.title,
                    Description = image.description,
                    Height = image.height,
                    Width = image.width,
                    Id = image.id,
                    Url = image.link
                };
            }).ToList();

            return new PicturesResult()
            {
                Result = picturesResults,
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

            return FormatResponseToPictureResult(response);
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

            return FormatResponseToPictureResult(response);
        }

        public override async Task<string> AddImageToFavorite(PictureResult selectedPicture)
        {
            OnFavoriteAdding(selectedPicture);
            var ret = await this.Post($"https://api.imgur.com/3/image/{selectedPicture.Id}/favorite", null);
            OnFavoriteAdded(selectedPicture);

            return ret;
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

            return FormatResponseToPictureResult(response);
        }

        public override async Task<PicturesResult> FetchUserImages()
        {
            string jsonString = await this.Get($"https://api.imgur.com/3/account/{this.UserName}/images/");

            ImageResponse response = JsonConvert.DeserializeObject<ImageResponse>(jsonString);

            if (!response.success)
            {
                return new PicturesResult()
                {
                    Result = null,
                    Success = false
                };
            }

            return FormatResponseToPictureResult(response);
        }

        public override async Task<string> AddUserImage(LocalPictureResult picture)
        {
            Stream stream = await picture.File.OpenStreamForReadAsync();
            
            MultipartFormDataContent dataContent = new MultipartFormDataContent();

            dataContent.Add(new StreamContent(stream), "image", picture.File.Name);
            dataContent.Add(new StringContent(picture.File.Name), "name");
            if (!String.IsNullOrEmpty(picture.Name) && !String.IsNullOrWhiteSpace(picture.Name))
                dataContent.Add(new StringContent(picture.Name), "title");
            if (!String.IsNullOrEmpty(picture.Description) && !String.IsNullOrWhiteSpace(picture.Description))
                dataContent.Add(new StringContent(picture.Description), "title");

            OnFileUploading(picture);
            var ret = await this.Post("https://api.imgur.com/3/upload", dataContent);
            OnFileUploaded(picture);

            return ret;
        }

        public override async Task<string> RemoveUserImage(PictureResult selectedPicture)
        {
            OnUserFileDeleting(selectedPicture);
            var ret =  await this.Delete($"https://api.imgur.com/3/image/{selectedPicture.Id}");
            OnUserFileDeleted(selectedPicture);

            return ret;
        }
    }
}
