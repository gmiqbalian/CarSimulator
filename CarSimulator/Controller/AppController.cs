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
            var car = _carServices.GetNewCar(20);
            car.Direction = _directionServices.GetCurrentDirection();

            return car;
        }
        public void Drive(string instruction, Car car, Driver driver)
        {
            if (FuelTankIsEmpty(car.FuelLevel))
            {
                Console.Write("Car is out of fuel. Refuel before moving.");
                return;
            }

            if (IsTired(driver))
            {
                Console.Write("Driver is tired and needs rest.");
                return;
            }

            car.FuelLevel -= 1;
            car.Direction = _directionServices.GetNewDirection(car.Direction, instruction);
            driver.FatigueLevel += 2;
            Console.WriteLine($"Car is going: {instruction}");
            Console.WriteLine($"Car direction: {car.Direction}");

            if (FuelTankWarning(car.FuelLevel))
                Console.WriteLine($"Fuel level warning: {car.FuelLevel} / {car.MaxFuel}");

            if(IsTiredWarning(driver.FatigueLevel))
                Console.WriteLine($"Driver fatigue level warning: {driver.FatigueLevel} / {driver.MaxFatigue}");
        }

        public bool FuelTankIsEmpty(int fuelLevel)
        {
            return fuelLevel == 0;
        }
        public bool FuelTankWarning(int fuelLevel)
        {
            return fuelLevel >= 0 && fuelLevel < 5;
        }
        public void RefuelTank(Car car)
        {
            if (car.FuelLevel == car.MaxFuel)
            {
                Console.Write("Car tank is already full!");
                return;
            }

            car.FuelLevel = car.MaxFuel;
            Console.Write($"Car tank refuled successfully! \n {car.FuelLevel} / {car.MaxFuel}");
        }
        public Driver GetDriver(int maxFatigue)
        {
            var driver = _driverServices.GetDriver().Result;
            driver.MaxFatigue = maxFatigue;
            driver.FatigueLevel = 0;

            return driver;
        }
        public bool IsTired(Driver driver)
        {
            return driver.FatigueLevel >= driver.MaxFatigue;
        }
        public bool IsTiredWarning(int fatigueLevel)
        {
            return fatigueLevel > 15;
        }
        public void TakeRest(Driver driver)
        {
            if (driver.FatigueLevel > 0)
            {
                driver.FatigueLevel = 0;
                Console.Write("Driver is rested now.");
            }
            else
                Console.Write("Driver is already rested and ready to driver.");
        }
    }
}
