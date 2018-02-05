using System;
using Epicture.BaseAPI;

namespace Epicture.ImgurAPI
{
    public class PictureQueryBuilder: APictureQueryBuilder
    {
        public PictureQueryBuilder(string clientId, string clientSecret) : base(clientId, clientSecret)
        {
        }
        public override PictureResult[] Get(PictureParameters parameters)
        {
           return new PictureResult[] {};
        }
    }
}
