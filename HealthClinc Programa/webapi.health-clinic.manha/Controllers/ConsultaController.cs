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

        /// <summary>
        /// Endpoint de Cadastro
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Endpoint de Listar
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>

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

        /// <summary>
        /// Endpoint de Deletar
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Endpoint de Atualizar
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
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


        /// <summary>
        /// Endpoint de Listar por Id de Medico
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Endpoint de Listar por Id de Paciente
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
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
