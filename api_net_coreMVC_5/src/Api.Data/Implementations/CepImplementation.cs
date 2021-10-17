using Api.Data.Context;
using Api.Data.Repository;
using Domain.Entities;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Data.Implementations
{
    public class CepImplementation : BaseRepository<CepEntity>, ICepRepository

    {
        private DbSet<CepEntity> _dataset;

        public CepImplementation(Mycontext context) : base(context)
        {
            _dataset = context.Set<CepEntity>();
        }

        public async Task<CepEntity> SelectAsync(string cep)
        {
            return await _dataset.Include(c => c.Municipio).ThenInclude(m => m.Uf).SingleOrDefaultAsync(u => u.Cep.Equals(cep));
        }
    }
}
