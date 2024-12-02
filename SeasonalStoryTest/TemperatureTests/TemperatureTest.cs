using SeasonalStory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SeasonalStoryTest.TemperatureTests
{
    [TestClass]
    public class TemperatureTest
    {
        Temperature validTemperature = new Temperature() { Value = 13 };
        Temperature temperatureTooLow = new Temperature() { Value = -31 };
        Temperature temperatureTooHigh = new Temperature() { Value = 41 };

        [TestMethod]
        public void ValidateValueTest()
        {
            validTemperature.ValidateValue();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => temperatureTooLow.ValidateValue());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => temperatureTooHigh.ValidateValue());
        }

        [TestMethod]
        public void ValidateTest()
        {
            validTemperature.Validate();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => temperatureTooLow.ValidateValue());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => temperatureTooHigh.ValidateValue());
        }

        [TestMethod]
        [DataRow(-30)]
        [DataRow(0)]
        [DataRow(40)]

        public void LegalValueTest(int value)
        {
            Temperature temperature = new Temperature(value);
            temperature.Validate();
        }

        [TestMethod]
        [DataRow(-31)]
        [DataRow(41)]

        public void IlegalValueTest(int value)
        {
            Temperature temperature = new Temperature(value);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => temperature.Validate());

        }

    }
}
