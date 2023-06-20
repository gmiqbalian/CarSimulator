using ServicesLibrary.Enums;
using ServicesLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSimulatorTests.Entities
{
    [TestClass]
    public class CarTests
    {
        private readonly Car _sut;
        public CarTests()
        {
            _sut = new Car();
        }
        [TestMethod]
        public void Refuel_Increases_Level_To_Maximum()
        {
            //Arrange
            var expected = 20;

            //Act
            for(var i = 0; i < expected; i++) {_sut.ConsumeFuel();}
            
            _sut.Refuel();
            var actual = _sut.FuelLevel;

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void CosumeFuel_Reduces_Fuel_By_1()
        {
            //Arrange
            var expected = 19;

            //Act
            _sut.ConsumeFuel();
            var actual = _sut.FuelLevel;

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ChangeDirection_Returns_Correct_Direction_When_Driving_Right()
        {
            //Arrange
            var currentDirection = "North";
            _sut.Direction = currentDirection;
            var instruction = Instruction.Right;
            var expected = "East";

            //Act
            _sut.ChangeDirection(instruction);
            var actual = _sut.Direction;

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ChangeDirection_Returns_Correct_Direction_When_Driving_Left()
        {
            //Arrange
            var currentDirection = "North";
            _sut.Direction = currentDirection;
            var instruction = Instruction.Left;
            var expected = "West";

            //Act
            _sut.ChangeDirection(instruction);
            var actual = _sut.Direction;

            //Assert
            Assert.AreEqual(expected, actual);
        }

    }
}
