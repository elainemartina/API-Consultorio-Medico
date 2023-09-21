namespace ConsultorioAPI.DTOs
{
    public class PacienteDTO
    {
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string CPF { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public string Sexo { get; set; }
        public string PlanoSaude { get; set; }
    }
}
