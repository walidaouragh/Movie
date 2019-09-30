using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Movie.API.Models;
using Movie.API.Repositories;

namespace Movie.API.Controllers
{
    [Route("api/movie")]
    [ApiController]
    
    public class MovieController : ControllerBase
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;


        public MovieController(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetMovies()
        {
            var result =  _movieRepository.GetMovies();
            return Ok(result);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovie(int id)
        {
            var result =  await _movieRepository.GetMovie(id);
            return Ok(result);
        }
        
        [HttpGet("category")]
        public IActionResult GetMoviesByCategory([FromQuery]string category)
        {
            var result = _movieRepository.GetMoviesByCategory(category);
            return Ok(result);
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateMovie([FromBody]Models.Movie movie)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var mapper = _mapper.Map<Models.Movie, MovieToPost>(movie);
            var result =  await _movieRepository.CreateMovie(mapper);
            
            return Ok(result);
        }
        
        [HttpPut]
        public async Task<IActionResult> UpdateMovie([FromBody]Models.Movie movie)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            await _movieRepository.UpdateMovie(movie);
             return NoContent();
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            await _movieRepository.DeleteMovie(id);
            return NoContent();
        }
    }
}