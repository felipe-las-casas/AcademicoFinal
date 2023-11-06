namespace Academico.Models
{
    public class Departamento
    {
        public long? DepartamentoId { get; set; }
        public string Nome { get; set; }
        public long InstituicaoID { get; set; }
       
        public Instituicao? Instituicao { get; set; }

        public ICollection<Curso>? Cursos { get; set; }
    }
}
