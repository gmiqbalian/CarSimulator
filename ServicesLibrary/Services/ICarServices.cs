using ServicesLibrary.Data;
using ServicesLibrary.Models;

namespace ServicesLibrary.Services
{
    public interface ICarServices
    {
        Car GetNewCar(int maxFuel);
    }
}