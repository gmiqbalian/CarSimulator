using ServicesLibrary.Models;

namespace ServicesLibrary.Services
{
    public interface IMessageService
    {
        void PrintStatusMessage(Car car, string instruction);
    }
}