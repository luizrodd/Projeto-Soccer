using APIzinha.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs;
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
        [ProducesResponseType(typeof(List<NewsVMGet>), 200)]
        [ProducesResponseType(typeof(List<NewsVMGet>), 203)]
        [ProducesResponseType(typeof(List<NewsVMGet>), 500)]
        public async Task<IActionResult> GetAll()
        {
            var news = await _newsService.GetAll();
            var vm = news.Select(x => new NewsVMGet()
            {
                Title = x.Title,
                Description = x.Description,
                Image = x.Image,
                Date = x.Date,
                Source = x.Source,
                TeamId = x.TeamId,
            });
            if (vm.Count() == 0)
                return StatusCode(203, "Está vazia");

            return StatusCode(200, vm);
        }

        [HttpPost]
        [ProducesResponseType(typeof(bool), 201)]
        [ProducesResponseType(typeof(bool), 400)]
        [ProducesResponseType(typeof(bool), 500)]
        public async Task<IActionResult> Create(NewsVMCreate news)
        {
            var dto = new NewsDTO()
            {
                Title = news.Title,
                Description = news.Description,
                Image = news.Image,
                Date = news.Date,
                Source = news.Source,
                TeamId = news.TeamId,
            };

            var result = await _newsService.Create(dto);

            if (result != true)
                return StatusCode(400, "Não foi possível criar");

            return StatusCode(201, "Criado com sucesso");
        }

        [HttpPut]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(typeof(bool), 400)]
        [ProducesResponseType(typeof(bool), 500)]
        public async Task<IActionResult> Update(NewsVMCreate news)
        {
            var dto = new NewsDTO()
            {
                Title = news.Title,
                Description = news.Description,
                Image = news.Image,
                Date = news.Date,
                Source = news.Source,
                TeamId = news.TeamId,
            };

            var result = await _newsService.Update(dto);
            if (result != true)
                return StatusCode(400, "Não foi possível atualizar");

            return StatusCode(200, "Atualizado com sucesso");

        }

        [HttpDelete]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(typeof(bool), 400)]
        [ProducesResponseType(typeof(bool), 500)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _newsService.Delete(id);

            if (result != true)
                return StatusCode(400, "Não foi possivel apagar");

            return StatusCode(200, "Apagado com sucesso");
        }
    }
}
