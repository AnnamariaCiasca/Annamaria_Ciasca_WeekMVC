using Restaurant.Core;
using Restaurant.Core.Models;
using Restaurant.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.MVC.Helpers
{
    public static class Mapping
    {
        public static MenùViewModel ToMenùViewModel(this Menù menu)
        {
            List<DishViewModel> dishesViewModel = new List<DishViewModel>();
            foreach (var item in menu.Dishes)
            {
                dishesViewModel.Add(item?.ToDishViewModel());
            }

            return new MenùViewModel
            {
                Id = menu.Id,
                Name = menu.Name,
                Dishes = dishesViewModel
            };
        }

        public static Menù ToMenù(this MenùViewModel menuViewModel)
        {
            List<Dish> dishes = new List<Dish>();
            foreach (var item in menuViewModel.Dishes)
            {
                dishes.Add(item?.ToDish());
            }

            return new Menù
            {
                Id = menuViewModel.Id,
                Name = menuViewModel.Name,
                Dishes = dishes
            };
        }

        public static DishViewModel ToDishViewModel(this Dish dish)
        {
            return new DishViewModel
            {
                Id = dish.Id,
                Name = dish.Name,
                Description = dish.Description,
                Price = dish.Price,
                Type = dish.Type,
                IdMenu = dish.IdMenu
            };
        }

        public static Dish ToDish(this DishViewModel dishViewModel)
        {
            return new Dish
            {
                Id = dishViewModel.Id,
                Name = dishViewModel.Name,
                Description = dishViewModel.Description,
                Price = dishViewModel.Price,
                Type = dishViewModel.Type,
                IdMenu = dishViewModel.IdMenu
            };
        }
    }
}
