using Service.DTOs;

namespace APIzinha.ViewModels
{
    public class TeamsVMCreate
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public List<NewsDTO> NewsList { get; set; } = new List<NewsDTO>();
        public Guid ChampionshipId { get; set; }
    }
}
