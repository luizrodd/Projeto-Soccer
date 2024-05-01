using Domain.Validation;

namespace Domain.Entitites
{
    public class Game
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string Place { get; set; }
        public int ResultTeamOne { get; set; }
        public int ResultTeamTwo { get; set; }
        public GameStatus GameStatus { get; set; }
        public Guid ChampionshipId { get; set; }
        public Team TeamOne { get; set; }
        public Team TeamTwo { get; set; }

    }
}
