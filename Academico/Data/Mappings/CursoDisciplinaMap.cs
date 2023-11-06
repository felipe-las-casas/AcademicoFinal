using Academico.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Academico.Data.Mappings
{
    public class CursoDisciplinaMap : IEntityTypeConfiguration<CursoDisciplina>
    {
        public void Configure(EntityTypeBuilder<CursoDisciplina> builder)
        {
            builder.HasKey(x => new {x.DisciplinaId, x.CursoId});

            builder.HasOne(entity => entity.Curso).WithMany(entity => entity.CursoDisciplinas).HasForeignKey(x => x.CursoId);
            builder.HasOne(entity => entity.Disciplina).WithMany(entity => entity.CursosDisciplinas).HasForeignKey(x => x.DisciplinaId);
        }
    }
}
