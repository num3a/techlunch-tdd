using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NSubstitute;

namespace Demeter.Tests
{
    public class DemeterEngineTests
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [TestCase(5, DemeterEngine.MoistureLevel.VeryLow)]
        [TestCase(10,DemeterEngine.MoistureLevel.VeryLow)]
        [TestCase(20, DemeterEngine.MoistureLevel.Low)]
        [TestCase(30, DemeterEngine.MoistureLevel.Low)]
        [TestCase(35, DemeterEngine.MoistureLevel.Middle)]
        [TestCase(40, DemeterEngine.MoistureLevel.Middle)]
        [TestCase(55, DemeterEngine.MoistureLevel.High)]
        [TestCase(80, DemeterEngine.MoistureLevel.VeryHigh)]
        [TestCase(100, DemeterEngine.MoistureLevel.VeryHigh)]
        public void Engine_Should_ReturnMoistureLevel(int actualMoistureInPercentage, DemeterEngine.MoistureLevel level)
        {
            var moistureSensor = Substitute.For<IMoistureSensor>();
            moistureSensor.GetLevelInPourcentage().Returns(actualMoistureInPercentage);
            var engine = new DemeterEngine(moistureSensor, null);

            var moistureLevel = engine.GetMoistureLevel();
            moistureSensor.Received().GetLevelInPourcentage();
            Assert.AreEqual(moistureLevel, level);
        }

        [Test]
        public void Engine_Should_TurnUpTheLight_When_TheNightCameOut()
        {
            var moistureSensor = Substitute.For<IMoistureSensor>();
            var lightSensor = Substitute.For<ILightSensor>();

            lightSensor.AmbiantLuminosityIsDark().Returns(true);

            var engine = new DemeterEngine(moistureSensor, lightSensor);
            Assert.IsTrue(engine.LightsOn);
        }


    }
}
