using Epicture.ImgurAPI.API.Models;
using Moq;
using System;
using System.Collections.Generic;
using Epicture.BaseAPI;
using Xunit;

namespace Epicture.Test.ImgurAPI.API.Models
{
    public class GalleryAlbumTests : IDisposable
    {
        private MockRepository mockRepository;



        public GalleryAlbumTests()
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
            GalleryAlbum galleryAlbum = this.CreateGalleryAlbum();
            galleryAlbum.account_id = testValue;

            // Assert
            Assert.Equal(testValue, galleryAlbum.account_id);
        }

        [Fact]
        public void TestAccountUrlSet()
        {
            // Arrange
            var testValue = "testValue";

            // Act
            GalleryAlbum galleryAlbum = this.CreateGalleryAlbum();
            galleryAlbum.account_url = testValue;

            // Assert
            Assert.Equal(testValue, galleryAlbum.account_url);
        }

        [Fact]
        public void TestCommentCountSet()
        {
            // Arrange
            var testValue = 20;

            // Act
            GalleryAlbum galleryAlbum = this.CreateGalleryAlbum();
            galleryAlbum.comment_count = testValue;

            // Assert
            Assert.Equal(testValue, galleryAlbum.comment_count);
        }

        [Fact]
        public void TestCoverSet()
        {
            // Arrange
            var testValue = "TestValue";

            // Act
            GalleryAlbum galleryAlbum = this.CreateGalleryAlbum();
            galleryAlbum.cover = testValue;

            // Assert
            Assert.Equal(testValue, galleryAlbum.cover);
        }

        [Fact]
        public void TestCoverHeightSet()
        {
            // Arrange
            var testValue = 20;

            // Act
            GalleryAlbum galleryAlbum = this.CreateGalleryAlbum();
            galleryAlbum.cover_height = testValue;

            // Assert
            Assert.Equal(testValue, galleryAlbum.cover_height);
        }

        [Fact]
        public void TestCoverWidthSet()
        {
            // Arrange
            var testValue = 20;

            // Act
            GalleryAlbum galleryAlbum = this.CreateGalleryAlbum();
            galleryAlbum.cover_width = testValue;

            // Assert
            Assert.Equal(testValue, galleryAlbum.cover_width);
        }

        [Fact]
        public void TestDateTimeSet()
        {
            // Arrange
            var testValue = 20;

            // Act
            GalleryAlbum galleryAlbum = this.CreateGalleryAlbum();
            galleryAlbum.datetime = testValue;

            // Assert
            Assert.Equal(testValue, galleryAlbum.datetime);
        }

        [Fact]
        public void TestDescriptionSet()
        {
            // Arrange
            var testValue = "TestValue";

            // Act
            GalleryAlbum galleryAlbum = this.CreateGalleryAlbum();
            galleryAlbum.description = testValue;

            // Assert
            Assert.Equal(testValue, galleryAlbum.description);
        }

        [Fact]
        public void TestDownsSet()
        {
            // Arrange
            var testValue = 20;

            // Act
            GalleryAlbum galleryAlbum = this.CreateGalleryAlbum();
            galleryAlbum.downs = testValue;

            // Assert
            Assert.Equal(testValue, galleryAlbum.downs);
        }

        [Fact]
        public void TestFavoriteSet()
        {
            // Arrange
            var testValue = true;

            // Act
            GalleryAlbum galleryAlbum = this.CreateGalleryAlbum();
            galleryAlbum.favorite = testValue;

            // Assert
            Assert.Equal(testValue, galleryAlbum.favorite);
        }

        [Fact]
        public void TestIdSet()
        {
            // Arrange
            var testValue = "testValue";

            // Act
            GalleryAlbum galleryAlbum = this.CreateGalleryAlbum();
            galleryAlbum.id = testValue;

            // Assert
            Assert.Equal(testValue, galleryAlbum.id);
        }

        [Fact]
        public void TestImagesSet()
        {
            // Arrange
            var testValue = new List<Image>{new Image(), new Image()};

            // Act
            GalleryAlbum galleryAlbum = this.CreateGalleryAlbum();
            galleryAlbum.images = testValue;

            // Assert
            Assert.Equal(testValue, galleryAlbum.images);
        }

        [Fact]
        public void TestImagesCountSet()
        {
            // Arrange
            var testValue = 20;

            // Act
            GalleryAlbum galleryAlbum = this.CreateGalleryAlbum();
            galleryAlbum.images_count = testValue;

            // Assert
            Assert.Equal(testValue, galleryAlbum.images_count);
        }

