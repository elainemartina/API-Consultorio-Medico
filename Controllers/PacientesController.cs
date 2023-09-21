using ConsultorioAPI.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConsultorioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacientesController : ControllerBase
    {
        private readonly IPacienteService _pacienteService;

        public PacientesController(IPacienteService pacienteService)
        {
            _pacienteService = pacienteService;
        }

        [HttpGet("Id/{id}")]
        public async Task<ActionResult<Paciente>> GetPacienteById(int id)
        {
            var paciente = await _pacienteService.GetPacienteById(id);
            if (paciente == null) return NotFound();

            return Ok(paciente);
        }

        [HttpPost]
        public async Task<ActionResult> CreatePaciente(PacienteDTO paciente)
        {
            var pacienteModel = new Paciente
            {
                Nome = paciente.Nome,
                DataNascimento = paciente.DataNascimento,
                CPF = paciente.CPF,
                Telefone = paciente.Telefone,
                Endereco = paciente.Endereco,
                Sexo = paciente.Sexo,
                PlanoSaude = paciente.PlanoSaude
            };

            await _pacienteService.CreatePaciente(pacienteModel);
            return Ok(pacienteModel);

        }

        [HttpGet("Plano/{plano}")]
        public async Task<ActionResult<Consulta>> GetPacienteByPlano(string plano)
        {
            var paciente = await _pacienteService.GetPacienteByPlano(plano);
            if (paciente == null) return NotFound();

            return Ok(paciente);
        }

        [HttpGet("Idade/{idade}")]
        public async Task<ActionResult<Consulta>> GetPacienteByIdade(int idade)
        {
            var paciente = await _pacienteService.GetPacienteByIdade(idade);
            if (paciente == null) return NotFound();

            return Ok(paciente);
        }

        [HttpPatch("{endereco}")]
        public async Task<ActionResult<int>> UpdateEnderecoPaciente(int id, string endereco)
        {
            await _pacienteService.UpdateEnderecoPaciente(id, endereco);

            return Ok("Endereço atualizado com sucesso!");
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePaciente(int id, PacienteDTO paciente)
        {
            var mensagem = await _pacienteService.UpdatePaciente(id, paciente);

            if (mensagem == null) return BadRequest();

            return Ok(mensagem);
        }
    }
}
