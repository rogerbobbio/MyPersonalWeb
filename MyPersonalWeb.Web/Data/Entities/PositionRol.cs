using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyPersonalWeb.Web.Data.Entities
{
    public class PositionRol
    {
        public int PositionRolId { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [MaxLength(50, ErrorMessage = "The field {0} must be at least {1} characteres length.")]
        [Display(Name = "Posicion")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [Range(1, double.MaxValue, ErrorMessage = "You must select a {0}")]
        [Display(Name = "Posicion Campo")]
        public int PositionId { get; set; }

        public virtual Position Position { get; set; }

        public virtual ICollection<Player> Players { get; set; }
    }
}
