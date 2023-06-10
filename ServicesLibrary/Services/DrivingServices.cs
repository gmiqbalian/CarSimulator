using System.Drawing;

namespace ServicesLibrary.Services
{
    public class DrivingServices : IDrivingServices
    {
        public void Drive(string direction)
        {
            Console.WriteLine($"Driver drives to the {direction}");
            Console.WriteLine("Car direction is: ");
            Console.WriteLine("Fuel level: ", Color.Green);
            Console.WriteLine("Driver rest status: ", Color.Red);
        }
    }
}
