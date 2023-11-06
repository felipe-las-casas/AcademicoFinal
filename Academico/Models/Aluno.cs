using System.ComponentModel.DataAnnotations;

namespace Academico.Models
{
    public class Aluno
    {
        public int AlunoId { get; set; }
        [Required]
        public string Nome { get; set; }

        public ICollection<AlunoDisciplina>? AlunosDisciplinas { get; set; }
    }
}
