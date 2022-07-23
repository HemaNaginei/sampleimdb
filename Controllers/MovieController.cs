using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sampleimdb.Models;
using Sampleimdb.Repository;

namespace Sampleimdb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly MovieRepository _repository;
        private readonly string _connectionString;

        public MovieController(MovieRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        } 
        [HttpPost,Route("InsertMovies")]
        public async Task<ActionResult<Movies>> Post([FromBody] Movies lead)
        {
            if (lead==null)
            {
                return BadRequest();
            }
            var change=await _repository.InsertMovies(lead);
            if(change==null)
            {
                return NotFound();
            }
            return Ok(change);
        }
        [HttpPut,Route("UpdateMovies")]
        public async Task<ActionResult<Movies>> Put([FromBody] Movies lead)
        {
            if(lead==null)
            {
                return BadRequest();
            }
            var change = await _repository.UpdateMovies(lead);
            if(change ==null)
            {
                return NotFound();
            }
            return Ok(change);
        }
        [HttpDelete,Route("DeleteMovies")]
        public async Task<ActionResult> DeleteMovies(int MovieId)
        {
            if(MovieId<=0)
            {
                return BadRequest();
            }
            var change = await _repository.DeleteMovies(MovieId);
            if(change==null)
            {
                return NotFound();
            }
            return Ok(change);
        }
        [HttpGet,Route("GetAllMovies")]
        public async Task<ActionResult<IEnumerable<Movies>>> GetAllMovies()
        {
            try
            {
                var result = await _repository.GetAllMovies();
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
        [HttpGet,Route("GetMovieById")]
        public async Task<ActionResult<IEnumerable<Movies>>> GetMovieById(int MovieId)
        {
            if(MovieId==null)
            {
                return BadRequest();
            }
            var result=await _repository.GetMoviesById(MovieId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
