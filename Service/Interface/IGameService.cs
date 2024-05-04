using Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IGameService
    {
        Task<List<GameDTO>> GetAll();
        Task<bool> Create(GameDTO game);
        Task<bool> Update(GameDTO game);
        Task<bool> Delete(Guid id);



        //retirar daqui
        Task<TeamDTO> FindTeamById(Guid id);
    }
}
