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
        public async Task GetByIDTest()
        {
            Assert.IsNull(await _photoRepo.GetByID(-1));
            Assert.IsNull(await _photoRepo.GetByID(0));
            //If the database gets cleared, first ID in list needs to be updated for the test to pass
            Assert.IsNotNull(await _photoRepo.GetByID(75));
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
    }
}
