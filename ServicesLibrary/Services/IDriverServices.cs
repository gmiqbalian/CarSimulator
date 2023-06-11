using ServicesLibrary.Models;

namespace ServicesLibrary.Services
{
    public interface IDriverServices
    {
        void FetchDriverFromAPI();
        Driver GetDriver();
        void PrintDriverStatus(Driver driver);
    }
}