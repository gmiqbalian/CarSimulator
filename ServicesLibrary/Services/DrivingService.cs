using ServicesLibrary.Enums;
using ServicesLibrary.Models;
using System.Threading.Tasks;

namespace ServicesLibrary.Services
{
    public class DrivingService : IDrivingService
    {
        private readonly ICarService _carService;
        private readonly IDriverService _driverService;
        private readonly IMessageService _messageService;

        public DrivingService(IDriverService driverService, IMessageService messageService, ICarService carService)
        {
            _driverService = driverService;
            _messageService = messageService;
            _carService = carService;
        }
        public Car GetCar(int fuelCapacity)
        {
            return _carService.CreateCar(fuelCapacity);
        }
        public Driver GetDriver(int fatigueCapacity)
        {
            return _driverService.GetDriver(fatigueCapacity);
        }
        public Status Drive(string instruction, Car car, Driver driver)
        {
            if (IsTankEmpty(car))
            {
                Print.ErrorMessage("\nPlease refuel before driving.");
                return Status.Error;
            }

            if (IsTired(driver))
            {
                Print.ErrorMessage("\nDriver is too tired to drive.");
                return Status.Error;
            }

            _carService.ChangeDirection(instruction, car);
            car.FuelLevel--;
            driver.FatigueLevel++;
            _messageService.PrintStatusMessage(car, driver, instruction);
            
            return Status.OK;
        }
        public Status TakeRest(Driver driver)
        {
            if (!IsTired(driver))
            {
                Print.ErrorMessage("\nDriver is alredy fresh.");
                return Status.Error;
            }
            driver.FatigueLevel = 0;
            Print.SuccessMessage("\nDriver is now rested and ready to drive.");
            return Status.OK;
        }
        public Status Refuel(Car car)
        {
            if (!IsTankEmpty(car))
            {
                Print.ErrorMessage("\nTank is already full!");
                return Status.Error;
            }

            car.FuelLevel = car.MaxFuel;
            Print.SuccessMessage("\nTank refueled to full capacity.");
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
