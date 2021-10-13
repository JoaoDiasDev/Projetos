using Api.Domain.Dtos.User;
using Api.Domain.Interfaces.Services.User;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Api.Service.Test.Usuario
{
    public class QuandoForExecutadoGet : UsuarioTestes
    {
        private IUserService _userService;
        private Mock<IUserService> _userServiceMock;

        [Fact(DisplayName = "É Possivel Executar o Método Get.")]
        public async Task E_Possivel_Executar_Motodo_Get()
        {
            _userServiceMock = new Mock<IUserService>();
            _userServiceMock.Setup(m => m.Get(IdUsuario)).ReturnsAsync(userDto);
            _userService = _userServiceMock.Object;

            var result = await _userService.Get(IdUsuario);
            Assert.NotNull(result);
            Assert.True(result.Id == IdUsuario);
            Assert.Equal(NomeUsuario, result.Name);

            _userServiceMock = new Mock<IUserService>();
            _userServiceMock.Setup(m => m.Get(It.IsAny<Guid>())).Returns(Task.FromResult((UserDto)null));
            _userService = _userServiceMock.Object;

            var _record = await _userService.Get(IdUsuario);
            Assert.Null(_record);

        }
    }
}
