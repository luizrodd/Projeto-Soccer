using Domain.Validation;

namespace Domain.Entitites
{
    public class Team
    {
        public Team(string name, string image)
        {
            ValidateDomain(name);
            Name = name;
            Image = image;
        }
        public Team(string name, string image, Guid champId)
        {
            ValidateDomain(name);
            Name = name;
            Image = image;
            ChampionshipId = champId;
        }
        
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public List<News> NewsList { get; set; }
        public Guid ChampionshipId { get; set; }

        public void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Invalid name. Name is required!");

            DomainExceptionValidation.When(name.Length > 40,
                "Name is maximun 40 charecters");
        }

    }
}
