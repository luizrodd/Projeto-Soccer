using Domain.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs
{
    public class GameDTO
    {
        public DateTime Date { get; set; }
        public string Place { get; set; }
        public int ResultTeamOne { get; set; }
        public int ResultTeamTwo { get; set; }
        public GameStatusDTO GameStatus { get; set; }
        public Guid ChampionshipId { get; set; }
        public TeamDTO TeamOne { get; set; }
        public TeamDTO TeamTwo { get; set; }
    }
}
