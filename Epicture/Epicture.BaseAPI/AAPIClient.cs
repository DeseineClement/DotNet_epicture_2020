using Epicture.BaseAPI.Enums;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Epicture.BaseAPI
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

        public abstract Task<PicturesResult> Search(string query, FILE_TYPE file_type, SORT_TYPE sort);
        public abstract Task<PicturesResult> FetchHomeImages();
    }
}
