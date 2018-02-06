﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Epicture.BaseAPI;
using Epicture.BaseAPI.Enums;
using Epicture.ImgurAPI.API.Models;
using Epicture.ImgurAPI.API.Responses;

namespace Epicture.ImgurAPI.API
{
    public class ImgurClient : AAPIClient
    {

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

        public ImgurClient(string accessToken) : base(accessToken)
        { }

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

        protected override Task<string> Post(string url)
        {
            throw new NotImplementedException();
        }

        public override async Task<PicturesResult> Search(string query, FILE_TYPE fileType = FILE_TYPE.ALL, SORT_TYPE sortType = SORT_TYPE.TIME)
        {
            if (String.IsNullOrEmpty(query))
            {
                throw new Exception("Query param cannot be empty.");
            }
            StringBuilder uri = new StringBuilder("https://api.imgur.com/3/gallery/search");
            uri.AppendFormat("/{0}?", WebUtility.UrlEncode(sortType.ToString().ToLower()));
            uri.AppendFormat("q_any={0}", WebUtility.UrlEncode(query));
            if (fileType != FILE_TYPE.ALL)
            {
                uri.AppendFormat("&q_type={0}", WebUtility.UrlEncode(fileType.ToString().ToLower()));
            }
            string jsonString = await this.Get(uri.ToString());

            GallerySearchResponse response = JSON.Deserialize<GallerySearchResponse>(jsonString);

            if (!response.success)
            {
                return new PicturesResult() {
                    Result = null,
                    Success = false
                };
            }

            List<PictureResult> picturesResult = response.data.ToList().Select(image =>
            {
                string url = image.is_album
                    ? image.images[0].link
                    : image.link;

                return new PictureResult()
                {
                    Name = image.title,
                    Description = image.description,
                    Height = image.height,
                    Width = image.width,
                    Url = url
                };
            }).ToList();

            return new PicturesResult()
            {
                Result = picturesResult,
                Success = true
            };
        }

        public override async Task<PicturesResult> FetchHomeImages()
        {
            string jsonString = await this.Get("https://api.imgur.com/3/gallery/hot/viral/");

            GallerySearchResponse response = JSON.Deserialize<GallerySearchResponse>(jsonString);

            if (!response.success)
            {
                return new PicturesResult()
                {
                    Result = null,
                    Success = false
                };
            }

            List<PictureResult> picturesResult = response.data.ToList().Select(image =>
            {
                string url = image.is_album
                    ? image.images[0].link
                    : image.link;

                return new PictureResult()
                {
                    Name = image.title,
                    Description = image.description,
                    Height = image.height,
                    Width = image.width,
                    Url = url
                };
            }).ToList();

            return new PicturesResult()
            {
                Result = picturesResult,
                Success = true
            };
        }
    }
}
