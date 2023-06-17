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
        public void PrintStatusMessage(Car car, Driver driver, string instruction)
        {
            Print.StatusMessage($"\nCar is moving: {instruction}");
            Print.StatusMessage($"\nDirection: {car.Direction}");

            if (IsFuelWarning(car))
            {
                Print.WarningMessage($"\nFuel warning: {car.FuelLevel} / {car.MaxFuel}");
            }
            if (IsFatigueWarning(driver))
            {
                Print.WarningMessage($"\nFatigue warning: {driver.FatigueLevel} / {driver.MaxFatigue}");
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
