using Domain.Entitites;
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
    public class ChampionshipService(TemplateContext data) : IChampionshipService
    {
        private readonly TemplateContext _data = data;

        public Task<List<ChampionshipDTO>> GetAll()
        {
            var championship = _data.Championships.Select(x => new ChampionshipDTO
            {
                Image = x.Image,
                Name = x.Name,
                Rounds = x.Rounds,
                TeamsList = x.TeamsList.Select(y => new TeamDTO()
                {
                    ChampionshipId = y.ChampionshipId,
                    Image = y.Image,
                    Name = y.Name,
                    TeamOneId = y.TeamOneId,
                    TeamTwoId = y.TeamTwoId,
                }).ToList(),    
                GamesList = x.GamesList.Select(y => new GameDTO()
                {
                    Date = y.Date,
                    GameStatus = new GameStatusDTO()
                    {
                        GameId = y.GameStatus.GameId,
                        Type = y.GameStatus.Type
                    },
                    ChampionshipId = y.Id,
                    Place = y.Place,
                    ResultTeamOne = y.ResultTeamOne,
                    ResultTeamTwo = y.ResultTeamTwo,
                    TeamOne = new TeamDTO()
                    {
                        Image = y.TeamOne.Image,
                        Name = y.TeamOne.Name,
                        TeamOneId = y.TeamOne.Id,
                    },
                    TeamTwo = new TeamDTO()
                    {
                        Image = y.TeamTwo.Image,
                        Name = y.TeamTwo.Name,
                        TeamTwoId = y.TeamTwo.Id,
                    }
                }).ToList()
            }).ToListAsync();

            return championship;
        }
    }
}
