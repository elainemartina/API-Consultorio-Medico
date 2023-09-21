using ConsultorioAPI.DTOs;
using System.Collections.Generic;

namespace ConsultorioAPI.Services.Interfaces
{
    public interface IConsultaService
    {
        Task<List<Consulta>> GetConsultasByPaciente(int idPaciente);
        Task<List<Consulta>> GetConsultasByMedico(int idMedico);
        Task<Consulta> CreateConsulta(Consulta consulta);
        Task<List<Consulta>> GetConsultaByData(DateTime data);
        Task<string> DeleteConsulta(int id);
    }
}
