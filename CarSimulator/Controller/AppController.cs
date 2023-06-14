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
    public class AppController : IAppController
    {
        private readonly IDrivingServices _drivingServices;
        private readonly IDriverServices _driverServices;
        private readonly ICarServices _carServices;
        private readonly IDirectionServices _directionServices;
        public AppController(IDrivingServices drivingServices, IDriverServices driverServices, ICarServices carServices, IDirectionServices directionServices)
        {
            _drivingServices = drivingServices;
            _driverServices = driverServices;
            _carServices = carServices;
            _directionServices = directionServices;
        }
        public Car SetupCar()
        {
            var car = _carServices.GetNewCar(5);
            
            return car;
        }
        public void Drive(string instruction, Car car)
        {
            if(FuelTankIsEmpty(car.FuelLevel))
            {
                Console.WriteLine("Car is out of fuel. Refuel before moving.");
                return;
            }
            
            car.FuelLevel--;
            car.Direction = _directionServices.GetNewDirection(car.Direction, instruction);
            Console.WriteLine($"Car is going: {instruction}");
            Console.WriteLine($"Car direction: {car.Direction}");
            if(FuelTankWarning(car.FuelLevel))
            {
                Console.WriteLine($"Fuel level warning: {car.FuelLevel} / {car.MaxFuel}");
            }
        }

        public bool FuelTankIsEmpty(int fuelLevel)
        {
            return fuelLevel == 0;
        }
        public bool FuelTankWarning(int fuelLevel)
        {
            return fuelLevel >= 0 && fuelLevel < 5;
        }
    }
}
