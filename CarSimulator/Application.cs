﻿using ServicesLibrary.Enums;
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
            Console.Title = "Car Simulator";
            Console.CursorVisible = false;
            var running = true;

            var car = _drivingService.SetupCar();

            while (running)
            {
                ConsoleKey keyPressed;
                var selection = 0;

                do
                {
                    Console.Clear();
                    MainMenu.ShowMenu(selection);
                    keyPressed = Console.ReadKey(true).Key;
                    selection = MainMenu.GetSelection(selection, keyPressed);

                } while (keyPressed != ConsoleKey.Enter);
                

                switch (selection)
                {
                    case 0:
                        _drivingService.DriveCommand(Instruction.Right, car);
                        Print.PressAnyKey();
                        break;

                    case 1:
                        _drivingService.DriveCommand(Instruction.Left, car);
                        Print.PressAnyKey();
                        break;

                    case 2:
                        _drivingService.DriveCommand(Instruction.Straight, car);
                        Print.PressAnyKey();
                        break;

                    case 3:
                        _drivingService.DriveCommand(Instruction.Reverse, car);
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
