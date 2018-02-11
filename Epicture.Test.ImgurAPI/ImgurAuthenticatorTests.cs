using Epicture.ImgurAPI;
using Moq;
using System;
using Xunit;

namespace Epicture.Test.ImgurAPI
{
    public class ImgurAuthenticatorTests : IDisposable
    {
        private MockRepository mockRepository;



        public ImgurAuthenticatorTests()
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
            ImgurAuthenticator flickrAuthenticator = this.CreateImgurAuthenticator(clientIdTest, "");

            // Assert
            Assert.Equal(clientIdTest, flickrAuthenticator.ClientId);
        }

        [Fact]
        public void TestClientSecretSet()
        {
            // Arrange
            var clientSecretTest = "ClientSecretTest";

            // Act
            ImgurAuthenticator flickrAuthenticator = this.CreateImgurAuthenticator("", clientSecretTest);

            // Assert
            Assert.Equal(clientSecretTest, flickrAuthenticator.ClientSecret);
        }

        private ImgurAuthenticator CreateImgurAuthenticator(string clientId, string clientSecret)
        {
            return new ImgurAuthenticator(
                clientId,
                clientSecret);
        }
    }
}
