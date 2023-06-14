using ServicesLibrary.Models;

namespace CarSimulator.Controller
{
    public interface IAppController
    {
        Car SetupCar();
        void Drive(string instruction, Car car, Driver driver);
        void RefuelTank(Car car);
        Driver GetDriver(int maxFatigue);
        public void TakeRest(Driver driver);
    }
}