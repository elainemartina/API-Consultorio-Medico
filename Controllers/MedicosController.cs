using ConsultorioAPI.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConsultorioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicosController : ControllerBase
    {
        private readonly IMedicoService _medicoService;

        public MedicosController(IMedicoService medicoService)
        {
            _medicoService = medicoService;
        }

        //4
        [HttpPut]
        public async Task<IActionResult> UpdateMedico(int id, MedicoDTO medico)
        {
            var mensagem = await _medicoService.UpdateMedico(id, medico);

            if (mensagem == null) return BadRequest();

            return Ok(mensagem);
        }

        //7
        [HttpGet("Especialidade/{especialidade}")]
        public async Task<ActionResult<Consulta>> GetMedicoByEspecialidade(string especialidade)
        {
            var medico = await _medicoService.GetMedicoByEspecialidade(especialidade);
            if (medico == null) return NotFound();

            return Ok(medico);
        }

        //9
        [HttpPost]
        public async Task<ActionResult> CreateMedico(MedicoDTO medico)
        {
            var medicoModel = new Medico
            {
                Nome = medico.Nome,
                CRM = medico.CRM,
                Especialidade = medico.Especialidade,
                Telefone = medico.Telefone,
                Endereco = medico.Endereco,
                DataNascimento = medico.DataNascimento,
                Sexo = medico.Sexo,
                AnoExperiencia = medico.AnoExperiencia,
            };

            await _medicoService.CreateMedico(medicoModel);
            return Ok(medicoModel);
        }

        //11
        [HttpPatch("{id}")]
        public async Task<ActionResult<int>> UpdateEspecialidadeMedico(int id, string especialidade)
        {
            await _medicoService.UpdateEspecialidadeMedico(id, especialidade);

            return Ok("Especialidade atualizada com sucesso!");
        }

        //14a
        [HttpGet("AnoExperiencia/{anoExperiencia}")]
        public async Task<ActionResult<Consulta>> GetMedicoByAnoExperiencia(int anoExperiencia)
        {
            var medico = await _medicoService.GetMedicoByAnoExperiencia(anoExperiencia);
            if (medico == null) return NotFound();

            return Ok(medico);
        }

        //DESAFIO
        [HttpGet("/disponiveis/{data}/{especialidade}")]
        public async Task<IActionResult> GetMedicosDisponiveis(DateTime data, string especialidade)
        {
            var medicos = await _medicoService.GetMedicosDisponiveis(data, especialidade);

            if (medicos.Any()) return Ok(medicos);

            else return NotFound("Não há medicos disponiveis, altere a especialidae ou data");          
        }
    }
}
