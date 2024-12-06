using SeasonalStory;
using SeasonalStory.Enums;

namespace SeasonalStoryTest
{
    [TestClass]
    public class PhotoTest
    {
        Photo validPhoto = new Photo() { PhotoTemp = TemperatureIntervals.BelowZero, PhotoSeason = Season.Winter, UploadedImage = "test" };
        Photo ImageNull = new Photo() { PhotoTemp = TemperatureIntervals.BelowZero, PhotoSeason = Season.Winter, UploadedImage = null };
        Photo ImageEmpty = new Photo() { PhotoTemp = TemperatureIntervals.BelowZero, PhotoSeason = Season.Winter, UploadedImage = "" };

        [TestMethod]
        public void ValidateTest()
        {
            validPhoto.Validate();
            Assert.ThrowsException<NullReferenceException>(() => ImageNull.Validate());
            Assert.ThrowsException<ArgumentException>(() => ImageEmpty.Validate());
        }
    }
}