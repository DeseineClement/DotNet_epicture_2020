# Epicture

.NET Image viewer, working with any image provider such as Imgur or Flickr.

## Overview

- Projects definitions
	- BaseAPI
		- `AAProviderAuthenticator`
		-  `AuthenticationResultBase`
		- `AAPIClient`
		- Summary
	- ImgurAPI/FlickrAPI
	- Epicture
- Simplified projects architecture
----------

### Projects

#### BaseAPI

BaseAPI is the base of any image provider.
Its core is made of two major components: The authenticator, and the client itself.

**AProviderAuthenticator**
```csharp
public abstract class AProviderAuthenticator
    {
        protected AProviderAuthenticator(string clientId, string clientSecret)
        {
            ClientId = clientId;
            ClientSecret = clientSecret;
        }

        public string ClientId { get;  }
        public string ClientSecret { get; }

        //Return the token and the client
        public abstract Task<AuthenticationResultBase> Authenticate(string pinCode);
    }
```

Any new provider has to implement this base class in order to execute the authentication.

**AuthenticationResultBase.cs**
```csharp
public class AuthenticationResultBase
    {
       public AAPIClient APIClient { get; set; }
       public bool Success { get; set; } 
       public string Error { get; set; }
    }
```

Once the authentication is done, the method `Authenticate` then returns an `AuthenticationResultBase` instances, containing whether the authencation succeded or not, along with the client (`AApiClient`) used to fetch data from that provider.

**AAPIClient.cs**

```csharp
public abstract class AAPIClient
    {
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
    }
```

The `AAPIClient` contains a load of method to implement for Epicture to work properly.

- `Get`, `Post` and `Delete` are the base http methods. You can use them to include any necessary http headers, such as your access token (eg: `Authorization: Bearer <access_token>`)

- `Search` is the method used to search any picture for a provider
- `FetchHomeImages` is the method called when authentication succeeded. It fetches all the images to display for the home tab.
- `AddImageToFavorite` and `FetchFavoriteImages` are the images relative to favourites.
- `AddUserImage` and `RemoveUserImage` handles uploading/deleting images from that provider.

**In a nutshell:**
Any new provider must implement the `AProviderAuthenticator`  base class with the method `Authenticate`, providing an `AAPIClient` if the authentication succeeded. The `AAPIClient` is then used to fetch all the data throught the application


----------


#### ImgurAPI/FlickrAPI

Those two projects are implementations of providers, working as examples.

**ImgurAPI**

- `ImgurAuthenticator` is the `AProviderAuthenticator` imgur implementation
- `ImgurAuthenticationResult` is the `AuthenticationResultBase` imgur implementation
- `ImgurClient` is the  `AAPIClient` imgur implementation

----------


#### Epicture

This project is the UI implementation, working with both `ImgurAPI` and `FlickrAPI`.


----------
