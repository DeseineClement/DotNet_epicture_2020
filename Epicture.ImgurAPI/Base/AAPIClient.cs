﻿using Epicture.ImgurAPI.Enums;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace Epicture.ImgurAPI
{
    public abstract class AAPIClient
    {
        public event EventHandler<LocalPictureResult> FileUploading;
        public event EventHandler<LocalPictureResult> FileUploaded; 
        protected string AccessToken { get; set; }

        public AAPIClient(string accessToken)
        {
            this.AccessToken = accessToken;
        }

        protected abstract Task<string> Get(string url);
        protected abstract Task<string> Post(string url, HttpContent data);
        protected abstract Task<string> Delete(string url);

        public abstract Task<PicturesResult> Search(string query, string file_type, string sort, string size);
        public abstract Task<PicturesResult> FetchHomeImages();

        public abstract Task<string> AddImageToFavorite(PictureResult selectedPicture);
        public abstract Task<PicturesResult> FetchFavoriteImages();

        public abstract Task<PicturesResult> FetchUserImages();
        public abstract Task<string> AddUserImage(LocalPictureResult picture);
        public abstract Task<string> RemoveUserImage(PictureResult selectedPicture);

        protected virtual void OnFileUploading(LocalPictureResult e)
        {
            FileUploading?.Invoke(this, e);
        }

        protected virtual void OnFileUploaded(LocalPictureResult e)
        {
            FileUploaded?.Invoke(this, e);
        }
    }
}
