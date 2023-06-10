using CarSimulator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSimulator
{
    public class Application
    {
        public void Run()
        {
            while(true)
            {
                MainMenu.ShowMainMenu();
                var selection = MainMenu.GetSelection();

                if (selection == 7) return;

                switch (selection)
                {
                    case 1:
                        Console.WriteLine(selection);
                        break;
                    case 2:
                        Console.WriteLine(selection);
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
