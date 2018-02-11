using Epicture.ImgurAPI.API.Responses;
using Moq;
using System;
using System.Collections.Generic;
using Epicture.ImgurAPI.API.Models;
using Xunit;

namespace Epicture.Test.ImgurAPI.API.Responses
{
    public class GallerySearchResponseTests : IDisposable
    {
        private MockRepository mockRepository;



        public GallerySearchResponseTests()
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
            var testValue = new List<GallerySearch> {new GallerySearch(), new GallerySearch()};

            // Act
            GallerySearchResponse gallerySearchResponse = this.CreateGallerySearchResponse();
            gallerySearchResponse.data = testValue;

            // Assert
            Assert.Equal(gallerySearchResponse.data, testValue);
        }

        [Fact]
        public void TestSuccessSet()
        {
            // Arrange
            var testValue = true;

            // Act
            GallerySearchResponse gallerySearchResponse = this.CreateGallerySearchResponse();
            gallerySearchResponse.success = testValue;

            // Assert
            Assert.Equal(gallerySearchResponse.success, testValue);
        }

        [Fact]
        public void TestStatusSet()
        {
            // Arrange
            var testValue = 20;

            // Act
            GallerySearchResponse gallerySearchResponse = this.CreateGallerySearchResponse();
            gallerySearchResponse.status = 20;

            // Assert
            Assert.Equal(gallerySearchResponse.status, testValue);
        }

        private GallerySearchResponse CreateGallerySearchResponse()
        {
            return new GallerySearchResponse();
        }
    }
}
