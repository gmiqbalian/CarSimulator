using ServicesLibrary.Enums;
using ServicesLibrary.Models;
using ServicesLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSimulatorTests.Services
{
    [TestClass]
    public class CarServiceTests
    {
        private readonly CarService _sut;
        public CarServiceTests()
        {
            _sut = new CarService();
        }
        [TestMethod]
        public void CreateCar_Does_Not_Return_Null()
        {
            //Arrange

            //Act
            var result = _sut.CreateCar();

            //Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void CreateCar_Returns_Car_Object()
        {
            //Arrange

            //Act
            var actualCar = _sut.CreateCar();

            //Assert
            Assert.IsInstanceOfType(actualCar, typeof(Car));
        }
        [TestMethod]
        public void CreateCar_Sets_Random_Car_Direction()
        {
            //Arrange

            //Act
            var car = _sut.CreateCar();
            var direction = car.Direction;

            //Assert
            Assert.IsNotNull(direction);
        }
        [TestMethod]
        public void Drive_Changes_FuelLevel()
        {
            //Arrange
            var car = new Car();
            var driver = new Driver();
            car.Driver = driver;
            var instruction = Instruction.Right;
            var expected = 19;

            //Act
            _sut.Drive(car, instruction);
            var actual = car.FuelLevel;

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Drive_Changes_Direction()
        {
            //Arrange
            var car = new Car();
            var driver = new Driver();
            car.Driver = driver;
            car.Direction = "North";
            var instruction = Instruction.Right;
            var expected = "East";

            //Act
            _sut.Drive(car, instruction);
            var actual = car.Direction;

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Drive_Increases_FatigueLevel()
        {
            //Arrange
            var car = new Car();
            var driver = new Driver();
            car.Driver = driver;
            var instruction = Instruction.Right;
            var expected = 1;

            //Act
            _sut.Drive(car, instruction);
            var actual = car.Driver.FatigueLevel;

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Refuel_Successful_When_TankIsEmpty()
        {
            //Arrange
            var car = new Car();
            var expectedFuelLevel = 20;

            //Act
            for (int i = 1; i <= car.MaxFuel; i++)
                car.ConsumeFuel();
            _sut.Refuel(car);
            var resultingFuelLevel = car.FuelLevel;

            //Assert
            Assert.AreEqual(expectedFuelLevel, resultingFuelLevel);
        }
        [TestMethod]
        public void Refuel_Fails_When_TankIsNotEmpty()
        {
            //Arrange
            var car = new Car();
            var expectedFuelLevel = 20;

            //Act            
            _sut.Refuel(car);
            var resultingFuelLevel = car.FuelLevel;

            //Assert
            Assert.AreEqual(expectedFuelLevel, resultingFuelLevel);
        }

    }
}
