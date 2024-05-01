using Infra;
using Service.DTOs;
using Service.Interface;
using Domain.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Service
{
    public class TeamService(TemplateContext data) : ITeamService
    {
        private readonly TemplateContext _data = data;

        public async Task<List<TeamDTO>> GetAll()
        {
           var teams = await _data.Teams.Select(s => new TeamDTO()
           {
               ChampionshipId = s.ChampionshipId,
               TeamTwoId = s.TeamTwoId,
               Image = s.Image,
               Name = s.Name,
               NewsList = s.NewsList,
               TeamOneId = s.TeamOneId,
           }).ToListAsync();

           return teams;
        }
    }
}
