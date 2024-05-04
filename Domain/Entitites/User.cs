using Domain.Validation;

namespace APIzinha.Entitites
{
    public class User
    {
        public User(string name, string displayName, string email, string password, string phone) {
            Validations(name, displayName, email, password, phone);
            Name = name;
            DisplayName = displayName;
            Email = email;
            Password = password;
            Phone = phone;
        }
        
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public bool isAdmin { get; set; }

        public void Validations(string name, string displayName, string email, string password, string phone)
        {
            DomainExceptionValidation.When(name is null,
                "Name cannot be null");
            DomainExceptionValidation.When(name.Length > 40,
                "Name cannot be longer than 40 characters");
            DomainExceptionValidation.When(displayName is null,
                "Display name cannot be null");
            DomainExceptionValidation.When(displayName.Length > 20,
                "Display name cannot be longer than 20 characters");
            DomainExceptionValidation.When(email is null,
                "Email cannot be null");
            DomainExceptionValidation.When(email.Length > 40,
                "Email cannot be longer than 40 characters");
            DomainExceptionValidation.When(password is null,
                "Password cannot be null");
            DomainExceptionValidation.When(password.Length > 40,
                "Password cannot be longer than 40 characters");
            DomainExceptionValidation.When(phone is null,
                "Phone cannot be null");
            DomainExceptionValidation.When(phone.Length > 20,
                "Phone cannot be longer than 20 characters");
        }
    }
}
