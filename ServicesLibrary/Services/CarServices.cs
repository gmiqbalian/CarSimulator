using ServicesLibrary.Data;
using ServicesLibrary.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLibrary.Services
{
    public class CarServices : ICarServices
    {
        public Car GetNewCar(int maxFuel)
        {
            var car = new Car();
            car.MaxFuel = maxFuel;
            car.FuelLevel = maxFuel;

            return car;
        }
    }
}
