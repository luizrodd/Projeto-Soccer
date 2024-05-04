using APIzinha.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Service;
using Service.DTOs;
using Service.Interface;

namespace APIzinha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IGameService _gameService;
        public GamesController(IGameService gameService) 
        {
            _gameService = gameService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<GameVMGet>), 203)]
        [ProducesResponseType(typeof(List<GameVMGet>), 400)]
        [ProducesResponseType(typeof(List<GameVMGet>), 500)]
        public async Task<IActionResult> GetAll()
        {
            var games = await _gameService.GetAll();

            var vm = games.Select(x => new GameVMGet()
            {
                Date = x.Date,
                Place = x.Place,
                ResultTeamOne = x.ResultTeamOne,
                ResultTeamTwo = x.ResultTeamTwo,
                GameStatus = x.GameStatus.Type,
                ChampionshipId = x.ChampionshipId,
                TeamOne = x.TeamOne.Name,
                TeamTwo = x.TeamTwo.Name
            });
            if (vm.Count() == 0)
                return StatusCode(203, "Está vazia");

            return StatusCode(200, vm);
        }

        [HttpPost]
        [ProducesResponseType(typeof(bool), 201)]
        [ProducesResponseType(typeof(bool), 400)]
        [ProducesResponseType(typeof(bool), 500)]
        public async Task<IActionResult> Create(GameVMCreate game)
        {
            var dto = new GameDTO()
            {
                Date = game.Date,
                Place = game.Place,
                ResultTeamOne = game.ResultTeamOne,
                ResultTeamTwo = game.ResultTeamTwo,
                GameStatus = new GameStatusDTO() { Type = game.GameStatus },
                ChampionshipId = game.ChampionshipId,
                TeamOne = await _gameService.FindTeamById(game.TeamOneId),
                TeamTwo = await _gameService.FindTeamById(game.TeamTwoId),
            };
            var result = await _gameService.Create(dto);

            if (result != true)
                return StatusCode(400, "Não foi possível criar");

            return StatusCode(200, "Craido com sucesso"); 
        }

        [HttpPut]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(typeof(bool), 400)]
        [ProducesResponseType(typeof(bool), 500)]
        public async Task<IActionResult> Update(GameVMCreate game)
        {
            var dto = new GameDTO()
            {
                Date = game.Date,
                Place = game.Place,
                ResultTeamOne = game.ResultTeamOne,
                ResultTeamTwo = game.ResultTeamTwo,
                GameStatus = new GameStatusDTO() { Type= game.GameStatus },
                ChampionshipId= game.ChampionshipId
            };

            var returnStatus = await _gameService.Update(dto);
            if (returnStatus != true)
                return StatusCode(400, "Não foi atualizado");

            return StatusCode(201, "Atualizado");
        }

        [HttpDelete]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(typeof(bool), 400)]
        [ProducesResponseType(typeof(bool), 500)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var returnStatus = await _gameService.Delete(id);
            if (returnStatus != true)
                return StatusCode(404, "Não foi encontrado esse campeonato");

            return StatusCode(200, "Excluído");
        }
    }
}
