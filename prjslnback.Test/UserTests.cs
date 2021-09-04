using Microsoft.Extensions.DependencyInjection;
using prjslnback.Domain.Interfaces;
using prjslnback.Domain.Services;
using Xunit;

namespace prjslnback.Test
{
    public class UserTests : IClassFixture<UserFixture>
    {
        
        private IUserService _service;

        public UserTests(UserFixture fixture)
        {
            this._service = fixture.Service;
        }
     
        [Fact]
        public void FindUser()
        {
            var result1 = this._service.FindUser("Usuario1", "Senha1");
            Assert.NotNull(result1);
            Assert.Equal("Usuario1", result1.Username);
            Assert.Equal("Senha1", result1.Password);
            Assert.Equal(1, result1.Id);

            var result2 = this._service.FindUser("Usuario1", "Senha2");
            Assert.Null(result2);
        }

    }

    public class UserFixture
    {
        public IUserService Service { get; private set; }

        public UserFixture()
        {
            var sp = new ServiceCollection()
            .AddTransient<IUserService, UserService>()
            .BuildServiceProvider();

            this.Service = sp.GetRequiredService<IUserService>();
        }
    }
}
