using Domain.Validation;

namespace Domain.Entitites
{
    public class Game
    {
        public Game(DateTime date, string place, int? resultOne, int? resultTwo, GameStatus gameStatus, Guid champId, Team teamOne, Team teamTwo)
        {
            ValidateDomain(place, gameStatus, champId, teamOne, teamTwo);
            Date = date;
            Place = place;
            ResultTeamOne = resultOne;
            ResultTeamTwo = resultTwo;
            GameStatus = gameStatus;
            ChampionshipId = champId;
            TeamOne = teamOne;
            TeamTwo = teamTwo;
        }
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string Place { get; set; }
        public int? ResultTeamOne { get; set; }
        public int? ResultTeamTwo { get; set; }
        public GameStatus GameStatus { get; set; }
        public Guid ChampionshipId { get; set; }
        public Team TeamOne { get; set; }
        public Team TeamTwo { get; set; }

        public void ValidateDomain (string place, GameStatus gameStatus, Guid champId, Team teamOne, Team teamTwo)
        {
            DomainExceptionValidation.When(place is null,
                "The place cannot be null");
            DomainExceptionValidation.When(gameStatus is null,
                "The game status cannot be null");
            DomainExceptionValidation.When(champId == Guid.Empty,
                "Not was possible create without a championship");
            DomainExceptionValidation.When(teamOne is null || teamTwo is null,
                "Not was possible create without a teams");
        }

    }
}
