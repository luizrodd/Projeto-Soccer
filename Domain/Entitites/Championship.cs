namespace Domain.Entitites
{
    public class Championship
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int Rounds { get; set; }
        public List<Game> GamesList { get; set; } = new List<Game>();
        public List<Team> TeamsList { get; set; } = new List<Team>();

    }
}
