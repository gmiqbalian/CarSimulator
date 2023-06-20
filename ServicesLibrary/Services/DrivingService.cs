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

        public DrivingService(
            IDriverService driverService, 
            IMessageService messageService, 
            ICarService carService)
        {
            _driverService = driverService;
            _messageService = messageService;
            _carService = carService;
        }
        public Car SetupCar()
        {
            var car = _carService.CreateCar();
            var driver = _driverService.GetDriver();
            car.Driver = driver;

            return car;
        }
        public void DriveCommand(Instruction instruction, Car car)
        {
            if (car.IsTankEmpty)
            {
                Print.ErrorMessage("\nPlease refuel before driving.");
                return;
            }

            if (car.Driver.IsTired())
            {
                Print.ErrorMessage("\nDriver is too tired to drive.");
                return;
            }

            _carService.Drive(car, instruction);
            
            _messageService.PrintStatusMessage(car, instruction.ToString());
        }
        public Status RestCommand(Driver driver)
        {            
            _driverService.TakeRest(driver);
            return Status.Success;
        }
        public Status RefuelCommand(Car car)
        {
            _carService.Refuel(car);
            return Status.Success;
        }
    }
}
