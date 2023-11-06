namespace Academico.Models
{
    public class Instituicao
    {
        public long? InstituicaoID { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public ICollection<Departamento>? Departamentos { get; set; }
    }
}
