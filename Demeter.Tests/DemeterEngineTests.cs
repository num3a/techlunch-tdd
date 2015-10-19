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
        private IMoistureSensor _moistureSensor;
        private ILightSensor _lightSensor;
        private DemeterEngine _engine;

        [SetUp]
        public void Setup()
        {
            InitializeEngine();
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
            StubGetLevelInPourcentage(actualMoistureInPercentage);

            var moistureLevel = _engine.GetMoistureLevel();
            _moistureSensor.Received().GetLevelInPourcentage();

            Assert.AreEqual(moistureLevel, level);
        }
        
        [Test]
        public void Engine_Should_TurnOnTheLight_When_TheNightCameOut()
        {
            StubAmbiantLuminosity(true);
            _engine.ToogleTheLights();

            Assert.IsTrue(_engine.LightsOn);
        }

        [Test]
        public void Engine_Should_TurnOffTheLight_When_TheSunRises()
        {
            StubAmbiantLuminosity(false);

            _engine.ToogleTheLights();

            Assert.IsFalse(_engine.LightsOn);
        }

        private void InitializeEngine()
        {
            _moistureSensor = Substitute.For<IMoistureSensor>();
            _lightSensor = Substitute.For<ILightSensor>();
            _engine = new DemeterEngine(_moistureSensor, _lightSensor);
        }

        private void StubAmbiantLuminosity(bool isDark)
        {
            _lightSensor.AmbiantLuminosityIsDark().Returns(isDark);
        }

        private void StubGetLevelInPourcentage(int actualMoistureInPercentage)
        {
            _moistureSensor.GetLevelInPourcentage().Returns(actualMoistureInPercentage);
        }

    }
}
