using Domain.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs
{
    public class ChampionshipDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int Rounds { get; set; }
        public List<GameDTO> GamesList { get; set;  } = new List<GameDTO>();
        public List<TeamDTO> TeamsList { get; set;  } = new List<TeamDTO>();
    }
}
