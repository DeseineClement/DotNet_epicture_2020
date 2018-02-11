using Epicture.BaseAPI;
using Moq;
using System;
using Xunit;

namespace Epicture.Test.BaseAPI
{
    public class PictureResultTests : IDisposable
    {
        private MockRepository mockRepository;



        public PictureResultTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        public void Dispose()
        {
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void TestNameSet()
        {
            // Arrange
            var testName = "TestName";

            // Act
            PictureResult pictureResult = this.CreatePictureResult();
            pictureResult.Name = testName;

            // Assert
            Assert.Equal(testName, pictureResult.Name);
        }

        [Fact]
        public void TestDescriptionSet()
        {
            // Arrange
            var testDesription = "TestDescription";

            // Act
            PictureResult pictureResult = this.CreatePictureResult();
            pictureResult.Description = testDesription;

            // Assert
            Assert.Equal(testDesription, pictureResult.Description);
        }

        [Fact]
        public void TestHeightSet()
        {
            // Arrange
            var testHeight = 42;

            // Act
            PictureResult pictureResult = this.CreatePictureResult();
            pictureResult.Height = testHeight;

            // Assert
            Assert.Equal(testHeight, pictureResult.Height);
        }

        [Fact]
        public void TestWidthSet()
        {
            // Arrange
            var testWidth = 42;

            // Act
            PictureResult pictureResult = this.CreatePictureResult();
            pictureResult.Width = testWidth;

            // Assert
            Assert.Equal(testWidth, pictureResult.Width);
        }

        [Fact]
        public void TestIdSet()
        {
            // Arrange
            var testId = "42";

            // Act
            PictureResult pictureResult = this.CreatePictureResult();
            pictureResult.Id = testId;

            // Assert
            Assert.Equal(testId, pictureResult.Id);
        }

        [Fact]
        public void TestUrlSet()
        {
            // Arrange
            var testUrl = "TestUrl";

            // Act
            PictureResult pictureResult = this.CreatePictureResult();
            pictureResult.Url = testUrl;

            // Assert
            Assert.Equal(testUrl, pictureResult.Url);
        }

        private PictureResult CreatePictureResult()
        {
            return new PictureResult();
        }
    }
}
