using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLibrary.Models
{
    public class MainMenu
    {
        public static void ShowLogo()
        {
            string logo =
            @"
               _____              _____ _                 _       _             
              / ____|            / ____(_)               | |     | |            
             | |     __ _ _ __  | (___  _ _ __ ___  _   _| | __ _| |_ ___  _ __ 
             | |    / _` | '__|  \___ \| | '_ ` _ \| | | | |/ _` | __/ _ \| '__|
             | |___| (_| | |     ____) | | | | | | | |_| | | (_| | || (_) | |   
              \_____\__,_|_|    |_____/|_|_| |_| |_|\__,_|_|\__,_|\__\___/|_|   
            ";
            Console.WriteLine(logo);
        }
        public static void ShowMenu(int selection)
        {
            ShowLogo();

            var options = new List<String>()
            {
                "Drive Right",
                "Drive Left",
                "Drive Straight",
                "Reverse",
                "Take Rest",
                "Refuel Tank",
                "Driver details",
                "Exit"
            };
            
            var prefix = string.Empty;
            for (var i = 0; i < options.Count; i++)
            {
                if (i == selection) { prefix = ">"; }
                else { prefix = ""; }

                Console.WriteLine($"{prefix} {options[i]}");
            }

            Print.StatusMessage("\nPress \"arrow\" keys to navigate and \"Enter\" to select\n");
        }

        public static int GetSelection(int selection, ConsoleKey keyPressed)
        {
            if (keyPressed == ConsoleKey.UpArrow)
                selection = selection == 0 ? 7 : selection - 1;
            else if (keyPressed == ConsoleKey.DownArrow)
                selection = selection == 7 ? 0 : selection + 1;

            return selection;
        }
    }
}
