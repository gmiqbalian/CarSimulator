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
        
        private readonly ICarController _carController;

        public Application(ICarController carController)
        {
            _carController = carController;
        }
        public void Run()
        {
            var instruction = string.Empty;
            var car = _carController.SetupCar();

            while (true)
            {
                MainMenu.ShowMainMenu();
                var selection = MainMenu.GetSelection();

                if (selection == 7) return;

                switch (selection)
                {
                    case 1:
                        instruction = "Right";
                        _carController.Drive(instruction, car);

                        Console.ReadKey();
                        break;
                    case 2:
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.ReadKey();
                        break;
                    case 4:
                        Console.ReadKey();
                        break;
                }

            }
        }
    }
}
