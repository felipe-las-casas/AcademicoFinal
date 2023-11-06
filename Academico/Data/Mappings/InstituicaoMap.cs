using Academico.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Academico.Data.Mappings
{
    public class InstituicaoMap : IEntityTypeConfiguration<Instituicao>
    {
        public void Configure(EntityTypeBuilder<Instituicao> builder)
        {
            builder.HasKey(entity => entity.InstituicaoID);
            builder.HasMany(entity => entity.Departamentos).WithOne(entity => entity.Instituicao).HasForeignKey(x => x.InstituicaoID);
        }
    }
}
