using SeasonalStory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeasonalStoryTest.TemperatureTests
{
    [TestClass]
    public class TemperatureRepoTest
    {
        TemperatureRepo _tempRepo = new TemperatureRepo();

        [TestMethod]
        public async Task GetTest()
        {

            var expected = new Temperature() { Timestamp = DateTime.Now, Value = 10 };

            await _tempRepo.AddTemperature(expected);
            Temperature temperature = await _tempRepo.GetLatest();
            
            Assert.AreEqual(expected, temperature);
        }


    }
}
