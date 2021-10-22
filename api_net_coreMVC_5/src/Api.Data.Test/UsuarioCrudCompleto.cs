using Api.Data.Context;
using Api.Data.Implementations;
using Api.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Api.Data.Test
{
    public class UsuarioCrudCompleto : BaseTest, IClassFixture<DbTeste>
    {
        private readonly ServiceProvider _serviceProvider;

        public UsuarioCrudCompleto(DbTeste dbTeste)
        {
            _serviceProvider = dbTeste.ServiceProvider;
        }

        [Fact(DisplayName = "CRUD de Usuário")]
        [Trait("CRUD", "UserEntity")]
        public async Task E_Possivel_Realizar_CRUD_Usuario()
        {
            using var context = _serviceProvider.GetService<Mycontext>();
            UserImplementation _repositorio = new(context);
            UserEntity _entity = new()
            {
                Email = Faker.Internet.Email(),
                Name = Faker.Name.FullName()
            };

            var _registroCriado = await _repositorio.InsertAsync(_entity);
            Assert.NotNull(_registroCriado);
            Assert.Equal(_entity.Email, _registroCriado.Email);
            Assert.Equal(_entity.Name, _registroCriado.Name);
            Assert.False(_registroCriado.Id == System.Guid.Empty);

            _entity.Name = Faker.Name.First();
            var _registroAtualizado = await _repositorio.UpdateAsync(_entity);
            Assert.NotNull(_registroAtualizado);
            Assert.Equal(_entity.Email, _registroAtualizado.Email);
            Assert.Equal(_entity.Name, _registroAtualizado.Name);

            var _registroExiste = await _repositorio.ExistAsync(_registroAtualizado.Id);
            Assert.True(_registroExiste);

            var _registroSelecionado = await _repositorio.SelectAsync(_registroAtualizado.Id);
            Assert.NotNull(_registroSelecionado);
            Assert.Equal(_registroAtualizado.Email, _registroSelecionado.Email);
            Assert.Equal(_registroAtualizado.Name, _registroSelecionado.Name);

            var _todosRegistros = await _repositorio.SelectAsync();
            Assert.NotNull(_todosRegistros);
            Assert.True(_todosRegistros.Count() > 1);

            var _deletarRegistro = await _repositorio.DeleteAsync(_registroSelecionado.Id);
            Assert.True(_deletarRegistro);

            var _usuarioPadrao = await _repositorio.FindByLogin("joaodiasworking@gmail.com");
            Assert.NotNull(_usuarioPadrao);
            Assert.Equal("joaodiasworking@gmail.com", _usuarioPadrao.Email);
            Assert.Equal("Administrator", _usuarioPadrao.Name);

        }
    }
}
