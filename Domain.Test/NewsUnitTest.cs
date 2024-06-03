//using Domain.Entitites;
//using FluentAssertions;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Domain.Test
//{
//    public class NewsUnitTest
//    {
//        #region positive cases
//        [Fact(DisplayName = "Create News with valids parameters")]
//        public void CreateNews_WithValidParemeters_ResultValid()
//        {
//            Action action = () => new News("Neymar voltou ao peixe", "O atacante voltou ao santos e vai ganhar muitos títulos e bla bla bla bla bla", "image.com.br", "minhacabeca.com.br", new Guid("6b89b85e-80f7-4c02-af29-dbb4c6219b8d"));
//            action.Should()
//                .NotThrow<Domain.Validation.DomainExceptionValidation>();
//        }
//        [Fact(DisplayName = "Create News without image")]
//        public void CreateNews_WithoutImage_ResultValid()
//        {
//            Action action = () => new News("Neymar voltou ao peixe", "O atacante voltou ao santos e vai ganhar muitos títulos e bla bla bla bla bla", null, "minhacabeca.com.br", new Guid("6b89b85e-80f7-4c02-af29-dbb4c6219b8d"));
//            action.Should()
//                .NotThrow<Domain.Validation.DomainExceptionValidation>();
//        }
//        [Fact(DisplayName = "Create News without team")]
//        public void CreateNews_WithoutTeam_ResultValid()
//        {
//            Action action = () => new News("Neymar voltou ao peixe", "O atacante voltou ao santos e vai ganhar muitos títulos e bla bla bla bla bla", "image.com.br", "minhacabeca.com.br");
//            action.Should()
//                .NotThrow<Domain.Validation.DomainExceptionValidation>();
//        }
//        #endregion

//        #region negative cases
//        [Fact(DisplayName = "Create News without title")]
//        public void CreateNews_WithoutTitle_ResultInvalid()
//        {
//            Action action = () => new News(null, "O atacante voltou ao santos e vai ganhar muitos títulos e bla bla bla bla bla", "image.com.br", "minhacabeca.com.br", new Guid("6b89b85e-80f7-4c02-af29-dbb4c6219b8d"));
//            action.Should()
//                .Throw<Domain.Validation.DomainExceptionValidation>()
//                .WithMessage("Title cannot be null");
//        }
//        [Fact(DisplayName = "Create News with long title")]
//        public void CreateNews_WithLongTitle_ResultInvalid()
//        {
//            Action action = () => new News("sghdajfgagfhafayruiayrjagfjahbjfhajfhajfhasjifhauifyhauifhajfasas", "O atacante voltou ao santos e vai ganhar muitos títulos e bla bla bla bla bla", "image.com.br", "minhacabeca.com.br", new Guid("6b89b85e-80f7-4c02-af29-dbb4c6219b8d"));
//            action.Should()
//                .Throw<Domain.Validation.DomainExceptionValidation>()
//                .WithMessage("Title cannot be longer than 50 characters");
//        }
//        [Fact(DisplayName = "Create News without description")]
//        public void CreateNews_WithoutDesciption_ResultInvalid()
//        {
//            Action action = () => new News("neymar voltou bla", null, "image.com.br", "minhacabeca.com.br", new Guid("6b89b85e-80f7-4c02-af29-dbb4c6219b8d"));
//            action.Should()
//                .Throw<Domain.Validation.DomainExceptionValidation>()
//                .WithMessage("Description cannot be null");
//        }
//        [Fact(DisplayName = "Create News with long description")]
//        public void CreateNews_WithLongDesciption_ResultInvalid()
//        {
//            Action action = () => new News("neymar voltou bla", "adescriptiona".PadRight(160, 'a'), "image.com.br", "minhacabeca.com.br", new Guid("6b89b85e-80f7-4c02-af29-dbb4c6219b8d"));
//            action.Should()
//                .Throw<Domain.Validation.DomainExceptionValidation>()
//                .WithMessage("Description cannot be longer than 150 characters");
//        }
//        [Fact(DisplayName = "Create News without description")]
//        public void CreateNews_WithoutSource_ResultInvalid()
//        {
//            Action action = () => new News("neymar voltou bla", "description", "image.com.br", null, new Guid("6b89b85e-80f7-4c02-af29-dbb4c6219b8d"));
//            action.Should()
//                .Throw<Domain.Validation.DomainExceptionValidation>()
//                .WithMessage("Source cannot be null");
//        }

//        #endregion
//    }
//}
