using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyPersonalWeb.Web.Data.Entities
{
    public class Country
    {
        public int CountryId { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [MaxLength(50, ErrorMessage = "The field {0} must be at least {1} characteres length.")]
        [Display(Name = "Pais")]
        public string Name { get; set; }

        public virtual ICollection<Player> Players { get; set; }
    }
}
