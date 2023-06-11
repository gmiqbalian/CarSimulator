using ServicesLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLibrary.Services
{
    public class CarServices : ICarServices
    {
        public Car GetNewCar()
        {
            var car = new Car();
            return car;
        }
    }
}
