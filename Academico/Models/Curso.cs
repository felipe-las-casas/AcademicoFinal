using System.ComponentModel.DataAnnotations;
using System.Configuration;

namespace Academico.Models
{
    public class Curso
    {
        public int? CursoId { get; set; }
        [Required]
        public string Nome { get; set; } = string.Empty;

        [IntegerValidator(MinValue = 20)]
        public int? CargaHoraria { get; set; }
        public ICollection<CursoDisciplina>? CursoDisciplinas { get; set; }

        public long? DepartamentoId { get; set; }
        public Departamento? Departamento { get; set; }
    }
}
