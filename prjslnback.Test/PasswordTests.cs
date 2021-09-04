using Microsoft.Extensions.DependencyInjection;
using prjslnback.Domain.Interfaces;
using prjslnback.Domain.Services;
using Xunit;

namespace prjslnback.Test
{
    public class PasswordTests : IClassFixture<PasswordFixture>
    {
        private IPasswordService _service;

        public PasswordTests(PasswordFixture fixture)
        {
            this._service = fixture.Service;
        }

        [Fact]
        public void PasswordGeneration()
        {
            var password = this._service.Generate();
            Assert.NotNull(password);
        }

        [Fact]
        public void PasswordValidation()
        {
            var result1 = this._service.Validate("Tfh1pFvFG_XHnPJ");
            Assert.True(result1);

            var result2 = this._service.Validate("aaaaaaaaaaaaaa");
            Assert.False(result2);

            var result3 = this._service.Validate("1243");
            Assert.False(result3);

            var result4 = this._service.Validate(default);
            Assert.False(result4);
        }

        [Fact]
        public void PasswordGenerationAndValidation()
        {
            var password = this._service.Generate();
            var result = this._service.Validate(password);
            Assert.True(result);
        }

    }

    public class PasswordFixture
    {
        public IPasswordService Service { get; private set; }

        public PasswordFixture()
        {
            var sp = new ServiceCollection()
            .AddTransient<IPasswordService, PasswordService>()
            .BuildServiceProvider();

            this.Service = sp.GetRequiredService<IPasswordService>();
        }
    }
}
