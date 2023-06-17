using ServicesLibrary.Models;

namespace ServicesLibrary.Services
{
    public interface IMessageService
    {
        void PrintStatusMessage(Car car, Driver driver, string instruction);
    }
}