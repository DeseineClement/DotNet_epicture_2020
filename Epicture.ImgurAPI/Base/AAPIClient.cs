using Epicture.ImgurAPI.Enums;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Epicture.ImgurAPI
{
    public abstract class AAPIClient
    {
        protected string AccessToken { get; set; }

        public AAPIClient(string accessToken)
        {
            this.AccessToken = accessToken;
        }

        protected abstract Task<string> Get(string url);
        protected abstract Task<string> Post(string url);
        protected abstract Task<string> Delete(string url);

        public abstract Task<PicturesResult> Search(string query, string file_type, string sort, string size);
        public abstract Task<PicturesResult> FetchHomeImages();

        public abstract Task AddImageToFavorite(PictureResult selectedPicture);
        public abstract Task RemoveImageFromFavorite(PictureResult selectedPicture);
        public abstract Task<PicturesResult> FetchFavoriteImages();
    }
}
