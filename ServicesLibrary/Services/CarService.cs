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
    public class CarService
    {
        private readonly List<String> Directions = new List<string> { "North", "East", "South", "West" };
        public Car GetCar(int fuelCapacity)
        {
            var car = new Car();

            car.MaxFuel = fuelCapacity;
            car.FuelLevel = car.MaxFuel;

            var random = new Random();
            var index = random.Next(Directions.Count());
            car.Direction = Directions[index];

            return car;
        }
        public FuelStatus CheckFuel(Car car)
        {
            if (car.FuelLevel == 0)
                return FuelStatus.Empty;
            if (car.FuelLevel > 0 && car.FuelLevel <= 5)
                return FuelStatus.Warning;
            
            return FuelStatus.Full;
        }
        public void PrintStatusMessage(string instruction)
        {
            Print.StatusMessage($"Car is moving: {instruction}");
        }
        public string Move(string instruction)
        {
            return $"Car is moving: {instruction}";
        }
        public string ChangeDirection(string instruction, Car car)
        {            
            if (instruction.ToLower() == "right")
            {
                switch (car.Direction)
                {
                    case "North":
                        car.Direction = "East";
                        break;
                    case "East":
                        car.Direction = "South";
                        break;
                    case "South":
                        car.Direction = "West";
                        break;
                    case "West":
                        car.Direction = "North";
                        break;
                }
            }
            if (instruction.ToLower() == "left")
            {
                switch (car.Direction)
                {
                    case "North":
                        car.Direction = "West";
                        break;
                    case "West":
                        car.Direction = "South";
                        break;
                    case "South":
                        car.Direction = "East";
                        break;
                    case "East":
                        car.Direction = "North";
                        break;
                }
            }
            return $"\nDirection is: {car.Direction}";
        }
    }
}
