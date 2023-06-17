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
        Car CreateCar(int fuelCapacity);
        void ChangeDirection(string instruction, Car car);
    }
}
