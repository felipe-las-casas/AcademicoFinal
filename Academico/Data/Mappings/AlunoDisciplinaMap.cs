using Academico.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Academico.Data.Mappings
{
    public class AlunoDisciplinaMap : IEntityTypeConfiguration<AlunoDisciplina>
    {
        public void Configure(EntityTypeBuilder<AlunoDisciplina> builder)
        {
            builder.HasKey(x => new { x.AlunoId, x.DisciplinaId, x.Semestre, x.Ano });

            builder.HasOne(entity => entity.Aluno).WithMany(entity => entity.AlunosDisciplinas).HasForeignKey(x => x.AlunoId);
            builder.HasOne(entity => entity.Disciplina).WithMany(entity => entity.AlunosDisciplinas).HasForeignKey(x => x.DisciplinaId);
        }  
    }
}
