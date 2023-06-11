using System.Drawing;
using Console = Colorful.Console;

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
        }
        public static int GetSelection()
        {
            Console.Write("Choose an option: ");
            var selection = int.Parse(Console.ReadLine());
            
            if (selection > 7 || selection < 1)
            {
                Console.WriteLine("Please choose a valid option", Color.Red);
                Thread.Sleep(1000);
            }

            return selection;
        }
    }
}
