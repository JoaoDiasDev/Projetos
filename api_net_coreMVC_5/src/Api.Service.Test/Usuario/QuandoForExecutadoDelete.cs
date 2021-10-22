using Api.Domain.Interfaces.Services.User;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Api.Service.Test.Usuario
{
    public class QuandoForExecutadoDelete : UsuarioTestes
    {
        private IUserService _userService;
        private Mock<IUserService> _userServiceMock;

        [Fact(DisplayName = "É possivel executar método Delete.")]
        public async Task E_Possivel_Executar_Metodo_Delete()
        {
            _userServiceMock = new Mock<IUserService>();
            _userServiceMock.Setup(m => m.Delete(IdUsuario)).ReturnsAsync(true);
            _userService = _userServiceMock.Object;

            var deletado = await _userService.Delete(IdUsuario);
            Assert.True(deletado);

            _userServiceMock = new Mock<IUserService>();
            _userServiceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(false);
            _userService = _userServiceMock.Object;

            deletado = await _userService.Delete(Guid.NewGuid());
            Assert.False(deletado);
        }
    }
}
