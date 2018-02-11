using Epicture.ImgurAPI.API.Models;
using Moq;
using System;
using Xunit;

namespace Epicture.Test.ImgurAPI.API.Models
{
    public class GalleryImageTests : IDisposable
    {
        private MockRepository mockRepository;



        public GalleryImageTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        public void Dispose()
        {
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void TestAccountIdSet()
        {
            // Arrange
            var testValue = 20;

            // Act
            GalleryImage galleryImage = this.CreateGalleryImage();
            galleryImage.account_id = testValue;

            // Assert
            Assert.Equal(testValue, galleryImage.account_id);
        }

        [Fact]
        public void TestAccountUrlSet()
        {
            // Arrange
            var testValue = "testValue";

            // Act
            GalleryImage galleryImage = this.CreateGalleryImage();
            galleryImage.account_url = testValue;

            // Assert
            Assert.Equal(testValue, galleryImage.account_url);
        }

        [Fact]
        public void TestCommentCountSet()
        {
            // Arrange
            var testValue = 20;

            // Act
            GalleryImage galleryImage = this.CreateGalleryImage();
            galleryImage.comment_count = testValue;

            // Assert
            Assert.Equal(testValue, galleryImage.comment_count);
        }

        [Fact]
        public void TestDateTimeSet()
        {
            // Arrange
            var testValue = 20;

            // Act
            GalleryImage galleryImage = this.CreateGalleryImage();
            galleryImage.datetime = testValue;

            // Assert
            Assert.Equal(testValue, galleryImage.datetime);
        }

        [Fact]
        public void TestDescriptionSet()
        {
            // Arrange
            var testValue = "TestValue";

            // Act
            GalleryImage galleryImage = this.CreateGalleryImage();
            galleryImage.description = testValue;

            // Assert
            Assert.Equal(testValue, galleryImage.description);
        }

        [Fact]
        public void TestDownsSet()
        {
            // Arrange
            var testValue = 20;

            // Act
            GalleryImage galleryImage = this.CreateGalleryImage();
            galleryImage.downs = testValue;

            // Assert
            Assert.Equal(testValue, galleryImage.downs);
        }

        [Fact]
        public void TestFavoriteSet()
        {
            // Arrange
            var testValue = true;

            // Act
            GalleryImage galleryImage = this.CreateGalleryImage();
            galleryImage.favorite = testValue;

            // Assert
            Assert.Equal(testValue, galleryImage.favorite);
        }

        [Fact]
        public void TestIdSet()
        {
            // Arrange
            var testValue = "testValue";

            // Act
            GalleryImage galleryImage = this.CreateGalleryImage();
            galleryImage.id = testValue;

            // Assert
            Assert.Equal(testValue, galleryImage.id);
        }

        [Fact]
        public void TestIsAlbumSet()
        {
            // Arrange
            var testValue = true;

            // Act
            GalleryImage galleryImage = this.CreateGalleryImage();
            galleryImage.is_album = testValue;

            // Assert
            Assert.Equal(testValue, galleryImage.is_album);
        }

        [Fact]
        public void TestLinkSet()
        {
            // Arrange
            var testValue = "TestValue";

            // Act
            GalleryImage galleryImage = this.CreateGalleryImage();
            galleryImage.link = testValue;

            // Assert
            Assert.Equal(testValue, galleryImage.link);
        }

        [Fact]
        public void TestNsfwSet()
        {
            // Arrange
            var testValue = true;

            // Act
            GalleryImage galleryImage = this.CreateGalleryImage();
            galleryImage.nsfw = testValue;

            // Assert
            Assert.Equal(testValue, galleryImage.nsfw);
        }

        [Fact]
        public void TestPointsSet()
        {
            // Arrange
            var testValue = 20;

            // Act
            GalleryImage galleryImage = this.CreateGalleryImage();
            galleryImage.points = testValue;

            // Assert
            Assert.Equal(testValue, galleryImage.points);
        }

        [Fact]
        public void TestScoreSet()
        {
            // Arrange
            var testValue = 20;

            // Act
            GalleryImage galleryImage = this.CreateGalleryImage();
            galleryImage.score = testValue;

            // Assert
            Assert.Equal(testValue, galleryImage.score);
        }

        [Fact]
        public void TestTitleSet()
        {
            // Arrange
            var testValue = "TestValue";

            // Act
            GalleryImage galleryImage = this.CreateGalleryImage();
            galleryImage.title = testValue;

            // Assert
            Assert.Equal(testValue, galleryImage.title);
        }

        [Fact]
        public void TestTopicSet()
        {
            // Arrange
            var testValue = "TestValue";

            // Act
            GalleryImage galleryImage = this.CreateGalleryImage();
            galleryImage.topic = testValue;

            // Assert
            Assert.Equal(testValue, galleryImage.topic);
        }

        [Fact]
        public void TestTopicIdSet()
        {
            // Arrange
            var testValue = 20;

            // Act
            GalleryImage galleryImage = this.CreateGalleryImage();
            galleryImage.topic_id = testValue;

            // Assert
            Assert.Equal(testValue, galleryImage.topic_id);
        }

        [Fact]
        public void TestUpsSet()
        {
            // Arrange
            var testValue = 20;

            // Act
            GalleryImage galleryAlbum = this.CreateGalleryImage();
            galleryAlbum.ups = testValue;

            // Assert
            Assert.Equal(testValue, galleryAlbum.ups);
        }

        [Fact]
        public void TestViewsSet()
        {
            // Arrange
            var testValue = 20;

            // Act
            GalleryImage galleryImage = this.CreateGalleryImage();
            galleryImage.views = testValue;

            // Assert
            Assert.Equal(testValue, galleryImage.views);
        }

        [Fact]
        public void TestVoteSet()
        {
            // Arrange
            var testValue = "TestValue";

            // Act
            GalleryImage galleryImage = this.CreateGalleryImage();
            galleryImage.vote = testValue;

            // Assert
            Assert.Equal(testValue, galleryImage.vote);
        }

        private GalleryImage CreateGalleryImage()
        {
            return new GalleryImage();
        }
    }
}
