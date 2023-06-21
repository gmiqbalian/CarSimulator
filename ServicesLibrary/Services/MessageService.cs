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

            if (car.IsFuelWarning)
            {
                Print.WarningMessage($"\nFuel warning: {car.FuelLevel} / {car.MaxFuel}");
            }
            if (car.Driver.IsFatigueWarning)
            {
                Print.WarningMessage($"\nFatigue warning: {car.Driver.FatigueLevel} / {car.Driver.MaxFatigue}");
            }
        }
    }
}
