using Service.DTOs;

namespace APIzinha.ViewModels
{
    public class GameVMGet
    {
        public DateTime Date { get; set; }
        public string Place { get; set; }
        public int? ResultTeamOne { get; set; }
        public int? ResultTeamTwo { get; set; }
        public string GameStatus { get; set; }
        public Guid ChampionshipId { get; set; }
        public string TeamOne { get; set; }
        public string TeamTwo { get; set; }
    }
}
