using Restaurant.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.MVC.Models
{
    public class DishViewModel
    {
        [Required(ErrorMessage = "Required Field"), DisplayName("Id")]
        public int Id { get; set; }


        [Required, DisplayName("Name")]
        public string Name { get; set; }


        [Required, DisplayName("Description")]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public Typology Type { get; set; }

        public int IdMenu { get; set; }
        public MenùViewModel Menu { get; set; }
    }
}

