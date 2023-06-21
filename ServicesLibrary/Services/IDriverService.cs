using ServicesLibrary.Enums;
using ServicesLibrary.Models;

namespace ServicesLibrary.Services
{
    public interface IDriverService
    {
        Driver GetDriver();
        bool TakeRest(Driver driver);
    }
}