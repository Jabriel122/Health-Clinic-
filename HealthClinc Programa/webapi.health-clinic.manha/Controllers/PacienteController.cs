using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.health_clinic.manha.Domains;
using webapi.health_clinic.manha.Interfaces;
using webapi.health_clinic.manha.Repository;

namespace webapi.health_clinic.manha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class PacienteController : ControllerBase
    {
        private IPacienteRepository _pacienteRepository;

        public PacienteController()
        {
            _pacienteRepository = new PacienteRepository();
        }
        /// <summary>
        /// Endpoint de Cadastro
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post (Paciente paciente)
        {
            try
            {
                _pacienteRepository.Cadastrar(paciente);
                return StatusCode(201);
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
        public IActionResult Delete (Guid id)
        {
            try
            {
                _pacienteRepository.Deletar(id);
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
                return Ok(_pacienteRepository.Listar());
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

        public IActionResult Put(Guid id, Paciente paciente)
        {
            try
            {
                _pacienteRepository.Atulizar(id, paciente);
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Endpoint de Listar por Id
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetId(Guid id)
        {
            try
            {

                return Ok(_pacienteRepository.BuscaPorId(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        

    }
}
