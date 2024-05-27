//using Domain.Entitites;
//using FluentAssertions;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Domain.Test
//{
//    public class GameUnitTest
//    {
//        #region postive cases
//        [Fact(DisplayName = "Create game with valids parameters")]
//        public void CreateGame_WithValidParemeters_ResultValid()
//        {
//            Action action = () => new Game(new DateTime(), "Bernabeu", 1, 0,  1, new Guid("c5e760e8-9e2b-4c8e-b0b4-aaa9a402e0c3"), new Team("Santos", null), new Team("Real Madrid", null));
//            action.Should()
//                .NotThrow<Domain.Validation.DomainExceptionValidation>();
//        }
//        [Fact(DisplayName = "Create game without score")]
//        public void CreateGame_WithoutScore_ResultValid()
//        {
//            Action action = () => new Game(new DateTime(), "Bernabeu", null, null, 1, new Guid("c5e760e8-9e2b-4c8e-b0b4-aaa9a402e0c3"), new Team("Santos", null), new Team("Real Madrid", null));
//            action.Should()
//                .NotThrow<Domain.Validation.DomainExceptionValidation>();
//        }
//        #endregion

//        #region negative cases
//        [Fact(DisplayName = "Create game without place")]
//        public void CreateGame_WithoutPlace_ResultInvalid()
//        {
//            Action action = () => new Game(new DateTime(), null, 1, 0, 1, new Guid("c5e760e8-9e2b-4c8e-b0b4-aaa9a402e0c3"), new Team("Santos", null), new Team("Real Madrid", null));
//            action.Should()
//                .Throw<Domain.Validation.DomainExceptionValidation>()
//                .WithMessage("The place cannot be null");
//        }
//        [Fact(DisplayName = "Create game without status")]
//        public void CreateGame_WithoutStatus_ResultInvalid()
//        {
//            Action action = () => new Game(new DateTime(), "Bernabeu", 1, 0, 0, new Guid("c5e760e8-9e2b-4c8e-b0b4-aaa9a402e0c3"), new Team("Santos", null), new Team("Real Madrid", null));
//            action.Should()
//                .Throw<Domain.Validation.DomainExceptionValidation>()
//                .WithMessage("The game status cannot be undefined");
//        }
//        [Fact(DisplayName = "Create game without championship")]
//        public void CreateGame_WithoutChampionship_ResultInvalid()
//        {
//            Action action = () => new Game(new DateTime(), "Bernabeu", 1, 0, 1, new Guid(), new Team("Santos", null), new Team("Real Madrid", null));
//            action.Should()
//                .Throw<Domain.Validation.DomainExceptionValidation>()
//                .WithMessage("Not was possible create without a championship");
//        }
//        [Fact(DisplayName = "Create game without first team")]
//        public void CreateGame_WithoutFirstTeam_ResultInvalid()
//        {
//            Action action = () => new Game(new DateTime(), "Bernabeu", 1, 0, 1, new Guid("c5e760e8-9e2b-4c8e-b0b4-aaa9a402e0c3"), new Team("Santos", null), null);
//            action.Should()
//                .Throw<Domain.Validation.DomainExceptionValidation>()
//                .WithMessage("Not was possible create without a teams");
//        }
//        [Fact(DisplayName = "Create game without second team")]
//        public void CreateGame_WithoutSecondTeam_ResultInvalid()
//        {
//            Action action = () => new Game(new DateTime(), "Bernabeu", 1, 0, 1, new Guid("c5e760e8-9e2b-4c8e-b0b4-aaa9a402e0c3"), null, new Team("Santos", null));
//            action.Should()
//                .Throw<Domain.Validation.DomainExceptionValidation>()
//                .WithMessage("Not was possible create without a teams");
//        }
//        [Fact(DisplayName = "Create game without teams")]
//        public void CreateGame_WithoutTeams_ResultInvalid()
//        {
//            Action action = () => new Game(new DateTime(), "Bernabeu", 1, 0, 1, new Guid("c5e760e8-9e2b-4c8e-b0b4-aaa9a402e0c3"), null, null);
//            action.Should()
//                .Throw<Domain.Validation.DomainExceptionValidation>()
//                .WithMessage("Not was possible create without a teams");
//        }

//        #endregion
//    }
//}
