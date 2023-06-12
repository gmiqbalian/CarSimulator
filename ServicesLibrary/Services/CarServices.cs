using ServicesLibrary.Data;
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
        private List<String> Directions = new List<string> { "North", "East", "South", "West" };
        public Car GetNewCar()
        {
            var car = new Car();
            car.FuelLevel = 20;

            var random = new Random();
            car.Direction = Directions[random.Next(Directions.Count)];

            return car;
        }
        public void PrintNewDiretion(Car car, string instruction)
            {
            var newDirection = string.Empty;
            var index = Directions.IndexOf(car.Direction);
            var newIndex = 0;

            if (instruction == "Right")
            {
                if (index != Directions.Count - 1)
                    newIndex = index + 1;

                newDirection = Directions[newIndex];
            }
            if (instruction == "Left")
            {
                if (index == 0)
                    newIndex = Directions.Count - 1;
                else
                    newIndex = index - 1;

                newDirection = Directions[newIndex];
            }

            car.Direction = newDirection;
            Console.WriteLine(newDirection);
        }
        public FuelEnum HasEnoughFuel(int fuelLevel)
        {
            if (fuelLevel == 20)
                return FuelEnum.Full;
            else if (fuelLevel > 0 && fuelLevel <= 5)
                return FuelEnum.Warning;
            else if (fuelLevel == 0)
                return FuelEnum.Empty;

            return FuelEnum.Enough;
        }
        public void PrintFuelWarning(int fuelLevel)
        {
            int totalLevel = 20;

            if (fuelLevel >= 3 && fuelLevel < 5)
                Console.WriteLine($"Fuel level: {fuelLevel} / {totalLevel} Green");
            else if (fuelLevel < 3)
                Console.WriteLine($"Fuel level: {fuelLevel} / {totalLevel} Red");

        }
    }
}
