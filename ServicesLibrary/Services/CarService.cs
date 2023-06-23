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
        private readonly List<String> Directions = new List<string> { "North", "East", "South", "West" }; //try to use enum instead

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
        public bool Refuel(Car car)
        {
            if (car.IsTankFull)
            {
                Print.ErrorMessage("\nTank is already full!");
                return false;
            }

            car.Driver.IncreaseFatigue();
            car.Refuel();
            Print.SuccessMessage("\nTank is refueled to full capacity.");
            return true;
        }
    }
}
