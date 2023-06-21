using ServicesLibrary.Enums;
using ServicesLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLibrary.Services
{
    public interface ICarService
    {
        Car CreateCar();
        void Drive(Car car, Instruction instruction);
        bool Refuel(Car car);
    }
}
