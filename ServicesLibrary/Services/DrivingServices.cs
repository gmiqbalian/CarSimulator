using ServicesLibrary.Models;
using System.Drawing;

namespace ServicesLibrary.Services
{
    public class DrivingServices : IDrivingServices
    {
        public void Drive(string instruction)
        {
            Console.WriteLine();
            Console.WriteLine($"Driver drives to: {instruction}");
        }
    }
}
