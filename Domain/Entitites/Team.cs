namespace Domain.Entitites
{
    public class Team
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public List<News> NewsList { get; set; }
        public Guid ChampionshipId { get; set; }
        public Guid TeamOneId { get; set; }
        public Guid TeamTwoId { get; set;}

    }
}
