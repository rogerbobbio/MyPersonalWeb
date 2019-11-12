using System.ComponentModel.DataAnnotations;

namespace MyPersonalWeb.Web.Data.Entities
{
    public class Player
    {
        public int PlayerId { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [MaxLength(256, ErrorMessage = "The field {0} must be at least {1} characteres length.")]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        public int Rating { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        public int Occurrence { get; set; }

        public bool Rare { get; set; }

        public bool Select { get; set; }

        public bool Champions { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [Range(1, double.MaxValue, ErrorMessage = "You must select a {0}")]
        [Display(Name = "Tipo")]
        public int PlayerTypeId { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [Range(1, double.MaxValue, ErrorMessage = "You must select a {0}")]
        [Display(Name = "Liga")]
        public int LeagueId { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [Range(1, double.MaxValue, ErrorMessage = "You must select a {0}")]
        [Display(Name = "Equipo")]
        public int TeamId { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [Range(1, double.MaxValue, ErrorMessage = "You must select a {0}")]
        [Display(Name = "Posicion Campo")]
        public int PositionId { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [Range(1, double.MaxValue, ErrorMessage = "You must select a {0}")]
        [Display(Name = "Rol")]
        public int PositionRolId { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [Range(1, double.MaxValue, ErrorMessage = "You must select a {0}")]
        [Display(Name = "Pais")]
        public int CountryId { get; set; }



        public virtual PlayerType PlayerType { get; set; }

        public virtual League League { get; set; }

        public virtual Team Team { get; set; }

        public virtual Position Position { get; set; }

        public virtual PositionRol PositionRol { get; set; }

        public virtual Country Country { get; set; }
    }
}
