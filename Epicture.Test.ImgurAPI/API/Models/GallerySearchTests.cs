using Epicture.ImgurAPI.API.Models;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace Epicture.Test.ImgurAPI.API.Models
{
    public class GallerySearchTests : IDisposable
    {
        private MockRepository mockRepository;



        public GallerySearchTests()
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
            GallerySearch gallerySearch = this.CreateGallerySearch();
            gallerySearch.account_id = testValue;

            // Assert
            Assert.Equal(testValue, gallerySearch.account_id);
        }

        [Fact]
        public void TestAccountUrlSet()
        {
            // Arrange
            var testValue = "testValue";

            // Act
            GallerySearch gallerySearch = this.CreateGallerySearch();
            gallerySearch.account_url = testValue;

            // Assert
            Assert.Equal(testValue, gallerySearch.account_url);
        }

        [Fact]
        public void TestCommentCountSet()
        {
            // Arrange
            var testValue = 20;

            // Act
            GallerySearch gallerySearch = this.CreateGallerySearch();
            gallerySearch.comment_count = testValue;

            // Assert
            Assert.Equal(testValue, gallerySearch.comment_count);
        }

        [Fact]
        public void TestDateTimeSet()
        {
            // Arrange
            var testValue = 20;

            // Act
            GallerySearch gallerySearch = this.CreateGallerySearch();
            gallerySearch.datetime = testValue;

            // Assert
            Assert.Equal(testValue, gallerySearch.datetime);
        }

        [Fact]
        public void TestDescriptionSet()
        {
            // Arrange
            var testValue = "TestValue";

            // Act
            GallerySearch gallerySearch = this.CreateGallerySearch();
            gallerySearch.description = testValue;

            // Assert
            Assert.Equal(testValue, gallerySearch.description);
        }

        [Fact]
        public void TestDownsSet()
        {
            // Arrange
            var testValue = 20;

            // Act
            GallerySearch gallerySearch = this.CreateGallerySearch();
            gallerySearch.downs = testValue;

            // Assert
            Assert.Equal(testValue, gallerySearch.downs);
        }

        [Fact]
        public void TestFavoriteSet()
        {
            // Arrange
            var testValue = true;

            // Act
            GallerySearch gallerySearch = this.CreateGallerySearch();
            gallerySearch.favorite = testValue;

            // Assert
            Assert.Equal(testValue, gallerySearch.favorite);
        }

        [Fact]
        public void TestIdSet()
        {
            // Arrange
            var testValue = "testValue";

            // Act
            GallerySearch gallerySearch = this.CreateGallerySearch();
            gallerySearch.id = testValue;

            // Assert
            Assert.Equal(testValue, gallerySearch.id);
        }

        [Fact]
        public void TestImagesSet()
        {
            // Arrange
            var testValue = new List<Image> {new Image(), new Image()};

            // Act
            GallerySearch gallerySearch = this.CreateGallerySearch();
            gallerySearch.images = testValue;

            // Assert
            Assert.Equal(testValue, gallerySearch.images);
        }

        [Fact]
        public void TestIsAlbumSet()
        {
            // Arrange
            var testValue = true;

            // Act
            GallerySearch gallerySearch = this.CreateGallerySearch();
            gallerySearch.is_album = testValue;

            // Assert
            Assert.Equal(testValue, gallerySearch.is_album);
        }

        [Fact]
        public void TestLinkSet()
        {
            // Arrange
            var testValue = "TestValue";

            // Act
            GallerySearch gallerySearch = this.CreateGallerySearch();
            gallerySearch.link = testValue;

            // Assert
            Assert.Equal(testValue, gallerySearch.link);
        }

        [Fact]
        public void TestNsfwSet()
        {
            // Arrange
            var testValue = true;

            // Act
            GallerySearch gallerySearch = this.CreateGallerySearch();
            gallerySearch.nsfw = testValue;

            // Assert
            Assert.Equal(testValue, gallerySearch.nsfw);
        }

        [Fact]
        public void TestPointsSet()
        {
            // Arrange
            var testValue = 20;

            // Act
            GallerySearch gallerySearch = this.CreateGallerySearch();
            gallerySearch.points = testValue;

            // Assert
            Assert.Equal(testValue, gallerySearch.points);
        }

        [Fact]
        public void TestScoreSet()
        {
            // Arrange
            var testValue = 20;

            // Act
            GallerySearch gallerySearch = this.CreateGallerySearch();
            gallerySearch.score = testValue;

            // Assert
            Assert.Equal(testValue, gallerySearch.score);
        }

        [Fact]
        public void TestTitleSet()
        {
            // Arrange
            var testValue = "TestValue";

            // Act
            GallerySearch gallerySearch = this.CreateGallerySearch();
            gallerySearch.title = testValue;

            // Assert
            Assert.Equal(testValue, gallerySearch.title);
        }

        [Fact]
        public void TestTopicSet()
        {
            // Arrange
            var testValue = "TestValue";

            // Act
            GallerySearch gallerySearch = this.CreateGallerySearch();
            gallerySearch.topic = testValue;

            // Assert
            Assert.Equal(testValue, gallerySearch.topic);
        }

        [Fact]
        public void TestTopicIdSet()
        {
            // Arrange
            var testValue = 20;

            // Act
            GallerySearch gallerySearch = this.CreateGallerySearch();
            gallerySearch.topic_id = testValue;

            // Assert
            Assert.Equal(testValue, gallerySearch.topic_id);
        }

        [Fact]
        public void TestUpsSet()
        {
            // Arrange
            var testValue = 20;

            // Act
            GallerySearch gallerySearch = this.CreateGallerySearch();
            gallerySearch.ups = testValue;

            // Assert
            Assert.Equal(testValue, gallerySearch.ups);
        }

        [Fact]
        public void TestViewsSet()
        {
            // Arrange
            var testValue = 20;

            // Act
            GallerySearch gallerySearch = this.CreateGallerySearch();
            gallerySearch.views = testValue;

            // Assert
            Assert.Equal(testValue, gallerySearch.views);
        }

        [Fact]
        public void TestVoteSet()
        {
            // Arrange
            var testValue = "TestValue";

            // Act
            GallerySearch gallerySearch = this.CreateGallerySearch();
            gallerySearch.vote = testValue;

            // Assert
            Assert.Equal(testValue, gallerySearch.vote);
        }

        private GallerySearch CreateGallerySearch()
        {
            return new GallerySearch();
        }
    }
}
