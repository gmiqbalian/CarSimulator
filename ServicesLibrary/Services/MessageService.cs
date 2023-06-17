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
    public class MessageService
    {
        public void PrintStatusMessage(Car car, Driver driver, string instruction)
        {
            Print.StatusMessage($"Car is moving: {instruction}");
            Print.StatusMessage($"Direction: {car.Direction}");

            if (IsFuelWarning(car))
            {
                Print.WarningMessage($"Fuel warning: {car.FuelLevel} / {car.MaxFuel}");
            }
            if (IsFatigueWarning(driver))
            {
                Print.WarningMessage($"Fatigue warning: {driver.FatigueLevel} / {driver.MaxFatigue}");
            }

        }
        private bool IsFuelWarning(Car car)
        {
            return true;
        }

        private bool IsFatigueWarning(Driver driver)
        {
            return true;
        }
    }
}
