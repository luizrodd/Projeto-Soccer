using Domain.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entitites
{
    public class Game
    {
        public Game(int? resultOne, int? resultTwo, int gameStatus, Guid champId)
        {
            ValidateDomain(gameStatus, champId);
            ResultTeamOne = resultOne;
            ResultTeamTwo = resultTwo;
            GameStatusId = gameStatus;
            ChampionshipId = champId;
        }



        public Game(DateTime date, string place, Team teamOne, Team teamTwo)
        {
            ValidateDomain(place, teamOne, teamTwo);
            Date = date;
            Place = place;
            TeamOne = teamOne;
            TeamTwo = teamTwo;
        }
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string Place { get; set; }
        public int? ResultTeamOne { get; set; }
        public int? ResultTeamTwo { get; set; }
        public int GameStatusId { get; set; }
        public Guid ChampionshipId { get; set; }
        public Guid TeamOneId { get; set; }
        public Team TeamOne { get; set; }
        public Guid TeamTwoId { get; set; }
        public Team TeamTwo { get; set; }

        public void ValidateDomain(string place, Team teamOne, Team teamTwo)
        {
            DomainExceptionValidation.When(place is null,
                "The place cannot be null");

            //DomainExceptionValidation.When(teamOne is empty || teamTwo is null,
            //    "Not was possible create without a teams");
        }
        public void ValidateDomain(int gameStatus, Guid champId)
        {


            DomainExceptionValidation.When(champId == Guid.Empty,
                "Not was possible create without a championship");
            DomainExceptionValidation.When(gameStatus is 0,
                "The game status cannot be undefined");
            DomainExceptionValidation.When(champId == Guid.Empty,
                "Not was possible create without a championship");

        }

    }
}
