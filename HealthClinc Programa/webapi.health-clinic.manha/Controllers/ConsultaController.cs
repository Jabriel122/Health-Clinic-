using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.health_clinic.manha.Context;
using webapi.health_clinic.manha.Domains;
using webapi.health_clinic.manha.Interfaces;
using webapi.health_clinic.manha.Repository;

namespace webapi.health_clinic.manha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ConsultaController : ControllerBase
    {

        private IConsultaRepository _consultaRepository;

        public ConsultaController()
        {
            _consultaRepository = new ConsultaRepository();
        }

        [HttpPost]
        public IActionResult Post(Consulta consulta)
        {
            try
            {
                _consultaRepository.Cadastrar(consulta);
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_consultaRepository.Listar());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _consultaRepository.Deletar(id);
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(Consulta consulta,Guid id)
        {
            try
            {
                _consultaRepository.Atualizar(id,consulta);
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Medico")]

        public IActionResult GetIdMEdico(Guid id)
        {
            try
            {
                List<Consulta> listaMedico = _consultaRepository.ListarPorMedico(id);
                return Ok(listaMedico);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("Paciente")]

        public IActionResult GetPaciente(Guid id)
        {
            try
            {
                List<Consulta> listaPaciente = _consultaRepository.ListarPorPaciente(id);
                return Ok(listaPaciente);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        } 
    }
}
