using Epicture.BaseAPI;

namespace Epicture.FlickrAPI
{
    public class PictureQueryBuilder: APictureQueryBuilder
    {
        public PictureQueryBuilder(string clientId, string clientSecret) : base(clientId, clientSecret)
        {
        }

        public override PictureResult[] Get(PictureParameters parameters)
        {
            return new PictureResult[] { };
        }
    }
}
