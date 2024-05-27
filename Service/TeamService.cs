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
               Image = s.Image,
               Name = s.Name,
           }).ToListAsync();

           return teams;
        }
        public async Task<bool> Create(TeamDTO team)
        {
            var createTeam = new Team(team.Name, team.Image);

            await _data.Teams.AddAsync(createTeam);
            _data.SaveChanges();
            return true;
        }

        public async Task<bool> Update(TeamDTO team)
        {
            var updatedTeam = await _data.Teams.FindAsync(team.Id);

            if (updatedTeam == null)
            {
                return false;
            }

            updatedTeam.Name = team.Name;
            updatedTeam.Image = team.Image;


            await _data.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(Guid id)
        {
            var deleteNews = await _data.News.FindAsync(id);
            if (deleteNews == null)
                return false;

            _data.News.Remove(deleteNews);
            await _data.SaveChangesAsync();

            return true;
        }
    }
}
