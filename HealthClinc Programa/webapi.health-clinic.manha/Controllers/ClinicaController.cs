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
    public class ClinicaController : ControllerBase
    {
        private IClinicaRepository _clinicaRepository;

        public ClinicaController()
        {
            _clinicaRepository = new ClinicaRepository();
        }



        /// <summary>
        /// Endpoint de Cadastro
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Cadastrar(Clinica clinica)
        {
            try
            {
                _clinicaRepository.Cadastar(clinica);
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
                return Ok(_clinicaRepository.Listar());
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

        public IActionResult GetId (Guid id)
        {
            try
            {
                
                return Ok(_clinicaRepository.BuscarPorId(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Endpoint de deletar
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult Deletar(Guid id)
        {
            try
            {
                _clinicaRepository.Deletar(id);
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
        public IActionResult Atualizar(Guid id, Clinica clinica)
        {
            try
            {
                _clinicaRepository.Atulaizar(id, clinica);
                return StatusCode(201) ;
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);  
            }
        }

    }
}
