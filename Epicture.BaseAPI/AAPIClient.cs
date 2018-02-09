using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Epicture.BaseAPI
{
    public abstract class AAPIClient
    {
        public event EventHandler<LocalPictureResult> FileUploading;
        public event EventHandler<LocalPictureResult> FileUploaded;

        public event EventHandler<PictureResult> UserFileDeleting;
        public event EventHandler<PictureResult> UserFileDeleted;

        public event EventHandler<PictureResult> FavoriteAdding;
        public event EventHandler<PictureResult> FavoriteAdded;
        protected string AccessToken { get; set; }
        public string UserName { get; set; }

        protected AAPIClient(string accessToken, string userName)
        {
            this.AccessToken = accessToken;
            this.UserName = userName;
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

        protected virtual void OnFileUploading(LocalPictureResult e) => FileUploading?.Invoke(this, e);
        protected virtual void OnFileUploaded(LocalPictureResult e) => FileUploaded?.Invoke(this, e);

        protected virtual void OnUserFileDeleting(PictureResult e) => UserFileDeleting?.Invoke(this, e);
        protected virtual void OnUserFileDeleted(PictureResult e) => UserFileDeleted?.Invoke(this, e);

        protected virtual void OnFavoriteAdding(PictureResult e) => FavoriteAdding?.Invoke(this, e);
        protected virtual void OnFavoriteAdded(PictureResult e) => FavoriteAdded?.Invoke(this, e);
    }
}
