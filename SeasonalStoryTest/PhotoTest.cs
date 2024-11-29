using SeasonalStory;
using SeasonalStory.Enums;

namespace SeasonalStoryTest
{
    [TestClass]
    public class PhotoTest
    {
        Photo validPhoto = new Photo() { PhotoTemp = TemperatureIntervals.BelowZero, PhotoSeason = Season.Winter, Image = new byte[] {1, 1, 1, 1, 1, 2 } };
        Photo UploadedImageNull = new Photo() { PhotoTemp = TemperatureIntervals.BelowZero, PhotoSeason = Season.Winter, UploadedImage = null};
        Photo ImageNull = new Photo() { PhotoTemp = TemperatureIntervals.BelowZero, PhotoSeason = Season.Winter, Image = null };

        [TestMethod]
        public void ValidateUploadedImageTest()
        {
            Assert.ThrowsException<NullReferenceException>(() => UploadedImageNull.ValidateUploadedImage());
            Assert.ThrowsException<NullReferenceException>(() => ImageNull.ValidateImage());
        }
    }
}