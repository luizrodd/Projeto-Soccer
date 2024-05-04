using APIzinha.Entitites;
using Domain.Entitites;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Test
{
    public class UserUnitTest
    {
        #region postive cases
        [Fact(DisplayName = "Create user with valids parameters")]
        public void CreateUser_WithValidParemeters_ResultValid()
        {
            Action action = () => new User("Neymar da Silva Santos Junior", "Neymar", "neymar@gmail.com", "santosmelhordomundo123", "16997566345");
            action.Should()
                .NotThrow<Domain.Validation.DomainExceptionValidation>();
        }
        #endregion

        #region negative cases
        [Fact(DisplayName = "Create user without name")]
        public void CreateUser_WithoutName_ResultValid()
        {
            Action action = () => new User(null, "Neymar", "neymar@gmail.com", "santosmelhordomundo123", "16997566345");
            action.Should()
                .Throw<Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Name cannot be null");
        }
        [Fact(DisplayName = "Create user with name longer than 40 characters")]
        public void CreateUser_WithNameLongerThan40Characters_ResultValid()
        {
            Action action = () => new User("ThisIsAVeryLongNameThatExceedsFortyCharactersLimit", "Neymar", "neymar@gmail.com", "santosmelhordomundo123", "16997566345");
            action.Should()
                .Throw<Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Name cannot be longer than 40 characters");
        }

        [Fact(DisplayName = "Create user with null display name")]
        public void CreateUser_WithNullDisplayName_ResultValid()
        {
            Action action = () => new User("Neymar", null, "neymar@gmail.com", "santosmelhordomundo123", "16997566345");
            action.Should()
                .Throw<Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Display name cannot be null");
        }

        [Fact(DisplayName = "Create user with display name longer than 20 characters")]
        public void CreateUser_WithDisplayNameLongerThan20Characters_ResultValid()
        {
            Action action = () => new User("Neymar", "ThisIsAVeryLongDisplayNameThatExceedsTwentyCharactersLimit", "neymar@gmail.com", "santosmelhordomundo123", "16997566345");
            action.Should()
                .Throw<Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Display name cannot be longer than 20 characters");
        }

        [Fact(DisplayName = "Create user with null email")]
        public void CreateUser_WithNullEmail_ResultValid()
        {
            Action action = () => new User("Neymar", "Neymar Jr.", null, "santosmelhordomundo123", "16997566345");
            action.Should()
                .Throw<Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Email cannot be null");
        }

        [Fact(DisplayName = "Create user with email longer than 40 characters")]
        public void CreateUser_WithEmailLongerThan40Characters_ResultValid()
        {
            Action action = () => new User("Neymar", "Neymar Jr.", "neymar@gmail.com".PadRight(45, 'a'), "santosmelhordomundo123", "16997566345");
            action.Should()
                .Throw<Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Email cannot be longer than 40 characters");
        }

        [Fact(DisplayName = "Create user with null password")]
        public void CreateUser_WithNullPassword_ResultValid()
        {
            Action action = () => new User("Neymar", "Neymar Jr.", "neymar@gmail.com", null, "16997566345");
            action.Should()
                .Throw<Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Password cannot be null");
        }

        [Fact(DisplayName = "Create user with password longer than 40 characters")]
        public void CreateUser_WithPasswordLongerThan40Characters_ResultValid()
        {
            Action action = () => new User("Neymar", "Neymar Jr.", "neymar@gmail.com", "santosmelhordomundo123".PadRight(45, 'a'), "16997566345");
            action.Should()
                .Throw<Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Password cannot be longer than 40 characters");
        }

        [Fact(DisplayName = "Create user with null phone")]
        public void CreateUser_WithNullPhone_ResultValid()
        {
            Action action = () => new User("Neymar", "Neymar Jr.", "neymar@gmail.com", "santosmelhordomundo123", null);
            action.Should()
                .Throw<Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Phone cannot be null");
        }

        [Fact(DisplayName = "Create user with phone longer than 20 characters")]
        public void CreateUser_WithPhoneLongerThan20Characters_ResultValid()
        {
            Action action = () => new User("Neymar", "Neymar Jr.", "neymar@gmail.com", "santosmelhordomundo123", "1699756634567891234590");
            action.Should()
                .Throw<Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Phone cannot be longer than 20 characters");
        }
        #endregion
    }
}
