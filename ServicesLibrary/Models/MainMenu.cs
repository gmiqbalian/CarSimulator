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
        public static void ShowMainMenu()
        {
            Console.WriteLine("1. Drive Right");
            Console.WriteLine("2. Drive Left");
            Console.WriteLine("3. Drive Straight");
            Console.WriteLine("4. Reverse");
            Console.WriteLine("5. Take Rest");
            Console.WriteLine("6. Refuel Tank");
            Console.WriteLine("7. Driver details");
            Console.WriteLine("8. Exit");

            Console.WriteLine();

            Console.Write("Please choose an option: ");
        }
    }
}
