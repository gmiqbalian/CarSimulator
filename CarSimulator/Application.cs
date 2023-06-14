using CarSimulator.Controller;
using CarSimulator.Models;
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

        private readonly IAppController _appController;

        public Application(IAppController appController)
        {
            _appController = appController;
        }
        public void Run()
        {
            var running = true;
            var instruction = string.Empty;
            var car = _appController.SetupCar();

            while (running)
            {
                MainMenu.ShowMainMenu();
                var selection = Console.ReadLine();

                switch (selection)
                {
                    case "1":
                        instruction = "Right";
                        _appController.Drive(instruction, car);
                        Console.ReadKey();
                        break;
                    case "2":
                        instruction = "Left";
                        _appController.Drive(instruction, car);
                        Console.ReadKey();
                        break;
                    case "3":
                        instruction = "Straight";
                        _appController.Drive(instruction, car);
                        Console.ReadKey();
                        break;
                    case "4":
                        instruction = "Reverse";
                        _appController.Drive(instruction, car);
                        Console.ReadKey();
                        break;
                    case "5":
                        Console.ReadKey();
                        break;
                    case "6":
                        _appController.RefuelTank(car);
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
