using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Movie.API.Models;
using Movie.API.Repositories.StudioRepository;

namespace Movie.API.Controllers
{
    [Route("api/studio")]
    [ApiController]
    public class StudioController : ControllerBase
    {
        private readonly IStudioRepository _studioRepository;


        public StudioController(IStudioRepository studioRepository)
        {
            _studioRepository = studioRepository;
        }

        [HttpGet]
        public IActionResult GetStudios()
        {
            var result =  _studioRepository.GetStudios();
            return Ok(result);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudio(int id)
        {
            var result =  await _studioRepository.GetStudio(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudio([FromBody] StudioToPost studio)
        {
            var result = await _studioRepository.CreateStudio(studio);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStudio([FromBody] Studio studio)
        { 
            await _studioRepository.UpdateStudio(studio);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudio(int id)
        {
            await _studioRepository.DeleteStudio(id);

            return NoContent();
        }
    }
}