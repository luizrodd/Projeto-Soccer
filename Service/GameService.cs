using Domain.Entitites;
using Infra;
using Infra.Migrations;
using Microsoft.EntityFrameworkCore;
using Service.DTOs;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class GameService(TemplateContext data) : IGameService
    {
        private readonly TemplateContext _data = data;

        public Task<List<GameDTO>> GetAll()
        {
            var games = _data.Games.Select(x => new GameDTO()
            {
                ChampionshipId = x.ChampionshipId,
                Date = x.Date,
                GameStatus = new GameStatusDTO()
                {
                    Type = x.GameStatus.Type,
                },
                Place = x.Place,
                ResultTeamOne = x.ResultTeamOne,
                ResultTeamTwo = x.ResultTeamTwo,
                TeamOne = new TeamDTO()
                {
                    Name = x.TeamTwo.Name,
                    Image = x.TeamTwo.Image,
                },
                TeamTwo = new TeamDTO()
                {
                    Image = x.TeamTwo.Image,
                    Name = x.TeamTwo.Name,
                },
            }).ToListAsync();

            return games;
        }
        public async Task<bool> Create(GameDTO game)
        {
            var createGame = new Game(game.Date, game.Place, game.ResultTeamOne, game.ResultTeamTwo, new GameStatus() { Type = game.GameStatus.Type }, game.ChampionshipId, new Team(game.TeamOne.Name, game.TeamOne.Image, game.TeamOne.ChampionshipId), new Team(game.TeamTwo.Name, game.TeamTwo.Image, game.TeamTwo.ChampionshipId));

            _data.Games.Add(createGame);
            await _data.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update(GameDTO game)
        {
            var id = game.Id;

            var gameToUpdate = await _data.Games.FindAsync(id);

            if (gameToUpdate == null)
            {
                return false;
            }

            gameToUpdate.Date = game.Date;
            gameToUpdate.Place = game.Place;
            gameToUpdate.ResultTeamOne = game.ResultTeamOne;
            gameToUpdate.ResultTeamTwo = game.ResultTeamTwo;
            gameToUpdate.GameStatus = new GameStatus() { Type = game.GameStatus.Type};
            gameToUpdate.ChampionshipId = game.ChampionshipId;

            await _data.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(Guid id)
        {
            var delete = await _data.Games.FindAsync(id);
            if (delete == null)
                return false;

            _data.Games.Remove(delete);
            await _data.SaveChangesAsync();
            return true;
        }



        //mover daqui
        public async Task<TeamDTO> FindTeamById(Guid id)
        { 
            var teamFound = await _data.Teams.FindAsync(id);
            if (teamFound == null)
                return null;

            var teamDto = new TeamDTO() { Name = teamFound.Name, Image = teamFound.Image };
            return teamDto;
        }
    }
}
