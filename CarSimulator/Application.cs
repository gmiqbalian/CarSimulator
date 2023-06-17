using ServicesLibrary.Models;
using ServicesLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSimulator
{
    public class Application
    {

        private readonly DrivingService _drivingService;
        private readonly CarService _carService;

        public Application()
        {
            _drivingService = new DrivingService();
            _carService = new CarService();
        }
        public void Run()
        {
            var running = true;
            var instruction = string.Empty;
            
            var maxTankCapaity = 15;
            var car = _carService.GetCar(maxTankCapaity);
            
            var maxDrivingCapacity = 5;
            var driver = new Driver(maxDrivingCapacity);

            while (running)
            {
                MainMenu.ShowMainMenu();
                var selection = Console.ReadLine();

                switch (selection)
                {
                    case "1":
                        instruction = "right";
                        _drivingService.Drive(instruction, car, driver);
                        Console.ReadKey();
                        break;
                    case "2":
                        instruction = "left";
                        _drivingService.Drive(instruction, car, driver);
                        Console.ReadKey();
                        break;
                    case "3":
                        instruction = "straight";
                        _drivingService.Drive(instruction, car, driver);
                        Console.ReadKey();
                        break;
                    case "4":
                        instruction = "reverse";
                        _drivingService.Drive(instruction, car, driver);
                        Console.ReadKey();
                        break;
                    case "5":
                        _drivingService.TakeRest(driver);
                        Console.ReadKey();
                        break;
                    case "6":
                        _drivingService.Refuel(car);
                        Console.ReadKey();
                        break;
                    case "7":
                        running = false;
                        break;
                    default:
                        Console.Write("Please choose a valid option");
                        Console.ReadKey();
                        break;
                }

            }
        }
    }
}
