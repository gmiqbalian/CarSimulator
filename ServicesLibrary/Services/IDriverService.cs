using ServicesLibrary.Enums;
using ServicesLibrary.Models;

namespace ServicesLibrary.Services
{
    public interface IDriverService
    {
        Driver GetDriver();
        bool TakeRest(Driver driver);
        bool Eat(Driver driver);    
        HungerStatus CheckHunger(Driver driver);
    }
}