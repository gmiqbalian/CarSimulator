using ServicesLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSimulatorTests.Entities
{
    [TestClass]
    public class DriverTests
    {
        private Driver _sut;

        [TestInitialize]
        public void Setup()
        {
            _sut = new Driver();
        }
        [TestMethod]
        public void TakeRest_Decreases_Fatigue_Level_To_Zero()
        {
            //Arrange
            _sut.FatigueLevel = 5;
            var expected = 0;

            //Act
            _sut.TakeRest();
            var actual = _sut.FatigueLevel;

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void IncreaseFatigue_Raise_Fatigue_By_OneLevel()
        {
            //Arrange
            var expected = 1;

            //Act
            _sut.IncreaseFatigue();
            var actual = _sut.FatigueLevel;

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
