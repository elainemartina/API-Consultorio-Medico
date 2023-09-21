namespace ConsultorioAPI.DTOs
{
    public class ConsultaDTO
    {
        public int MedicoId { get; set; }
        public int PacienteId { get; set; }
        public DateTime DataConsulta { get; set; }
        public DateTime? DataRetorno { get; set; } 
        public string Descricao { get; set; }
        public string PrescricaoMedica { get; set; }
    }
}
