using prjslnback.Domain.Entities;

namespace prjslnback.Domain.Interfaces
{
    public interface IUserService
    {
        User FindUser(string username, string password);
    }
}
