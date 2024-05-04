using APIzinha.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;
using Service.DTOs;
using Service.Interface;

namespace APIzinha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly ITeamService _teamService;

        public TeamsController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<TeamsVMGet>), 200)]
        [ProducesResponseType(typeof(List<TeamsVMGet>), 400)]
        [ProducesResponseType(typeof(List<TeamsVMGet>), 500)]
        public async Task<IActionResult> GetAll()
        {
            var teams = await _teamService.GetAll();
            var vm = teams.Select(x => new TeamsVMGet()
            {
                Name = x.Name,
                Image = x.Image,
                ChampionshipId = x.ChampionshipId,
            });

            if (vm.Count() == 0)
                return StatusCode(203, "Está vazia");

            return StatusCode(200, vm);

        }

        [HttpPost]
        [ProducesResponseType(typeof(bool), 201)]
        [ProducesResponseType(typeof(bool), 400)]
        [ProducesResponseType(typeof(bool), 500)]
        public async Task<IActionResult> Create(TeamsVMCreate team)
        {
            var dto = new TeamDTO()
            {
                Name = team.Name,
                Image = team.Image,
                ChampionshipId = team.ChampionshipId,
            };
            var result = await _teamService.Create(dto);

            if (result != true)
                return StatusCode(400, "Não foi possível criar");

            return StatusCode(201, "Criado com sucesso");
        }

        [HttpPut]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(typeof(bool), 400)]
        [ProducesResponseType(typeof(bool), 500)]
        public async Task<IActionResult> Update(TeamsVMCreate team)
        {
            var dto = new TeamDTO()
            {
                Name = team.Name,
                Image = team.Image,
                ChampionshipId = team.ChampionshipId,
            };
            var result = await _teamService.Update(dto);

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
            var result = await _teamService.Delete(id);

            if (result != true)
                return StatusCode(400, "Não foi possivel apagar");

            return StatusCode(200, "Apagado com sucesso");
        }
    }
}
