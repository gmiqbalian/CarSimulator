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
        private readonly IDirectionServices _directionServices;
        public CarController(IDrivingServices drivingServices, IDriverServices driverServices, ICarServices carServices, IDirectionServices directionServices)
        {
            _drivingServices = drivingServices;
            _driverServices = driverServices;
            _carServices = carServices;
            _directionServices = directionServices;
        }
        public Car SetupCar()
        {
            var car = new Car();
            car.FuelLevel = 5; //change to 20
            car.Direction = _directionServices.GetCurrentDirection();

            return car;
        }
        public void Drive(string instruction, Car car)
        {
            if (FuelTankIsEmpty(car))
            {
                Console.WriteLine("Car is out of fuel. Refuel before moving.");
            }
            else
            {
                car.FuelLevel--;
                car.Direction = _directionServices.GetNewDirection(car.Direction, instruction);

                Console.WriteLine($"Car is going: {instruction}");
                Console.WriteLine($"Car direction: {car.Direction}");
            }
        }

        public bool FuelTankIsEmpty(Car car)
        {
            if(car.FuelLevel == 0)
                return true;
            return false;
        }
    }
}
