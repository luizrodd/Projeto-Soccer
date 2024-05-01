using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;

namespace APIzinha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly INewsService _newsService;

        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var news = await _newsService.GetAll();
            return StatusCode(200,news);
        }
        [HttpPost]
        public async Task<IActionResult> Create(string title, string description, string image, DateTime date, string source, Guid teamId)
        {
            await _newsService.Create(title, description,image,date,source,teamId);
            return StatusCode(201,"Created");
        }
    }
}
