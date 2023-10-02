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
    public class TiposUsuarioController : ControllerBase
    {
        private ITipoDeUsuarioRepository _tiposUsuarioRepository;
        public TiposUsuarioController()
        {
            _tiposUsuarioRepository = new TiposDeUsuarioRepository();
        }

        [HttpPost]
        public IActionResult Post(TiposDeUsuario tiposDeUsuario)
        {
            try
            {
                _tiposUsuarioRepository.Cadastrar(tiposDeUsuario);
                return StatusCode(201);
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
                _tiposUsuarioRepository.Deletar(id);
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
            return Ok(_tiposUsuarioRepository.Listar());
        }

    }
}
