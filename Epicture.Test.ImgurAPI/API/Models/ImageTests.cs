using Epicture.ImgurAPI.API.Models;
using Moq;
using System;
using Xunit;

namespace Epicture.Test.ImgurAPI.API.Models
{
    public class ImageTests : IDisposable
    {
        private MockRepository mockRepository;



        public ImageTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        public void Dispose()
        {
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void TestDateTimeSet()
        {
            // Arrange
            var testValue = 20;

            // Act
            Image image = this.CreateImage();
            image.datetime = testValue;

            // Assert
            Assert.Equal(testValue, image.datetime);
        }

        [Fact]
        public void TestDescriptionSet()
        {
            // Arrange
            var testValue = "TestValue";

            // Act
            Image image = this.CreateImage();
            image.description = testValue;

            // Assert
            Assert.Equal(testValue, image.description);
        }

        [Fact]
        public void TestFavoriteSet()
        {
            // Arrange
            var testValue = true;

            // Act
            Image image = this.CreateImage();
            image.favorite = testValue;

            // Assert
            Assert.Equal(testValue, image.favorite);
        }

        [Fact]
        public void TestIdSet()
        {
            // Arrange
            var testValue = "testValue";

            // Act
            Image image = this.CreateImage();
            image.id = testValue;

            // Assert
            Assert.Equal(testValue, image.id);
        }

        [Fact]
        public void TestInGallerySet()
        {
            // Arrange
            var testValue = true;

            // Act
            Image image = this.CreateImage();
            image.in_gallery = testValue;

            // Assert
            Assert.Equal(testValue, image.in_gallery);
        }

        [Fact]
        public void TestLinkSet()
        {
            // Arrange
            var testValue = "TestValue";

            // Act
            Image image = this.CreateImage();
            image.link = testValue;

            // Assert
            Assert.Equal(testValue, image.link);
        }

        [Fact]
        public void TestNsfwSet()
        {
            // Arrange
            var testValue = true;

            // Act
            Image image = this.CreateImage();
            image.nsfw = testValue;

            // Assert
            Assert.Equal(testValue, image.nsfw);
        }

        [Fact]
        public void TestTitleSet()
        {
            // Arrange
            var testValue = "TestValue";

            // Act
            Image image = this.CreateImage();
            image.title = testValue;

            // Assert
            Assert.Equal(testValue, image.title);
        }

        [Fact]
        public void TestViewsSet()
        {
            // Arrange
            var testValue = 20;

            // Act
            Image image = this.CreateImage();
            image.views = testValue;

            // Assert
            Assert.Equal(testValue, image.views);
        }

        [Fact]
        public void TestVoteSet()
        {
            // Arrange
            var testValue = "TestValue";

            // Act
            Image image = this.CreateImage();
            image.vote = testValue;

            // Assert
            Assert.Equal(testValue, image.vote);
        }

        private Image CreateImage()
        {
            return new Image();
        }
    }
}
