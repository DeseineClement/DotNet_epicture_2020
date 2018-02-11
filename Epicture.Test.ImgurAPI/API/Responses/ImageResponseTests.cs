using Epicture.ImgurAPI.API.Responses;
using Moq;
using System;
using System.Collections.Generic;
using Epicture.ImgurAPI.API.Models;
using Xunit;

namespace Epicture.Test.ImgurAPI.API.Responses
{
    public class ImageResponseTests : IDisposable
    {
        private MockRepository mockRepository;



        public ImageResponseTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        public void Dispose()
        {
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void TestDataSet()
        {
            // Arrange
            var testValue = new List<Image> { new Image(), new Image() };

            // Act
            ImageResponse imageResponse = this.CreateImageResponse();
            imageResponse.data = testValue;

            // Assert
            Assert.Equal(imageResponse.data, testValue);
        }

        [Fact]
        public void TestSuccessSet()
        {
            // Arrange
            var testValue = true;

            // Act
            ImageResponse imageResponse = this.CreateImageResponse();
            imageResponse.success = testValue;

            // Assert
            Assert.Equal(imageResponse.success, testValue);
        }

        [Fact]
        public void TestStatusSet()
        {
            // Arrange
            var testValue = 20;

            // Act
            ImageResponse imageResponse = this.CreateImageResponse();
            imageResponse.status = 20;

            // Assert
            Assert.Equal(imageResponse.status, testValue);
        }

        private ImageResponse CreateImageResponse()
        {
            return new ImageResponse();
        }
    }
}
