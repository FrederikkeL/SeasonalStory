using SeasonalStory;
using SeasonalStory.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SeasonalStoryTest
{
    [TestClass]
    public class PhotoRepoTest
    {
        PhotosRepo _photoRepo = new PhotosRepo();

        [TestMethod]
        public async Task GetTest()
        {
            IEnumerable<Photo> photos = await _photoRepo.Get();
            //If the database gets cleared, first uploadedimage link needs to be updated for the test to pass
            Assert.AreEqual("https://images.photowall.com/products/60831/summer-park.jpg?h=699&q=85", photos.First().UploadedImage);
        }

        [TestMethod]
        public async Task GetQueryTest()
        {
            IEnumerable<Photo> photos = await _photoRepo.Get("season", "15");
            Assert.IsNotNull(photos);
        }

        [TestMethod]
        public async Task GetByIDTest()
        {
            Assert.IsNull(await _photoRepo.GetByID(-1));
            Assert.IsNull(await _photoRepo.GetByID(0));
            //If the database gets cleared, first ID in list needs to be updated for the test to pass
            Assert.IsNotNull(await _photoRepo.GetByID(15));
        }

        [TestMethod]
        public async Task AddTest()
        {
            int count = _photoRepo.Get().Result.Count();

            Photo addedPhoto = await _photoRepo.Add(new Photo() { PhotoTemp = TemperatureIntervals.BelowZero, PhotoSeason = Season.Winter, UploadedImage = "test" });
            
            Assert.AreEqual(count + 1, _photoRepo.Get().Result.Count());

            await Assert.ThrowsExceptionAsync<NullReferenceException>(
                async () => await _photoRepo.Add(new Photo() { PhotoTemp = TemperatureIntervals.BelowZero, PhotoSeason = Season.Winter, UploadedImage = null }));

            await Assert.ThrowsExceptionAsync<ArgumentException>(
                async () => await _photoRepo.Add(new Photo() { PhotoTemp = TemperatureIntervals.BelowZero, PhotoSeason = Season.Winter, UploadedImage = "" }));

            await _photoRepo.Delete(addedPhoto.Id);
        }

        [TestMethod]
        public async Task DeleteTest()
        {
            Photo deletePhoto = await _photoRepo.Add(new Photo() { PhotoTemp = TemperatureIntervals.BelowZero, PhotoSeason = Season.Winter, UploadedImage = "delete" });
            Photo deletedPhoto = await _photoRepo.Delete(deletePhoto.Id);
            Assert.IsNotNull(deletedPhoto);

            Photo failedDelete = await _photoRepo.Delete(deletedPhoto.Id);
            Assert.IsNull(failedDelete);
        }

        [TestMethod]
        public void GetSeasonTest()
        {
            Assert.AreEqual(Season.Winter, _photoRepo.GetSeason()); // Som Season.Winter er implementeret nu, skal der rettes i testen, når vi skifter sæson
        }

        [TestMethod]
        [DataRow (-1, TemperatureIntervals.BelowZero)]
        [DataRow (-2, TemperatureIntervals.BelowZero)]

        [DataRow (0, TemperatureIntervals.ZeroToTwelve)]
        [DataRow (1, TemperatureIntervals.ZeroToTwelve)]
        [DataRow (11, TemperatureIntervals.ZeroToTwelve)]
        [DataRow (12, TemperatureIntervals.ZeroToTwelve)]

        [DataRow (13, TemperatureIntervals.ThirteenToEigthteen)]
        [DataRow (14, TemperatureIntervals.ThirteenToEigthteen)]
        [DataRow (17, TemperatureIntervals.ThirteenToEigthteen)]
        [DataRow (18, TemperatureIntervals.ThirteenToEigthteen)]

        [DataRow (19, TemperatureIntervals.NineteenToTwentythree)]
        [DataRow (20, TemperatureIntervals.NineteenToTwentythree)]
        [DataRow (22, TemperatureIntervals.NineteenToTwentythree)]
        [DataRow (23, TemperatureIntervals.NineteenToTwentythree)]

        [DataRow (24, TemperatureIntervals.TwentyfourToThirty)]
        [DataRow (25, TemperatureIntervals.TwentyfourToThirty)]
        [DataRow (29, TemperatureIntervals.TwentyfourToThirty)]
        [DataRow (30, TemperatureIntervals.TwentyfourToThirty)]

        [DataRow (31, TemperatureIntervals.AboveThirtyone)]
        [DataRow (32, TemperatureIntervals.AboveThirtyone)]
        


        public void GetTemperatureGoodValuesTest(int temperature, TemperatureIntervals expected)
        {
            Assert.AreEqual(expected, _photoRepo.GetTemperature(temperature));
           
        }

        [TestMethod]
        [DataRow (1, TemperatureIntervals.BelowZero)]

        [DataRow (-1, TemperatureIntervals.ZeroToTwelve)]
        [DataRow (13, TemperatureIntervals.ZeroToTwelve)]

        [DataRow (12, TemperatureIntervals.ThirteenToEigthteen)]
        [DataRow (19, TemperatureIntervals.ThirteenToEigthteen)]

        [DataRow (18, TemperatureIntervals.NineteenToTwentythree)]
        [DataRow (24, TemperatureIntervals.NineteenToTwentythree)]

        [DataRow (23, TemperatureIntervals.TwentyfourToThirty)]
        [DataRow (31, TemperatureIntervals.TwentyfourToThirty)]

        [DataRow (30, TemperatureIntervals.AboveThirtyone)]

        public void GetTemperatureBadValuesTest(int temperature, TemperatureIntervals expected)
        {
            Assert.AreNotEqual(expected, _photoRepo.GetTemperature(temperature));
        }
    }
}
