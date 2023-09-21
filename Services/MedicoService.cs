using ConsultorioAPI.DTOs;
using Microsoft.EntityFrameworkCore;

namespace ConsultorioAPI.Services
{
    public class MedicoService : IMedicoService
    {
        private readonly DataContext _dbContext;

        public MedicoService(DataContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<string> UpdateMedico(int id, MedicoDTO medico)
        {
            var medicoModel = await _dbContext.Medicos.FindAsync(id);
            if (medicoModel == null) return "Medico não encontrado";

            medicoModel.Nome = medico.Nome;
            medicoModel.CRM = medico.CRM;
            medicoModel.Especialidade = medico.Especialidade;
            medicoModel.Telefone = medico.Telefone;
            medicoModel.Endereco = medico.Endereco;
            medicoModel.DataNascimento = medico.DataNascimento;
            medicoModel.Sexo = medico.Sexo;
            medicoModel.AnoExperiencia = medico.AnoExperiencia;

            await _dbContext.SaveChangesAsync();

            return "Medico atualizado com sucesso";
        }

        public async Task<List<Medico>> GetMedicoByEspecialidade(string especialidade)
        {
            return await _dbContext.Medicos.Where(m => (m.Especialidade) == especialidade).ToListAsync();
        }
        public async Task CreateMedico(Medico medico)
        {
            _dbContext.Add(medico);
            await _dbContext.SaveChangesAsync();
        }
        public async Task UpdateEspecialidadeMedico(int id, string especialidade)
        {
            var medico = await _dbContext.Medicos.FirstOrDefaultAsync(m => m.Id == id);

            medico.Especialidade = especialidade;
            await _dbContext.SaveChangesAsync();
        }
        public async Task<List<Medico>> GetMedicoByAnoExperiencia(int anoExperiencia)
        {
            return await _dbContext.Medicos.Where(m => m.AnoExperiencia >= anoExperiencia).ToListAsync();
        }

        //DESAFIO
        public async Task<List<Medico>> GetMedicosDisponiveis(DateTime data, string especialidade)
        {
            var medicosEspecializacao = await _dbContext.Medicos.Where(m => m.Especialidade == especialidade).ToListAsync();

            var medicosDisponiveis = new List<Medico>();
            if (medicosEspecializacao.Count != 0)
            {
                foreach (var m in medicosEspecializacao)
                {
                    var consulta = await _dbContext.Consultas.Where(c => c.MedicoId == m.Id && c.DataConsulta.Date == data.Date).ToListAsync();

                    if (consulta.Count == 0)
                    {
                        medicosDisponiveis.Add(m);
                    }
                }
            }
            return medicosDisponiveis;
        }
    }
}
