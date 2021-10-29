using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.MVC.Models
{
    public class MenùViewModel
    {
        [Required(ErrorMessage = "Required Field")]
        [DisplayName("Id")]
        public int Id { get; set; }

        [Required]
        [DisplayName("Name")]
        public string Name { get; set; }


        public List<DishViewModel> Dishes { get; set; } = new List<DishViewModel>();
    }
}
