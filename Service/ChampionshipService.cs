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
               
            }).ToListAsync();

            return championship;
        }
        public async Task<bool> Create(ChampionshipDTO championshipDTO)
        {

            var championship = new Championship(championshipDTO.Name, championshipDTO.Image, championshipDTO.Rounds);
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
