using ServicesLibrary.Models;

namespace CarSimulator.Controller
{
    public interface ICarController
    {
        Car SetupCar();
        void Drive(string instruction, Car car);
    }
}