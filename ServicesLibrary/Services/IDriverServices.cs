using ServicesLibrary.Models;

namespace ServicesLibrary.Services
{
    public interface IDriverServices
    {
        Task<Driver> GetDriver();
        void PrintDriverStatus(Driver driver);
    }
}