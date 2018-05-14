using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeatherRest;
using WeatherRest.model;

namespace WeatherRestTests
{
    [TestClass()]
    public class Service1Tests
    {
        [TestMethod()]
        public void GetAllTemperaturesTest()
        {
            // Arrange
            Service1 svc1 = new Service1();

            // Act
            var mTemperatures = svc1.GetAllTemperatures().ToList();
            var count = mTemperatures.Count;

            // Assert
            Assert.AreEqual(40, count);
        }

        [TestMethod()]
        public void GetTemperatureTest()
        {
            // Arrange
            Service1 svc1 = new Service1();
            // Act
            var mTemperature = svc1.GetTemperature("1");
            // Assert
            Assert.AreEqual(9, mTemperature.Temperature);
        }

        [TestMethod()]
        public void GetSpecificTemperaturesTest()
        {
            // Arrange
            Service1 svc1 = new Service1();
            // Act
            var mTemperatures = svc1.GetSpecificTemperatures("Mars");
            var count = mTemperatures.Count;
            // Assert
            Assert.AreEqual(1, count);
        }

        [TestMethod()]
        public void AddTemperatureTest()
        {
            // Arrange
            Service1 svc1 = new Service1();
            // Act9
            var temp = new MTemperature(9000, "TESTING", "TESTING");
            var mTemperatures = svc1.AddTemperature(temp);
            // Assert
            Assert.AreEqual(true, mTemperatures);
        }
    }
}