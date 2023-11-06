using Academico.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Academico.Data.Mappings
{
    public class DepartamentoMap : IEntityTypeConfiguration<Departamento>
    {
        public void Configure(EntityTypeBuilder<Departamento> builder)
        {
            builder.HasKey(entity => entity.DepartamentoId);
            builder.HasOne(entity => entity.Instituicao).WithMany(entity => entity.Departamentos).HasForeignKey(entity => entity.InstituicaoID);
        }
    }
}
