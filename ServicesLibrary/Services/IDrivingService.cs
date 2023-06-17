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
        Car GetCar(int fuelCapacity);
        Driver GetDriver(int fatigueCapacity);
        Status Drive(string instruction, Car car, Driver driver);
        Status TakeRest(Driver driver);
        Status Refuel(Car car);
    }
}
