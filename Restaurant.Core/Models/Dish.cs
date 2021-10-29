using Restaurant.Core.Models;
using System;

namespace Restaurant.Core
{
    public class Dish
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Typology Type { get; set; }

        public Menù Menu { get; set; }
        public int IdMenu { get; set; }

    }

    public enum Typology
    {
        FirstCourse,
        SecondCourse,
        Side,
        Dessert
    }
}
