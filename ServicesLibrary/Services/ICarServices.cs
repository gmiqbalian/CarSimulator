using ServicesLibrary.Data;
using ServicesLibrary.Models;

namespace ServicesLibrary.Services
{
    public interface ICarServices
    {
        Car GetNewCar();
        void PrintNewDiretion(Car car, string driveTo);
        FuelEnum HasEnoughFuel(int fuelLevel);
        void PrintFuelWarning(int fuelLevel);
    }
}