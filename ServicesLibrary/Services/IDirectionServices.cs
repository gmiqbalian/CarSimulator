namespace ServicesLibrary.Services
{
    public interface IDirectionServices
    {
        string GetNewDirection(string currentDirection, string instruction);
        string GetCurrentDirection();
    }
}