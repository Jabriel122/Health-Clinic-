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

        [HttpPost]

        public IActionResult Post(Médico médico)
        {
            try
            {
                if (médico != null)
                {
                    _medicoRepository.Cadastrar(médico);
                    return StatusCode(201);
                }
                return Ok("Médico não foi inserido corretamente");
            }
            
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

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

        [HttpPut]
        public IActionResult Put(Médico médico, Guid id)
        {
            try
            {
                _medicoRepository.Atualizar(id, médico);
                return StatusCode(201);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            } 
        }
    }
}
