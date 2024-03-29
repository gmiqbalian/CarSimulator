﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLibrary.Models
{
    public class Print
    {
        public static void StatusMessage(string message)
        {
            Console.Write(message);
        }
        public static void WarningMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(message);
            Console.ResetColor();
        }
        public static void SuccessMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(message);
            Console.ResetColor();
        }
        public static void ErrorMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(message);
            Console.ResetColor();
        }
        public static void HighlightedMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write(message);
            Console.BackgroundColor = ConsoleColor.White;
            Console.ResetColor();
        }
        public static void PressAnyKey()
        {
            Console.Write("\n\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
