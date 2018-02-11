using System;
using Epicture.BaseAPI;
using Moq;
using Xunit;

namespace Epicture.Test.BaseAPI
{
    public class AuthenticationResultBaseTests : IDisposable
    {
        private MockRepository mockRepository;



        public AuthenticationResultBaseTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        public void Dispose()
        {
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void TestErrorSet()
        {
            // Arrange
            var errorTest = "ErrorTest";

            // Act
            AuthenticationResultBase authenticationResultBase = this.CreateAuthenticationResultBase();
            authenticationResultBase.Error = errorTest;

            // Assert
            Assert.Equal(authenticationResultBase.Error, errorTest);
        }

        [Fact]
        public void TestSuccessSet()
        {
            // Arrange
            var successTest = true;

            // Act
            AuthenticationResultBase authenticationResultBase = this.CreateAuthenticationResultBase();
            authenticationResultBase.Success = successTest;

            // Assert
            Assert.Equal(authenticationResultBase.Success, successTest);
        }

        private AuthenticationResultBase CreateAuthenticationResultBase()
        {
            return new AuthenticationResultBase();
        }
    }
}
