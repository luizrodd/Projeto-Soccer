using Domain.Validation;

namespace Domain.Entitites
{
    public class Championship
    {
        public Championship(string name, string image, int rounds) {
            ValidateDomain(name, rounds);
            Name = name;
            Image = image;
            Rounds = rounds;
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int Rounds { get; set; }



        public void ValidateDomain(string name, int rounds)
        {
            DomainExceptionValidation.When(name is null,
                "Name cannot be null");
            DomainExceptionValidation.When(name.Length > 40,
                "Name cannot be longer than 40 characters");
            DomainExceptionValidation.When(rounds > 99,
                "Rounds cannot be longer than 99");
        }
    }
}
