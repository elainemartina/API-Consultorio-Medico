using ConsultorioAPI.DTOs;
using ConsultorioAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConsultorioAPI.Services
{
    public class PacienteService : IPacienteService
    {
        private readonly DataContext _dbContext;

        public PacienteService(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        // CRIAR PACIENTE
        public async Task CreatePaciente(Paciente paciente)
        {
            _dbContext.Add(paciente);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Paciente> GetPacienteById(int id)
        {
            return await _dbContext.Pacientes.FindAsync(id);
        }

        // PACIENTE POR IDADE
        public async Task<List<Paciente>> GetPacienteByIdade(int idade)
        {           
            return await _dbContext.Pacientes.Where(p => DateTime.Today.Year - p.DataNascimento.Year >= idade).ToListAsync();             
        }

        // PACIENTE POR PLANO
        public async Task<List<Paciente>> GetPacienteByPlano(string plano)
        {
            return await _dbContext.Pacientes.Where(p => (p.PlanoSaude) == plano).ToListAsync();
        }

        // ATUALIZAR ENDEREÇO PACIENTE
        public async Task UpdateEnderecoPaciente(int id, string endereco)
        {
            var paciente = await _dbContext.Pacientes.FirstOrDefaultAsync(p => p.Id == id);

            paciente.Endereco = endereco;
            await _dbContext.SaveChangesAsync();
        }

        // ATUALIZAR ENDEREÇO
        public async Task<string> UpdatePaciente(int id, PacienteDTO paciente)
        {
            var pacienteModel = await _dbContext.Pacientes.FindAsync(id);
            if (pacienteModel == null) return "Paciente não encontrado";

            pacienteModel.Nome = paciente.Nome;
            pacienteModel.DataNascimento = paciente.DataNascimento;
            pacienteModel.CPF = paciente.CPF;
            pacienteModel.Telefone = paciente.Telefone;
            pacienteModel.Endereco = paciente.Endereco;
            pacienteModel.Sexo = paciente.Sexo;
            pacienteModel.PlanoSaude = paciente.PlanoSaude;

            await _dbContext.SaveChangesAsync();

            return "Paciente atualizado com sucesso";
        }
    }
}
