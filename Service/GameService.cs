using Infra;
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
                    GameId = x.GameStatus.GameId,
                    Type = x.GameStatus.Type,
                },
                Place = x.Place,
                ResultTeamOne = x.ResultTeamOne,
                ResultTeamTwo = x.ResultTeamTwo,
                TeamOne = new TeamDTO()
                {
                    TeamTwoId = x.TeamOne.TeamTwoId,
                    Name = x.TeamTwo.Name,
                    Image = x.TeamTwo.Image,
                },
                TeamTwo = new TeamDTO()
                {
                    Image = x.TeamTwo.Image,
                    Name = x.TeamTwo.Name,
                    TeamOneId = x.TeamTwo.TeamOneId,
                },
            }).ToListAsync();

            return games;
        }
    }
}
