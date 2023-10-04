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
    public class ComentarioConsultaController : ControllerBase
    {

        private IComentarioConsultaRepository _comentarioConsultaRepository;

        public ComentarioConsultaController()
        {
            _comentarioConsultaRepository = new ComentarioConsultaRepository();
        }

        /// <summary>
        /// Endpoint de Cadastro
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>

        [HttpPost]
        public IActionResult Post(ComentarioConsulta comentarioConsulta)
        {
            try
            {
                _comentarioConsultaRepository.Cadastrar(comentarioConsulta);
                return StatusCode(201);
            }
            catch(Exception ex)
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
                return Ok(_comentarioConsultaRepository.Listar());
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
                _comentarioConsultaRepository.Deletar(id);
                return StatusCode(201);
            }
            catch(Exception ex)
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
        public IActionResult Put(ComentarioConsulta comentario, Guid id)
        {
            try
            {
                _comentarioConsultaRepository.Atualizar(id,comentario);
                return StatusCode(201);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }




    }
}
