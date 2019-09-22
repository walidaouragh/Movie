using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Movie.API.Repositories.StudioRepository;

namespace Movie.API.Controllers
{
    [Route("api/studios")]
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
    }
}