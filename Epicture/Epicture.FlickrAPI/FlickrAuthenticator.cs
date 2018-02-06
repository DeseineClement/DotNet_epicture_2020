using System.Collections.Generic;
using System.Threading.Tasks;
using Epicture.BaseAPI;

namespace Epicture.FlickrAPI
{
    public class FlickrAuthenticator: AProviderAuthenticator
    {
        public FlickrAuthenticator(string clientId, string clientSecret) : base(clientId, clientSecret)
        {
        }

        public override async Task<AuthenticationResultBase> Authenticate(string pinCode)
        {
            throw new System.NotImplementedException();
        }
    }
}
