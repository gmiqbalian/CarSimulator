﻿using ServicesLibrary.Enums;
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
        public Status DriveCommand(Instruction instruction, Car car)
        {
            if (car.Driver.IsTired)
            {
                Print.ErrorMessage("\nDriver is too tired to drive.");
                return Status.Error;
            }

            if (car.IsTankEmpty)
            {
                Print.ErrorMessage("\nPlease refuel before driving.");
                return Status.Error;
            }

            if(car.Driver.HungerStatus == HungerStatus.Starving)
            {
                Print.ErrorMessage("\nDriver is too hungry to driver.");
                return Status.Error;
            }

            _carService.Drive(car, instruction);
            _messageService.PrintStatusMessage(car, instruction.ToString());
            return Status.Success;
        }
        public Status RestCommand(Driver driver)
        {
            var restStatus = _driverService.TakeRest(driver);

            if (restStatus == false)
                return Status.Error;
            
            return Status.Success;
        }
        public Status RefuelCommand(Car car)
        {
            var refuelStatus = _carService.Refuel(car);

            if (refuelStatus == false)
                return Status.Error;

            return Status.Success;
            }
        public void IntroductionCommand(Driver driver)
        {
            Print.StatusMessage(
                $"\nName: {driver.Name}" +
                $"\nAge: {driver.Age}" +
                $"\nContact: {driver.Phone}" +
                $"\nFatigue Level: {driver.FatigueLevel} / {driver.MaxFatigue}");
        }
        public Status EatCommand(Driver driver)
        {
            var status = _driverService.Eat(driver);
            
            if (status == false)
                return Status.Error;

            return Status.Success;
        }
    }
}
