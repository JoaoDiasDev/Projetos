using System.Threading.Tasks;
using Xunit;

namespace Api.Integration.Test
{
    public class TesteLogin : BaseIntegration
    {
        [Fact(DisplayName = "Teste de Integração")]
        public async Task TesteDoToken()
        {
            await AdicionarToken();
        }
    }
}
