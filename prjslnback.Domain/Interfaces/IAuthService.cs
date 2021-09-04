using prjslnback.Domain.Response;

namespace prjslnback.Domain.Interfaces
{
    public interface IAuthService
    {
        TokenResponse Login(string username, string password);
    }
}
