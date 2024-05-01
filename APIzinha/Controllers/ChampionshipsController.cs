using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;

namespace APIzinha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChampionshipsController : ControllerBase
    {
        private readonly IChampionshipService _championshipService;
        public ChampionshipsController(IChampionshipService championshipService)
        {
            _championshipService = championshipService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var championships = await _championshipService.GetAll();
            return StatusCode(200, championships);
        }
    }
}
