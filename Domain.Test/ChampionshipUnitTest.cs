using Domain.Entitites;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Test
{
    public class ChampionshipUnitTest
    {
        //#region positive cases
        //[Fact(DisplayName = "Create championship with valids parameters")]
        //public void CreateChampionship_WithValidParemeters_ResultValid()
        //{
        //    Action action = () => new Championship("La Liga", "image.com.br", 32);
        //    action.Should()
        //        .NotThrow<Domain.Validation.DomainExceptionValidation>();
        //}
        //[Fact(DisplayName = "Create championship without image")]
        //public void CreateChampionship_WithoutImage_ResultValid()
        //{
        //    Action action = () => new Championship("La Liga", null, 32);
        //    action.Should()
        //        .NotThrow<Domain.Validation.DomainExceptionValidation>();
        //}
        //#endregion

        //#region negative cases
        //[Fact(DisplayName = "Create championship without name")]
        //public void CreateChampionship_WithoutName_ResultInvalid()
        //{
        //    Action action = () => new Championship(null, "image.com.br", 32);
        //    action.Should()
        //        .Throw<Domain.Validation.DomainExceptionValidation>()
        //        .WithMessage("Name cannot be null");
        //}
        //[Fact(DisplayName = "Create championship with long name")]
        //public void CreateChampionship_WithLongName_ResultInvalid()
        //{
        //    Action action = () => new Championship("NomeGrande".PadRight(41, 'N'), "image.com.br", 32);
        //    action.Should()
        //        .Throw<Domain.Validation.DomainExceptionValidation>()
        //        .WithMessage("Name cannot be longer than 40 characters");
        //}
        //[Fact(DisplayName = "Create championship with long rounds")]
        //public void CreateChampionship_WithLongRounds_ResultInvalid()
        //{
        //    Action action = () => new Championship("La Liga", "image.com.br", 100);
        //    action.Should()
        //        .Throw<Domain.Validation.DomainExceptionValidation>()
        //        .WithMessage("Rounds cannot be longer than 99");
        //}
        //#endregion
    }
}
