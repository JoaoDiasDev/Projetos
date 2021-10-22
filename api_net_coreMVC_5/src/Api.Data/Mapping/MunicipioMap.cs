using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
    public class MunicipioMap : IEntityTypeConfiguration<MunicipioEntity>
    {
        public void Configure(EntityTypeBuilder<MunicipioEntity> builder)
        {
            builder.ToTable("Municipio");

            builder.HasKey(m => m.Id);

            builder.HasIndex(m => m.CodIBGE);

            builder.HasOne(m => m.Uf).WithMany(m => m.Municipios);
        }
    }
}
