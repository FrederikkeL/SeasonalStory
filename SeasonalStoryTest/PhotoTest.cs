using SeasonalStory;
using SeasonalStory.Enums;

namespace SeasonalStoryTest
{
    [TestClass]
    public class PhotoTest
    {
        Photo validPhoto = new Photo() { PhotoTemp = TemperatureIntervals.BelowZero, PhotoSeason = Season.Winter, UploadedImage = "test" };
        Photo ImageNull = new Photo() { PhotoTemp = TemperatureIntervals.BelowZero, PhotoSeason = Season.Winter, UploadedImage = null };

        [TestMethod]
        public void ValidateTest()
        {
            validPhoto.Validate();
            Assert.ThrowsException<NullReferenceException>(() => ImageNull.Validate());
        }
    }
}