using ServicesLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLibrary.Services
{
    public class MessageService
    {
        public void PrintErrorMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void PrintWarning(string type, int currentLevel, int maxLevel)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{type} warning: {currentLevel} / {maxLevel}");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void PrintCarStatus(string instruction, Car car)
        {
            if (instruction == "right")
                Console.WriteLine("Car is turning right.");
            else if (instruction == "left")
                Console.WriteLine("Car is turning left.");
            else if (instruction == "straight")
                Console.WriteLine("Car is going straight.");
            else if (instruction == "reverse")
                Console.WriteLine("Car is reversing.");

            Console.WriteLine($"Car direction: {car.Direction}");
        }

        internal void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
