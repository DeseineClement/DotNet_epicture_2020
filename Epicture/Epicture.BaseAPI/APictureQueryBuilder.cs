namespace Epicture.BaseAPI
{
    public abstract class APictureQueryBuilder
    {
        protected APictureQueryBuilder(string clientId, string clientSecret)
        {
            ClientId = clientId;
            ClientSecret = clientSecret;
        }

        public string ClientId { get;  }
        public string ClientSecret { get; }
        public abstract PictureResult[] Get(PictureParameters parameters);
    }
}
