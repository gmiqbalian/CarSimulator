using ServicesLibrary.Models;
using System.Drawing;

namespace ServicesLibrary.Services
{
    public class DrivingServices : IDrivingServices
    {
        public void Drive(string currentDirection, string driveTo)
        {
            var direction = GetCarDiretion(currentDirection, driveTo);

            Console.WriteLine();
            Console.WriteLine($"Driver drives to the {driveTo}");
            Console.WriteLine($"Car direction is: {direction}");
            Console.WriteLine("Fuel level: ");
            Console.WriteLine("Driver rest status: ");
        }
        public string GetCarDiretion(string currentDirection, string driveTo)
        {
            var directions = new List<string> { "North", "East", "South", "West" };
            var returnDirection = string.Empty;

            if (directions.Contains(currentDirection))
            {
                var index = directions.IndexOf(currentDirection);
                var requiredIndex = 0;

                if (driveTo == "right")
                {
                    if (index != directions.Count - 1)
                        requiredIndex = index + 1;

                    return returnDirection = directions[requiredIndex];
                }
                if (driveTo == "left")
                {
                    if (index == 0)
                        requiredIndex = directions.Count - 1;
                    else
                        requiredIndex = index - 1;

                    return returnDirection = directions[requiredIndex];
                }

            }
            return returnDirection;
        }
    }
}
