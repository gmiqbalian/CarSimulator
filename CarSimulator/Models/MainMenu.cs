using System;

namespace CarSimulator.Models
{
    class MainMenu
    {
        public static void ShowMainMenu()
        {
            Console.Clear();
            
            Console.WriteLine("1. Drive Right");
            Console.WriteLine("2. Drive Left");
            Console.WriteLine("3. Drive Straight");
            Console.WriteLine("4. Reverse");
            Console.WriteLine("5. Take Rest");
            Console.WriteLine("6. Refuel Tank");
            Console.WriteLine("7. Exit");
            Console.WriteLine();
            Console.Write("Please choose an option: ");
        }
    }
}
