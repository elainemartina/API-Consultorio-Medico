using ConsultorioAPI.DTOs;

namespace ConsultorioAPI.Services.Interfaces
{
    public interface IMedicoService
    {
        Task<string> UpdateMedico(int id, MedicoDTO medico);
        Task<List<Medico>> GetMedicoByEspecialidade(string especialidade);
        Task CreateMedico(Medico medico);
        Task UpdateEspecialidadeMedico(int id, string especialidade);
        Task<List<Medico>> GetMedicoByAnoExperiencia(int anoExperiencia);
        Task<List<Medico>> GetMedicosDisponiveis(DateTime data, string especialidade);
    }
}
