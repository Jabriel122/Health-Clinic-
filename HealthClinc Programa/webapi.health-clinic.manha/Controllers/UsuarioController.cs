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
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository;

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Endpoint de Cadastro
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [HttpPost]
       
        public IActionResult Post(Usuario usuario)
        {
            try
            {
                _usuarioRepository.Cadastrar(usuario);
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
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        
        public IActionResult Deletar(Guid id)
        {
            try
            {
                _usuarioRepository.Deletar(id);
                return StatusCode(201);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint de Listar
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get ()
        {
            try
            {
                return Ok(_usuarioRepository.Listar());
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
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut]

        public IActionResult Put(Usuario usuario, Guid id) 
        {
            try
            {
                _usuarioRepository.Atulizar(id,usuario);
                return StatusCode(201);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message) ;
            }

        }
    }
}
