using ServicesLibrary.Enums;
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
            Instruction instruction;

            var car = _drivingService.SetupCar();

            while (running)
            {
                MainMenu.ShowMainMenu();
                var selection = Console.ReadLine();

                switch (selection)
                {
                    case "1":
                        instruction = Instruction.Right;
                        _drivingService.DriveCommand(instruction, car);
                        Console.ReadKey();
                        break;

                    case "2":
                        instruction = Instruction.Left;
                        _drivingService.DriveCommand(instruction, car);
                        Console.ReadKey();
                        break;

                    case "3":
                        instruction = Instruction.Straight;
                        _drivingService.DriveCommand(instruction, car);
                        Console.ReadKey();
                        break;

                    case "4":
                        instruction = Instruction.Reverse;
                        _drivingService.DriveCommand(instruction, car);
                        Console.ReadKey();
                        break;

                    case "5":
                        _drivingService.RestCommand(car.Driver);
                        Console.ReadKey();
                        break;

                    case "6":
                        _drivingService.RefuelCommand(car);
                        Console.ReadKey();
                        break;
                    
                    case "7":
                        running = false;
                        break;
                    
                    default:
                        Print.ErrorMessage("\nPlease choose a valid option");
                        Console.ReadKey();
                        break;
                }

            }
        }
    }
}
