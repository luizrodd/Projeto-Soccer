using Domain.Validation;

namespace Domain.Entitites
{
    public class Team
    {
        //public Team(string name, string image)
        //{
        //    ValidateDomain(name);
        //    Name = name;
        //    Image = image;
        //}
        
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public IEnumerable<Game> GamesOne { get; set; }
        public IEnumerable<Game> GamesTwo { get; set; }

        //public void ValidateDomain(string name)
        //{
        //    DomainExceptionValidation.When(string.IsNullOrEmpty(name),
        //        "Invalid name. Name is required!");

        //    DomainExceptionValidation.When(name.Length > 40,
        //        "Name is maximun 40 charecters");
        //}

    }
}
