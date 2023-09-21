using ConsultorioAPI.DTOs;
using ConsultorioAPI.Models;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConsultorioAPI.Services
{
    public class ConsultaService : IConsultaService
    {
        private readonly DataContext _dbContext;

        public ConsultaService(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        // CRIAR CONSULTA
        public async Task<Consulta> CreateConsulta(Consulta consulta)
        {
            _dbContext.Add(consulta);
            await _dbContext.SaveChangesAsync();

            return consulta;
        }

        // CONSULTAS BY DATA
        public async Task<List<Consulta>> GetConsultaByData(DateTime data)
        {
            return await _dbContext.Consultas.Where(c => (c.DataConsulta.Date) == data.Date).ToListAsync();
        }

        // CONSULTAS POR PACIENTE
        public async Task<List<Consulta>> GetConsultasByPaciente(int idPaciente)
        {
            return await _dbContext.Consultas.Where(c => (c.PacienteId) == idPaciente).ToListAsync();
        }

        // DELETAR CONSULTA
        public async Task<string> DeleteConsulta(int id)
        {
            var consulta = await _dbContext.Consultas.FindAsync(id);

            if (consulta == null) return "Consulta não encontrada";

            _dbContext.Consultas.Remove(consulta);
            await _dbContext.SaveChangesAsync();

            return "Consulta Excluída com Sucesso!";
        }

        // CONSULTA POR MEDICO
        public async Task<List<Consulta>> GetConsultasByMedico(int idMedico)
        {
            return await _dbContext.Consultas.Where(c => c.MedicoId == idMedico).ToListAsync();
        }
    }
}
