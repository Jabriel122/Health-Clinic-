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

    public class MedicoController : ControllerBase
    {
        private IMedicoRepository _medicoRepository;

        public MedicoController()
        {
            _medicoRepository = new MedicoRepository();
        }

        /// <summary>
        /// Endpoint de Cadastro
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [HttpPost]

        public IActionResult Post(Medico medico)
        {
            try
            {
               
                _medicoRepository.Cadastrar(medico);
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
        public IActionResult Get ()
        {
            try
            {
                return Ok(_medicoRepository.Listar());
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }

        /// <summary>
        /// Endpoint de Listar por id
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [HttpGet("{id}")]

        public IActionResult GetId(Guid id)
        {
            try
            {

                return Ok(_medicoRepository.BuscarPorId(id));
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
        public IActionResult Put(Medico medico, Guid id)
        {
            try
            {
                _medicoRepository.Atualizar(id, medico);
                return StatusCode(201);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            } 
        }
    }
}
