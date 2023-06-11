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
        private readonly IDrivingServices _drivingServices;
        private readonly IDriverServices _driverServices;

        public Application(IDrivingServices drivingServices, IDriverServices driverServices)
        {
            _drivingServices = drivingServices;
            _driverServices = driverServices;
        }
        public void Run()
        {
            while (true)
            {
                MainMenu.ShowMainMenu();
                var selection = MainMenu.GetSelection();

                if (selection == 7) return;

                switch (selection)
                {
                    case 1:
                        _drivingServices.Drive("South", "right");
                        _driverServices.GetDriver();
                        Console.ReadKey();
                        break;
                    case 2:
                        _drivingServices.Drive("South", "left");
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.WriteLine(selection);
                        break;
                    case 4:
                        Console.WriteLine(selection);
                        break;
                }

            }
        }
    }
}
