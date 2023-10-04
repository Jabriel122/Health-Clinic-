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
    public class EspecialidadeController : ControllerBase
    {
        private IEspecialidadeRepository _especialidadeRepository;

        public EspecialidadeController()
        {
            _especialidadeRepository= new EspecialidadeRepository();
        }

        /// <summary>
        /// Endpoint de Cadastro
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(Especialidades especialidades)
        {
            try
            {
                _especialidadeRepository.Cadastrar(especialidades);
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
                return Ok(_especialidadeRepository.Listar());
            }
            catch(Exception ex)
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
                _especialidadeRepository.Deletar(id);
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
