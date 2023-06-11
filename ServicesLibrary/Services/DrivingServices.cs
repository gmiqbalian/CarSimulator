using ServicesLibrary.Models;
using System.Drawing;

namespace ServicesLibrary.Services
{
    public class DrivingServices : IDrivingServices
    {
        public IDriverServices _driverServices { get; }
        public ICarServices _carServices { get; }

        public DrivingServices(IDriverServices driverServices, ICarServices carServices)
        {
            _driverServices = driverServices;
            _carServices = carServices;
        }
        public void Drive(string currentDirection, string driveTo)
        {
            var car = _carServices.GetNewCar();
            var driver = _driverServices.GetDriver();

            car.Direction = GetCarDiretion(currentDirection, driveTo);
            car.FuelLevel--;
            driver.Fatigue++;

            Console.WriteLine();
            Console.WriteLine($"Driver drives to: {driveTo}");
            Console.WriteLine($"Car direction is: {car.Direction}");
            Console.WriteLine("Fuel level: ");
            Console.WriteLine("Driver rest status: ");


        }
        public void PrintFuelStatus()
        {
            Console.WriteLine();
        }
        public void PrintDriverRestStatus()
        {
            Console.WriteLine();
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
