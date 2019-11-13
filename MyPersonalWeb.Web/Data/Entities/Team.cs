using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyPersonalWeb.Web.Data.Entities
{
    public class Team
    {
        public int TeamId { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [MaxLength(50, ErrorMessage = "The field {0} must be at least {1} characteres length.")]
        [Display(Name = "Equipo")]
        public string Name { get; set; }

        public virtual League League { get; set; }

        public virtual ICollection<Player> Players { get; set; }
    }
}
