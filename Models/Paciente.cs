namespace ConsultorioAPI.Models
{
    public class Paciente
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public DateTime DataNascimento { get; set; }
        public string CPF { get; set; } = string.Empty;
        public string Telefone { get; set;} = string.Empty;
        public string Endereco { get; set; } = string.Empty;
        public string Sexo { get; set; } = string.Empty;
        public string PlanoSaude { get; set; } = string.Empty;
        public List<Medico> Medicos { get; set; } = new List<Medico>();
    }
}
