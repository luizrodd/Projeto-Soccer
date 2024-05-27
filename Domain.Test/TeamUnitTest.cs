using FluentAssertions;
using Domain.Entitites;

namespace Domain.Test
{
    public class TeamUnitTest
    {
        #region positive cases
        [Fact(DisplayName = "Create Team with name and image not null")]
        public void CreateTeam_WithValidParemeters_ResultValid()
        {
            Action action = () => new Team("Santos", "www.santosimagem.com");
            action.Should()
                .NotThrow<Domain.Validation.DomainExceptionValidation>();
        }
        [Fact(DisplayName = "Create Team with image null")]
        public void CreateTeam_WithNullImage_ResultValid()
        {
            Action action = () => new Team("Santos", null);
            action.Should()
                .NotThrow<Domain.Validation.DomainExceptionValidation>();
        }
       

        #endregion

        #region negative cases
        [Fact(DisplayName = "Create Team with name null")]
        public void CreateTeam_WithInvalidName_ResultInvalid()
        {
            Action action = () => new Team(null, "link.com");
            action.Should()
                .Throw<Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name. Name is required!");
        }
        [Fact(DisplayName = "Create Team with name too long")]
        public void CreateTeam_WithLongName_ResultInvalid()
        {
            Action action = () => new Team("Marcelino de Almeida da Silva e Souza Andre Silva", "link.com");
            action.Should()
                .Throw<Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Name is maximun 40 charecters");
        }
        #endregion
    }
}
