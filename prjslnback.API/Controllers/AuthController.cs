using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using prjslnback.API.ViewModels;
using prjslnback.Domain.Interfaces;
using prjslnback.Domain.Response;

namespace prjslnback.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IPasswordService _passwordService;

        public AuthController(IAuthService authService, IPasswordService _passwordService)
        {
            this._authService = authService;
            this._passwordService = _passwordService;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public TokenResponse Login(Credential credential)
        {
            return this._authService.Login(credential.UserName, credential.Password);
        }

        [HttpPost]
        [Route("validate-password")]
        public bool ValidatePassword([FromBody] string password)
        {
            return this._passwordService.Validate(password);
        }

        [HttpGet]
        [Route("generate-password")]
        public string GeneratePassword()
        {
            return this._passwordService.Generate();
        }
    }
}
