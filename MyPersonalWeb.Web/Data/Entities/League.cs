using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyPersonalWeb.Web.Data.Entities
{
    public class League
    {
        public int LeagueId { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [MaxLength(100, ErrorMessage = "The field {0} must be at least {1} characteres length.")]
        [Display(Name = "Liga")]
        public string Name { get; set; }

        public virtual ICollection<Team> Teams { get; set; }

        public virtual ICollection<Player> Players { get; set; }
    }
}
