using ServicesLibrary.Enums;
using ServicesLibrary.Models;
using System.Threading.Tasks;

namespace ServicesLibrary.Services
{
    public class DrivingService
    {
        private readonly CarService _carService;
        private readonly DriverService _driverService;
        public DrivingService()
        {          
            _carService = new CarService();
            _driverService = new DriverService();
        }
        public Status Drive(string instruction, Car car, Driver driver)
        {
            if (IsTankEmpty(car))
            {
                Print.ErrorMessage("Please refuel before driving.");
                return Status.Error;
            }

            if (IsTired(driver))
            {
                Print.ErrorMessage("Driver is too tired to drive.");
                return Status.Error;

            }

            car.FuelLevel--;
            driver.FatigueLevel++;
            return Status.OK;
        }
        public Status TakeRest(Driver driver)
        {
            if (!IsTired(driver))
            {
                Print.ErrorMessage("Driver is alredy fresh.");
                return Status.Error;
            }
            driver.FatigueLevel = 0;
            Print.SuccessMessage("Driver is now rested and ready to drive.");
            return Status.OK;
        }
        public Status Refuel(Car car)
        {
            if (!IsTankEmpty(car))
            {
                Print.ErrorMessage("Tank is already full");
                return Status.Error;
            }

            car.FuelLevel = car.MaxFuel;
            Print.SuccessMessage("Tank refueled to full capacity.");
            return Status.OK;
        }



        private bool IsTankEmpty(Car car)
        {
            return car.FuelLevel == 0;
        }
        private bool IsTired(Driver driver)
        {
            return driver.FatigueLevel == driver.MaxFatigue;
        }
    }
}
