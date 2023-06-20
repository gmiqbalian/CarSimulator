using ServicesLibrary.Enums;
using ServicesLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLibrary.Services
{
    public class MessageService : IMessageService
    {
        public void PrintStatusMessage(Car car, string instruction)
        {
            Print.StatusMessage($"\nCar is moving: {instruction}");
            Print.StatusMessage($"\nDirection: {car.Direction}");

            if (IsFuelWarning(car))
            {
                Print.WarningMessage($"\nFuel warning: {car.FuelLevel} / {car.MaxFuel}");
            }
            if (IsFatigueWarning(car.Driver))
            {
                Print.WarningMessage($"\nFatigue warning: {car.Driver.FatigueLevel} / {car.Driver.MaxFatigue}");
            }

            Print.StatusMessage("\n\nPress any key to continue...");
        }

        private bool IsFuelWarning(Car car)
        {
            return car.FuelLevel >= 0 && car.FuelLevel <= 5;
        }
        private bool IsFatigueWarning(Driver driver)
        {
            return driver.FatigueLevel >= 7;
        }
    }
}
