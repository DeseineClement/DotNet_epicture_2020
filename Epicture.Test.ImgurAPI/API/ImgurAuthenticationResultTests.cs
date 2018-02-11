using Epicture.ImgurAPI.API;
using Moq;
using System;
using Xunit;

namespace Epicture.Test.ImgurAPI.API
{
    public class ImgurAuthenticationResultTests : IDisposable
    {
        private MockRepository mockRepository;



        public ImgurAuthenticationResultTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        public void Dispose()
        {
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void TestAccessTokenSet()
        {
            // Arrange
            var testValue = "TestValue";

            // Act
            ImgurAuthenticationResult imgurAuthenticationResult = this.CreateImgurAuthenticationResult();
            imgurAuthenticationResult.access_token = testValue;

            // Assert
            Assert.Equal(testValue, imgurAuthenticationResult.access_token);
        }

        [Fact]
        public void TestExpiresInSet()
        {
            // Arrange
            var testValue = 20;

            // Act
            ImgurAuthenticationResult imgurAuthenticationResult = this.CreateImgurAuthenticationResult();
            imgurAuthenticationResult.expires_in = testValue;

            // Assert
            Assert.Equal(testValue, imgurAuthenticationResult.expires_in);
        }

        [Fact]
        public void TestTokenTypeSet()
        {
            // Arrange
            var testValue = "TestValue";

            // Act
            ImgurAuthenticationResult imgurAuthenticationResult = this.CreateImgurAuthenticationResult();
            imgurAuthenticationResult.token_type = testValue;

            // Assert
            Assert.Equal(testValue, imgurAuthenticationResult.token_type);
        }

        [Fact]
        public void TestScopeSet()
        {
            // Arrange
            var testValue = new { Test1 = "Test", Test2 = 42};

            // Act
            ImgurAuthenticationResult imgurAuthenticationResult = this.CreateImgurAuthenticationResult();
            imgurAuthenticationResult.scope = testValue;

            // Assert
            Assert.Equal(testValue, imgurAuthenticationResult.scope);
        }

        [Fact]
        public void TestRefreshTokenSet()
        {
            // Arrange
            var testValue = "TestValue";

            // Act
            ImgurAuthenticationResult imgurAuthenticationResult = this.CreateImgurAuthenticationResult();
            imgurAuthenticationResult.refresh_token = testValue;

            // Assert
            Assert.Equal(testValue, imgurAuthenticationResult.refresh_token);
        }

        [Fact]
        public void TestAccountIdSet()
        {
            // Arrange
            var testValue = 20;

            // Act
            ImgurAuthenticationResult imgurAuthenticationResult = this.CreateImgurAuthenticationResult();
            imgurAuthenticationResult.account_id = testValue;

            // Assert
            Assert.Equal(testValue, imgurAuthenticationResult.account_id);
        }

        [Fact]
        public void TestAccountUsernameSet()
        {
            // Arrange
            var testValue = "TestValue";

            // Act
            ImgurAuthenticationResult imgurAuthenticationResult = this.CreateImgurAuthenticationResult();
            imgurAuthenticationResult.account_username = testValue;

            // Assert
            Assert.Equal(testValue, imgurAuthenticationResult.account_username);
        }

        private ImgurAuthenticationResult CreateImgurAuthenticationResult()
        {
            return new ImgurAuthenticationResult();
        }
    }
}
