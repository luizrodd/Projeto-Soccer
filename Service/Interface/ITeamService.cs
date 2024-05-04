using Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface ITeamService
    {
        Task<List<TeamDTO>> GetAll();
        Task<bool> Create(TeamDTO team);
        Task<bool> Update(TeamDTO team);
        Task<bool> Delete(Guid id);
    }
}
