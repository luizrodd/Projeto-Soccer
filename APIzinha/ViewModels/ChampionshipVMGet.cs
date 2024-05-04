using Microsoft.AspNetCore.Routing.Constraints;

namespace APIzinha.ViewModels
{
    public class ChampionshipVMGet
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public int Rounds { get; set; }

        public int Teams { get; set; }
        public int Games { get; set; }
    }
}
