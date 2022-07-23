using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sampleimdb.Models;
using Sampleimdb.Repository;

namespace Sampleimdb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProducerController : ControllerBase
    {
        private readonly ProducerRepository _repository;
        private readonly string _connectionString;

        public ProducerController(ProducerRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        } 
        [HttpPost,Route("InsertProducer")]
        public async Task<ActionResult<Producer>>Post([FromBody] Producer lead)
        {
            if (lead == null)
            {
                return BadRequest();
            }
            var change = await _repository.InsertProducer(lead);
            if(change==null)
            {
                return NotFound();
            }
            return Ok(change);
        }
        [HttpPut,Route("UpdateProducer")]
        public async Task<ActionResult<Producer>> Put([FromBody] Producer lead)
        {
            if(lead==null)
            {
                return BadRequest();
            }
            var change = await _repository.UpdateProducer(lead);
            if(change ==null)
            {
                return NotFound();
            }
            return Ok(change);
        }
        [HttpDelete, Route("DeleteProducer")]
        public async Task<ActionResult> DeleteProducer(int ProducerId)
        {
            if(ProducerId<=0)
            {
                return BadRequest();
            }
            var change = await _repository.DeleteProducer(ProducerId);
            if(change==null)
            {
                return NotFound();
            }
            return Ok(change);
        }
        [HttpGet,Route("GetAllProducer")]
        public async Task<ActionResult<IEnumerable<Producer>>> GetAllProducer()
        {
            try
            {
                var result=await _repository.GetAllProducer();  
                if(result.Any())
                {
                    return Ok(result);
                }
                return NotFound();
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpGet,Route("GetProducerById")]
        public async Task<ActionResult<IEnumerable<Producer>>> GetProducerById(int ProducerId)
        {
            try
            {
                if (ProducerId == null)
                {
                    return BadRequest();
                }
                var result = await _repository.GetProducerById(ProducerId);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpGet,Route("GetAllProdcuerDD")]
        public async Task<ActionResult<IEnumerable<Producer_DD>>> GetAllProducerDD()
        {
            try
            {
                var result = await _repository.GetAllProducerDD();
                if(result.Any())
                {
                    return Ok(result);
                }
                return NotFound();
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
         
    }
}
