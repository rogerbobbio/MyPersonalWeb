﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyPersonalWeb.Web.Data.Entities
{
    public class Position
    {
        public int PositionId { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [MaxLength(50, ErrorMessage = "The field {0} must be at least {1} characteres length.")]
        [Display(Name = "Posicion Campo")]
        public string Name { get; set; }

        public virtual ICollection<PositionRol> PositionRols { get; set; }

        public virtual ICollection<Player> Players { get; set; }
    }
}