using Microsoft.Extensions.DependencyInjection;
using prjslnback.Domain.Interfaces;
using prjslnback.Domain.Services;
using System.IdentityModel.Tokens.Jwt;
using Xunit;

namespace prjslnback.Test
{
    public class TokenTests : IClassFixture<TokenFixture>
    {
        private ITokenService _service;

        public TokenTests(TokenFixture fixture)
        {
            this._service = fixture.Service;
        }

        [Fact]
        public void TokenGeneration()
        {
            var token = this._service.GenerateToken();
            Assert.NotNull(token);

            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(token);
            var tokenS = jsonToken as JwtSecurityToken;
            var timespan = tokenS.ValidTo - tokenS.ValidFrom;

            Assert.Equal(5, timespan.Minutes);

        }
    }

    public class TokenFixture
    {
        public ITokenService Service { get; private set; }

        public TokenFixture()
        {
            var sp = new ServiceCollection()
            .AddTransient<ITokenService, TokenService>()
            .BuildServiceProvider();

            this.Service = sp.GetRequiredService<ITokenService>();
        }
    }
}
