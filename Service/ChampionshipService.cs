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
                }).ToList(),    
                GamesList = x.GamesList.Select(y => new GameDTO()
                {
                    Date = y.Date,
                    GameStatus = new GameStatusDTO()
                    {
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
                    },
                    TeamTwo = new TeamDTO()
                    {
                        Image = y.TeamTwo.Image,
                        Name = y.TeamTwo.Name,
                    }
                }).ToList()
            }).ToListAsync();

            return championship;
        }
        public async Task<bool> Create(ChampionshipDTO championshipDTO)
        {

            var championship = new Championship(championshipDTO.Name, championshipDTO.Image, championshipDTO.Rounds)
            {
                GamesList = championshipDTO.GamesList.Select(x => new Game(x.Date, x.Place, x.ResultTeamOne, x.ResultTeamTwo, new GameStatus() { Type = x.GameStatus.Type }, x.ChampionshipId, new Team(x.TeamOne.Name, x.TeamOne.Image, x.TeamOne.ChampionshipId), new Team(x.TeamTwo.Name, x.TeamTwo.Image, x.TeamTwo.ChampionshipId))).ToList(),

                TeamsList = championshipDTO.TeamsList.Select(x => new Team(x.Name, x.Image, x.ChampionshipId)).ToList()
                 
            };
            _data.Championships.Add(championship);
            await _data.SaveChangesAsync();
            return true;

        }
        public async Task<bool> Update(ChampionshipDTO championshipDTO)
        {
            var id = championshipDTO.Id;

            var championshipToUpdate = await _data.Championships.FindAsync(id);

            if (championshipToUpdate == null)
            {
                return false;
            }
            championshipToUpdate.Name = championshipDTO.Name;
            championshipToUpdate.Image = championshipDTO.Image;
            championshipToUpdate.Rounds = championshipDTO.Rounds;

            await _data.SaveChangesAsync();

            return true;

        }
        public async Task<bool> Delete(Guid championshipId)
        {
            var delete = await _data.Championships.FindAsync(championshipId);
            if (delete == null)
                return false;

            _data.Championships.Remove(delete);
            await _data.SaveChangesAsync();
            return true;
        }
    }
}
