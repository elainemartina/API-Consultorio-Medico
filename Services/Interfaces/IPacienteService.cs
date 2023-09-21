using ConsultorioAPI.DTOs;

namespace ConsultorioAPI.Services.Interfaces
{
    public interface IPacienteService
    {
        Task<List<Paciente>> GetPacienteByIdade(int idade);
        Task<List<Paciente>> GetPacienteByPlano(string plano);
        Task CreatePaciente(Paciente paciente);
        Task<string> UpdatePaciente(int id, PacienteDTO paciente);
        Task UpdateEnderecoPaciente(int id, string endereco);
        Task<Paciente> GetPacienteById(int id);
    }
}
