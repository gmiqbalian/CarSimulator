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
    public class CarService : ICarService
    {
        private readonly List<String> Directions = new List<string> { "North", "East", "South", "West" };

        public Car CreateCar()
        {
            var car = new Car();
                        
            var random = new Random();
            var index = random.Next(Directions.Count());
            car.Direction = Directions[index];

            return car;
        }
        public void Drive(Car car, Instruction instruction)
        {
            car.ConsumeFuel();
            car.ChangeDirection(instruction);
            car.Driver.IncreaseFatigue();
        }
        public void Refuel(Car car)
        {
            if (!car.IsTankEmpty)
            {
                Print.ErrorMessage("\nTank is already full!");
                return;
            }

            car.Refuel();
            Print.SuccessMessage("\nTank is refueled to full capacity.");
        }
    }
}
