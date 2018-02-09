using System.Collections.Generic;
using System.Threading.Tasks;

namespace Epicture.BaseAPI
{
    public abstract class AProviderAuthenticator
    {
        protected AProviderAuthenticator(string clientId, string clientSecret)
        {
            ClientId = clientId;
            ClientSecret = clientSecret;
        }

        protected string ClientId { get;  }
        protected string ClientSecret { get; }

        //Return the token and the client
        public abstract Task<AuthenticationResultBase> Authenticate(string pinCode);
    }
}
