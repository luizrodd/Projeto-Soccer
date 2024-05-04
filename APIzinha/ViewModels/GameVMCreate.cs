using Service.DTOs;

namespace APIzinha.ViewModels
{
    public class GameVMCreate
    {
        public DateTime Date { get; set; }
        public string Place { get; set; }
        public int? ResultTeamOne { get; set; }
        public int? ResultTeamTwo { get; set; }
        public string GameStatus { get; set; }
        public Guid ChampionshipId { get; set; }
        public Guid TeamOneId { get; set; }
        public Guid TeamTwoId { get; set; }
    }
}
