using ServicesLibrary.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLibrary.Models
{
    public class Car
    {
        public int MaxFuel { get; } = 20;
        public int FuelLevel { get; protected set; }
        public string? Direction { get; set; }
        public Driver Driver { get; set; }
        public bool IsTankEmpty { get => FuelLevel == 0; }
        public bool IsTankFull { get => FuelLevel == MaxFuel; }
        public bool IsFuelWarning { get => FuelLevel >= 0 && FuelLevel <= 5; }
        public Car()
        {
            FuelLevel = MaxFuel;
        }
        public void Refuel()
        {
            FuelLevel = MaxFuel;
        }
        public void ConsumeFuel()
        {
            FuelLevel--;
        }
        public void ChangeDirection(Instruction instruction)
        {
            if (instruction == Instruction.Right)
            {
                switch (Direction)
                {
                    case "North":
                        Direction = "East";
                        break;

                    case "East":
                        Direction = "South";
                        break;

                    case "South":
                        Direction = "West";
                        break;

                    case "West":
                        Direction = "North";
                        break;
                }
            }
            if (instruction == Instruction.Left)
            {
                switch (Direction)
                {
                    case "North":
                        Direction = "West";
                        break;

                    case "West":
                        Direction = "South";
                        break;

                    case "South":
                        Direction = "East";
                        break;

                    case "East":
                        Direction = "North";
                        break;
                }
            }
        }
    }

}
