using SeasonalStory;
using SeasonalStory.Enums;

namespace SeasonalStoryTest
{
    [TestClass]
    public class PhotoTest
    {
        Photo validPhoto = new Photo() { PhotoTemp = Temperature.BelowZero, PhotoSeason = Season.Winter, ImageFile = "/TestPhoto/photo1.png" };
        Photo ImageFileNull = new Photo() { PhotoTemp = Temperature.BelowZero, PhotoSeason = Season.Winter, ImageFile = null };
        Photo ImageFileEmpty = new Photo() { PhotoTemp = Temperature.BelowZero, PhotoSeason = Season.Winter, ImageFile = "" };

        [TestMethod]
        public void ValidateImageFileTest()
        {
            validPhoto.Validate();
            Assert.ThrowsException<NullReferenceException>(() => ImageFileNull.Validate());
            Assert.ThrowsException<ArgumentException>(() => ImageFileEmpty.Validate());
        }
    }
}