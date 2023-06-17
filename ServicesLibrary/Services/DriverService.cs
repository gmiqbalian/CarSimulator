using ServicesLibrary.Enums;
using ServicesLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLibrary.Services
{
    public class DriverService
    {
        public FatigueStatus CheckFatigueLevel(Driver driver)
        {
            FatigueStatus status = new FatigueStatus();

            if (driver.FatigueLevel == driver.MaxFatigue)
                status = FatigueStatus.IsTired;
            if (driver.FatigueLevel > 3)
                status = FatigueStatus.Warning;
            if (driver.FatigueLevel == 0)
                status = FatigueStatus.Rested;

            return status;
        }
    }
}
