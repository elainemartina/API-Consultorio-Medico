using ConsultorioAPI.DTOs;
using ConsultorioAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;

namespace ConsultorioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultasController : ControllerBase
    {
        private readonly IConsultaService _consultaService;

        public ConsultasController(IConsultaService consultaService)
        {
            _consultaService = consultaService;
        }

        [HttpGet("ConsultasPaciente/{idPaciente}")]
        public async Task<ActionResult<Consulta>> GetConsultasByPaciente(int idPaciente)
        {
            var consulta = await _consultaService.GetConsultasByPaciente(idPaciente);
            if (consulta == null) return NotFound();

            return Ok(consulta);
        }

        [HttpGet("ConsultasMedico/{idMedico}")]
        public async Task<ActionResult<Consulta>> GetConsultasByMedico(int idMedico)
        {
            var consulta = await _consultaService.GetConsultasByMedico(idMedico);
            if (consulta == null) return NotFound();

            return Ok(consulta);
        }

        [HttpPost]
        public async Task<ActionResult> CreateConsulta(ConsultaDTO consulta)
        {
            var consultaModel = new Consulta
            {
                MedicoId = consulta.MedicoId,
                PacienteId = consulta.PacienteId,
                DataConsulta = consulta.DataConsulta,
                DataRetorno = consulta.DataRetorno,
                Descricao = consulta.Descricao,
                PrescricaoMedica = consulta.PrescricaoMedica
            };

            await _consultaService.CreateConsulta(consultaModel);
            return Ok(consultaModel);
        }
       
        [HttpGet("ConsultaPorDatas/{data}")]
        public async Task<ActionResult<Consulta>> GetConsultaByData(DateTime data)
        {
            var consultas = await _consultaService.GetConsultaByData(data);
            return Ok(consultas);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteConsulta(int id)
        {
            await _consultaService.DeleteConsulta(id);
            return Ok("Consulta excluída com sucesso.");
        }
    }
}
