using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Models
{
    public class Menù
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Dish> Dishes { get; set; } = new List<Dish>();
    }
}
