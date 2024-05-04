using Service.DTOs;

namespace APIzinha.ViewModels
{
    public class TeamsVMGet
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public Guid ChampionshipId { get; set; }
    }
}
