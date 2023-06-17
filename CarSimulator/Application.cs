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

        private readonly IDrivingService _drivingService;
        public Application(IDrivingService drivingService)
        {
            _drivingService = drivingService;
        }
        public void Run()
        {            
            var running = true;
            var instruction = string.Empty;
            
            var maxTankCapaity = 15;
            var car = _drivingService.GetCar(maxTankCapaity);
            
            var fatigueCapcity = 10;
            var driver = _drivingService.GetDriver(fatigueCapcity);

            while (running)
            {
                MainMenu.ShowMainMenu();
                var selection = Console.ReadLine();

                switch (selection)
                {
                    case "1":
                        instruction = "Right";
                        _drivingService.Drive(instruction, car, driver);
                        Console.ReadKey();
                        break;
                    case "2":
                        instruction = "Left";
                        _drivingService.Drive(instruction, car, driver);
                        Console.ReadKey();
                        break;
                    case "3":
                        instruction = "Straight";
                        _drivingService.Drive(instruction, car, driver);
                        Console.ReadKey();
                        break;
                    case "4":
                        instruction = "Reverse";
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
                        Console.Write("\n\nPlease choose a valid option");
                        Console.ReadKey();
                        break;
                }

            }
        }
    }
}
