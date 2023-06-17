using ServicesLibrary.Enums;
using ServicesLibrary.Models;

namespace ServicesLibrary.Services
{
    public interface IDriverService
    {
        FatigueStatus CheckFatigueLevel(Driver driver);
        Driver GetDriver(int fatigueCapacity);
    }
}