using Api.Domain.Dtos;
using Api.Domain.Interfaces.Services.User;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Api.Service.Test.Login
{
    public class QuandoForExecutadoFindByLogin
    {
        private ILoginService _serviceLogin;
        private Mock<ILoginService> _serviceLoginMock;

        [Fact(DisplayName = "É Possivel executar o Método FindByLogin.")]
        public async Task E_Possivel_Executar_Metodo_FindByLogin()
        {
            var email = Faker.Internet.Email();
            var objetoRetorno = new
            {
                authenticated = true,
                create = DateTime.UtcNow,
                expiration = DateTime.UtcNow,
                accessToken = Guid.NewGuid(),
                userName = email,
                name = Faker.Name.FullName(),
                message = "Usuário Logado com sucesso"
            };

            var loginDto = new LoginDto
            {
                Email = email,
            };

            _serviceLoginMock = new Mock<ILoginService>();
            _serviceLoginMock.Setup(m => m.FindByLogin(loginDto)).ReturnsAsync(objetoRetorno);
            _serviceLogin = _serviceLoginMock.Object;

            var result = await _serviceLogin.FindByLogin(loginDto);
            Assert.NotNull(result);
        }
    }
}
