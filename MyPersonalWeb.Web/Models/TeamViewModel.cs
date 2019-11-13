using MyPersonalWeb.Web.Data.Entities;

namespace MyPersonalWeb.Web.Models
{
    public class TeamViewModel : Team
    {
        public int LeagueId { get; set; }

        public string LeagueName { get; set; }
    }
}
