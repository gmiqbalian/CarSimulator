using ServicesLibrary.Enums;
using ServicesLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLibrary.Services
{
    public interface IDrivingService
    {
        Car SetupCar();
        void DriveCommand(Instruction instruction, Car car);
        Status RestCommand(Driver driver);
        Status RefuelCommand(Car car);
    }
}
