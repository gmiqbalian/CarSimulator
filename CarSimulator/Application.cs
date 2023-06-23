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
            Console.CursorVisible = false;
            var running = true;
            Instruction instruction;

            var car = _drivingService.SetupCar();

            while (running)
            {
                int selection = MainMenu.GetSelection();

                switch (selection)
                {
                    case 0:
                        instruction = Instruction.Right;
                        _drivingService.DriveCommand(instruction, car);
                        Print.PressAnyKey();
                        break;

                    case 1:
                        instruction = Instruction.Left;
                        _drivingService.DriveCommand(instruction, car);
                        Print.PressAnyKey();
                        break;

                    case 2:
                        instruction = Instruction.Straight;
                        _drivingService.DriveCommand(instruction, car);
                        Print.PressAnyKey();
                        break;

                    case 3:
                        instruction = Instruction.Reverse;
                        _drivingService.DriveCommand(instruction, car);
                        Print.PressAnyKey();
                        break;

                    case 4:
                        _drivingService.RestCommand(car.Driver);
                        Print.PressAnyKey();
                        break;

                    case 5:
                        _drivingService.RefuelCommand(car);
                        Print.PressAnyKey();
                        break;

                    case 6:
                        _drivingService.IntroductionCommand(car.Driver);
                        Print.PressAnyKey();
                        break;

                    case 7:
                        running = false;
                        break;
                }
            }
        }
    }
}
