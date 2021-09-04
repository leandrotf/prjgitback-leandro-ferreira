namespace prjslnback.Domain.Interfaces
{
    public interface IPasswordService
    {
        string Generate();
        bool Validate(string password);

    }
}
