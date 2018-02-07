using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Epicture.BaseAPI;
using Epicture.ImgurAPI.API;
using Newtonsoft.Json;

namespace Epicture.ImgurAPI
{
    public class ImgurAuthenticator : AProviderAuthenticator
    {
        public ImgurAuthenticator(string clientId, string clientSecret) : base(clientId, clientSecret)
        {}

        public override async Task<AuthenticationResultBase> Authenticate(string pinCode)
        {
            using (HttpClient client = new HttpClient())
            {
                var values = new Dictionary<string, string>
                {
                    { "client_id", this.ClientId },
                    { "client_secret", this.ClientSecret },
                    { "grant_type", "pin" },
                    { "pin", pinCode }
                };
                var content = new FormUrlEncodedContent(values);
                var response = await client.PostAsync("https://api.imgur.com/oauth2/token", content);
                string ret = await response.Content.ReadAsStringAsync();

                ImgurAuthenticationResult imgurAuthResult = JsonConvert.DeserializeObject<ImgurAuthenticationResult>(ret);
                if (imgurAuthResult.account_id != 0)
                {
                    var imgurClient = new ImgurClient(imgurAuthResult.access_token);
                    return new AuthenticationResultBase()
                    {
                        APIClient = imgurClient,
                        Success = true,
                        Error = String.Empty
                    };
                }
                else
                {
                    return new AuthenticationResultBase()
                    {
                        APIClient = null,
                        Success = false,
                        Error = "Invalid PIN Code."
                    };
                }
            }
        }
    }
}
