using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Movie.API.Models;
using Movie.API.Repositories;

namespace Movie.API.Controllers
{
    [Route("api/movies")]
    [ApiController]
    
    public class MovieController : ControllerBase
    {
        private readonly IMoviesRepository _moviesRepository;


        public MovieController(IMoviesRepository moviesRepository)
        {
            _moviesRepository = moviesRepository;
        }

        [HttpGet]
        public IActionResult GetMovies()
        {
            var result =  _moviesRepository.GetMovies();
            return Ok(result);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovie(int id)
        {
            var result =  await _moviesRepository.GetMovie(id);
            return Ok(result);
        }
        
        [HttpGet("category")]
        public IActionResult GetMoviesByCategory([FromQuery]string category)
        {
            var result = _moviesRepository.GetMoviesByCategory(category);
            return Ok(result);
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateMovies([FromBody]MovieToPost movie)
        {
            var result =  await _moviesRepository.CreatMovies(movie);
            return Ok(result);
        }
        
        //put still not working properly
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMovie([FromBody]MovieToPost movie, int id)
        {
            var result =  await _moviesRepository.UpdateMovie(movie, id);
            return Ok(result);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            await _moviesRepository.DeleteMovie(id);
            return NoContent();
        }
    }
}