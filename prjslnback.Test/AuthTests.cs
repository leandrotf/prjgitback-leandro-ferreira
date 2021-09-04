using Microsoft.Extensions.DependencyInjection;
using prjslnback.Domain.Interfaces;
using prjslnback.Domain.Services;
using Xunit;

namespace prjslnback.Test
{
    public class AuthTests : IClassFixture<AuthFixture>
    {
        private IAuthService _service;

        public AuthTests(AuthFixture fixture)
        {
            this._service = fixture.Service;
        }

        [Fact]
        public void Login()
        {
            var result1 = this._service.Login("Usuario1", "Senha1");
            Assert.NotNull(result1);
            Assert.Equal("Usuario1", result1.UserName);
            Assert.True(result1.Authenticated);
            Assert.NotNull(result1.Token);

            var result2 = this._service.Login("Usuario1", "Senha2");
            Assert.NotNull(result2);
            Assert.Null(result2.UserName);
            Assert.False(result2.Authenticated);
            Assert.Null(result2.Token);
        }

    }

    public class AuthFixture
    {
        public IAuthService Service { get; private set; }

        public AuthFixture()
        {
            var sp = new ServiceCollection()
            .AddTransient<IAuthService, AuthService>()
            .AddTransient<IUserService, UserService>()
            .AddTransient<ITokenService, TokenService>()
            .BuildServiceProvider();

            this.Service = sp.GetRequiredService<IAuthService>();
        }
    }
}
