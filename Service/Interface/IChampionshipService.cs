using Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IChampionshipService
    {
        Task<List<ChampionshipDTO>> GetAll();
        Task<bool> Create(ChampionshipDTO championshipDTO);
        Task<bool> Update(ChampionshipDTO championshipDTO);
        Task<bool> Delete(Guid championshipId);
    }
}
