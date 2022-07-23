using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sampleimdb.Models;
using Sampleimdb.Repository;

namespace Sampleimdb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SampleController : ControllerBase
    {
        private readonly SampleRepository _repository;
        private readonly string _connectionString;
        public SampleController(SampleRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        [HttpPost,Route("InsertSample")]
        public async Task<ActionResult<Sample>> Post([FromBody] Sample lead)
        {
            if(lead==null)
            {
                return BadRequest();
            }
            var change = await _repository.InsertSample(lead);
            if(change==null)
            {
                return NotFound();
            }
            return Ok(change);
        }
        [HttpPut,Route("UpdateSample")]
        public async Task<ActionResult<Sample>> Put([FromBody] Sample lead)
        {
            if(lead==null)
            {
                return BadRequest();
            }
            var change=await _repository.UpdateSample(lead);
            if(change==null)
            {
                return NotFound();
            }
            return Ok(change);
        }
        [HttpDelete,Route("DeleteSample")]
        public async Task<ActionResult>DeleteSample(int Id)
        {
            if(Id<=0)
            {
                return BadRequest();
            }
            var change=await _repository.DeleteSample(Id);
            if(change==null)
            {
                return NotFound();
            }
            return Ok(change);
        }
        [HttpGet,Route("GetAllSample")]
        public async Task<ActionResult<IEnumerable<Sample>>>GetAllSample()
        {
            try
            {
                var result = await _repository.GetAllSample();
                if(result.Any())
                {
                    return Ok(result);
                }
                return NotFound();
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,ex.Message);
            }
        }
        [HttpGet,Route("GetSampleById")]
        public async Task<ActionResult<IEnumerable<Sample>>> GetSampleById(int SampleId)
        {
            try
            {
                if(SampleId==null)
                {
                    return BadRequest();
                }
                var result=await _repository.GetSampleById(SampleId);
                if(result==null)
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
    }
}
