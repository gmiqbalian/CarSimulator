using ServicesLibrary.Data;
using ServicesLibrary.Models;
using ServicesLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSimulator.Controller
{
    public class CarController : ICarController
    {
        private readonly IDrivingServices _drivingServices;
        private readonly IDriverServices _driverServices;
        private readonly ICarServices _carServices;
        private Car _car { get; set; }
        private Driver _driver { get; set; }
        public CarController(IDrivingServices drivingServices, IDriverServices driverServices, ICarServices carServices)
        {
            _drivingServices = drivingServices;
            _driverServices = driverServices;
            _carServices = carServices;
            _car = _carServices.GetNewCar();
            _driver = _driverServices.GetDriver().Result;
        }
        public void Drive(string instruction)
        {
            var currentFuelLevel = _car.FuelLevel;
            var fuelStatus = _carServices.HasEnoughFuel(currentFuelLevel);
            var fuelLevel = _car.FuelLevel;

            if(fuelStatus == FuelEnum.Empty)
            {
                Console.WriteLine("Car is out of fuel. Refuel before moving...");
            }
            else
            {
                _drivingServices.Drive(instruction);
                _car.FuelLevel--;
            }
            
            _carServices.PrintFuelWarning(fuelLevel);
        }
    }
}