        [Fact]
        public void TestInGallerySet()
        {
            // Arrange
            var testValue = true;

            // Act
            GalleryAlbum galleryAlbum = this.CreateGalleryAlbum();
            galleryAlbum.in_gallery = testValue;

            // Assert
            Assert.Equal(testValue, galleryAlbum.in_gallery);
        }

        [Fact]
        public void TestIsAlbumSet()
        {
            // Arrange
            var testValue = true;

            // Act
            GalleryAlbum galleryAlbum = this.CreateGalleryAlbum();
            galleryAlbum.is_album = testValue;

            // Assert
            Assert.Equal(testValue, galleryAlbum.is_album);
        }

        [Fact]
        public void TestLayoutSet()
        {
            // Arrange
            var testValue = "TestValue";

            // Act
            GalleryAlbum galleryAlbum = this.CreateGalleryAlbum();
            galleryAlbum.layout = testValue;

            // Assert
            Assert.Equal(testValue, galleryAlbum.layout);
        }

        [Fact]
        public void TestLinkSet()
        {
            // Arrange
            var testValue = "TestValue";

            // Act
            GalleryAlbum galleryAlbum = this.CreateGalleryAlbum();
            galleryAlbum.link = testValue;

            // Assert
            Assert.Equal(testValue, galleryAlbum.link);
        }

        [Fact]
        public void TestNsfwSet()
        {
            // Arrange
            var testValue = true;

            // Act
            GalleryAlbum galleryAlbum = this.CreateGalleryAlbum();
            galleryAlbum.nsfw = testValue;

            // Assert
            Assert.Equal(testValue, galleryAlbum.nsfw);
        }

        [Fact]
        public void TestPointsSet()
        {
            // Arrange
            var testValue = 20;

            // Act
            GalleryAlbum galleryAlbum = this.CreateGalleryAlbum();
            galleryAlbum.points = testValue;

            // Assert
            Assert.Equal(testValue, galleryAlbum.points);
        }

        [Fact]
        public void TestPrivacySet()
        {
            // Arrange
            var testValue = "TestValue";

            // Act
            GalleryAlbum galleryAlbum = this.CreateGalleryAlbum();
            galleryAlbum.privacy = testValue;

            // Assert
            Assert.Equal(testValue, galleryAlbum.privacy);
        }

        [Fact]
        public void TestScoreSet()
        {
            // Arrange
            var testValue = 20;

            // Act
            GalleryAlbum galleryAlbum = this.CreateGalleryAlbum();
            galleryAlbum.score = testValue;

            // Assert
            Assert.Equal(testValue, galleryAlbum.score);
        }

        [Fact]
        public void TestTitleSet()
        {
            // Arrange
            var testValue = "TestValue";

            // Act
            GalleryAlbum galleryAlbum = this.CreateGalleryAlbum();
            galleryAlbum.title = testValue;

            // Assert
            Assert.Equal(testValue, galleryAlbum.title);
        }

        [Fact]
        public void TestTopicSet()
        {
            // Arrange
            var testValue = "TestValue";

            // Act
            GalleryAlbum galleryAlbum = this.CreateGalleryAlbum();
            galleryAlbum.topic = testValue;

            // Assert
            Assert.Equal(testValue, galleryAlbum.topic);
        }

        [Fact]
        public void TestTopicIdSet()
        {
            // Arrange
            var testValue = 20;

            // Act
            GalleryAlbum galleryAlbum = this.CreateGalleryAlbum();
            galleryAlbum.topic_id = testValue;

            // Assert
            Assert.Equal(testValue, galleryAlbum.topic_id);
        }

        [Fact]
        public void TestUpsSet()
        {
            // Arrange
            var testValue = 20;

            // Act
            GalleryAlbum galleryAlbum = this.CreateGalleryAlbum();
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
            GalleryAlbum galleryAlbum = this.CreateGalleryAlbum();
            galleryAlbum.views = testValue;

            // Assert
            Assert.Equal(testValue, galleryAlbum.views);
        }

        [Fact]
        public void TestVoteSet()
        {
            // Arrange
            var testValue = "TestValue";

            // Act
            GalleryAlbum galleryAlbum = this.CreateGalleryAlbum();
            galleryAlbum.vote = testValue;

            // Assert
            Assert.Equal(testValue, galleryAlbum.vote);
        }

        private GalleryAlbum CreateGalleryAlbum()
        {
            return new GalleryAlbum();
        }
    }
}
