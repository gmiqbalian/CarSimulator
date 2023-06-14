using ServicesLibrary.Models;

namespace CarSimulator.Controller
{
    public interface IAppController
    {
        Car SetupCar();
        void Drive(string instruction, Car car);
        void RefuelTank(Car car);
    }
}