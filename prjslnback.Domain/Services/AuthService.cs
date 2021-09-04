using prjslnback.Domain.Interfaces;
using prjslnback.Domain.Response;
using System.IdentityModel.Tokens.Jwt;

namespace prjslnback.Domain.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;

        public AuthService(IUserService userService,
                           ITokenService tokenService)
        {
            this._userService = userService;
            this._tokenService = tokenService;
        }

        public TokenResponse Login(string username, string password)
        {
            var user = this._userService.FindUser(username, password);

            if (user == null) return new TokenResponse();

            var token = this._tokenService.GenerateToken();

            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(token);
            var tokenS = jsonToken as JwtSecurityToken;            

            return new TokenResponse()
            {
                UserName = username,
                Authenticated = true,
                Token = token,
                ValidUntil = tokenS.ValidTo
            };
        }
    }
}
