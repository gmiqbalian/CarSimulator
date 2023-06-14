using ServicesLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLibrary.Services
{
    public class DirectionServices : IDirectionServices
    {
        private List<String> Directions = new List<string> { "North", "East", "South", "West" };
        public string GetNewDirection(string currentDirection, string instruction)
        {
            var newDirection = string.Empty;
            var index = Directions.IndexOf(currentDirection);
            var newIndex = 0;

            if (instruction == "Right")
            {
                if (index != Directions.Count - 1)
                    newIndex = index + 1;

                newDirection = Directions[newIndex];
            }
            else if (instruction == "Left")
            {
                if (index == 0)
                    newIndex = Directions.Count - 1;
                else
                    newIndex = index - 1;

                newDirection = Directions[newIndex];
            }

            return newDirection;
        }
        public string GetCurrentDirection()
        {
            var random = new Random();
            return Directions[random.Next(Directions.Count)];
        }
    }
}
