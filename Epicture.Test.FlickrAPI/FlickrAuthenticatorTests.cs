using Epicture.FlickrAPI;
using Moq;
using System;
using Epicture.BaseAPI;
using Xunit;

namespace Epicture.Test.FlickrAPI
{
    public class FlickrAuthenticatorTests : IDisposable
    {
        private MockRepository mockRepository;



        public FlickrAuthenticatorTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        public void Dispose()
        {
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void TestClientIdSet()
        {
            // Arrange
            var clientIdTest = "ClientIdTest";

            // Act
            FlickrAuthenticator flickrAuthenticator = this.CreateFlickrAuthenticator(clientIdTest, "");

            // Assert
            Assert.Equal(clientIdTest, flickrAuthenticator.ClientId);
        }

        [Fact]
        public void TestClientSecretSet()
        {
            // Arrange
            var clientSecretTest = "ClientSecretTest";

            // Act
            FlickrAuthenticator flickrAuthenticator = this.CreateFlickrAuthenticator("", clientSecretTest);

            // Assert
            Assert.Equal(clientSecretTest, flickrAuthenticator.ClientSecret);
        }

        private FlickrAuthenticator CreateFlickrAuthenticator(string clientId, string clientSecret)
        {
            return new FlickrAuthenticator(
                clientId,
                clientSecret);
        }
    }
}
