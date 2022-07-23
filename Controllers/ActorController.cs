using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sampleimdb.Context;
using Sampleimdb.Models;
using Sampleimdb.Repository;

namespace Sampleimdb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        public readonly ActorRepository _repository;
        public readonly string _connectionString;
        public ActorController(ActorRepository repository)
        {
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        [HttpPost, Route("InsertActor")]
        public async Task<ActionResult<Actor>> Post([FromBody] Actor lead)
        {
            if (lead == null)
            {
                return BadRequest();
            }
            var change = await _repository.InsertActor(lead);
            if (change == null)
            {
                return NotFound();
            }
            return Ok(change);
        }
        [HttpPut, Route("UpdateActor")]
        public async Task<ActionResult<Actor>> Put([FromBody] Actor lead)
        {
            if (lead == null)
            {
                return BadRequest();
            }
            var change = await _repository.UpdateActor(lead);
            if (change == null)
            {
                return NotFound();
            }
            return Ok(change);
        }
        [HttpDelete, Route("DeleteActor")]
        public async Task<ActionResult> DeleteActor(int ActorId)
        {
            if (ActorId <= 0)
            {
                return BadRequest();
            }
            var change = await _repository.DeleteActor(ActorId);
            if (change == null)
            {
                return NotFound();
            }
            return Ok(change);
        }
        [HttpGet,Route("GetAllActor")]
        public async Task<ActionResult<IEnumerable<Actor>>> GetAllActors()
        {
            try
            {
                var result=await _repository.GetAllActors();
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
        [HttpGet,Route("GetActorById")]
        public async Task<ActionResult<IEnumerable<Actor>>>GetActorById(int ActorId)
        {
            try
            {
                if(ActorId==null)
                {
                    return BadRequest();
                }
                var change = await _repository.GetActorById(ActorId);
                if(change ==null)
                {
                    return NotFound();
                }
                return Ok(change);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpGet, Route("GetAllActorDD")]
        public async Task<ActionResult<IEnumerable<Actor_DD>>> GetAllActorDD()
        {
            try
            {
                var result = await _repository.GetAllActorDD();
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
