using Brilliance.API.Services;

namespace Brilliance.API.Controllers
{
    [Route("api/v1/seedata")]
    [ApiController]
    public class SeedDataController : ControllerBase
    {
        private readonly SeedDataService _service;
        public SeedDataController(SeedDataService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            await _service.InitializeData();
            return Ok();
        }
    }
}
