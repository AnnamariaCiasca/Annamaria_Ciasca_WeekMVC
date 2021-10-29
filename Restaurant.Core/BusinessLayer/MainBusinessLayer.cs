using Restaurant.Core.Interfaces;
using Restaurant.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.BusinessLayer
{
    public class MainBusinessLayer : IBusinessLayer
    {
        private readonly IDishRepository dishRepo;
        private readonly IMenùRepository menuRepo;
        private readonly IUserRepository userRepo;
 

        public MainBusinessLayer(IDishRepository dishRepository, IMenùRepository menuRepository, IUserRepository userRepository)
        {
            this.dishRepo = dishRepository;
            this.menuRepo = menuRepository;
            this.userRepo = userRepository;
        }

        #region Dish
        public bool AddNewDish(Dish newDish)
        {
            if (newDish == null)
            {
                return false;
            }
            else
            {
                return dishRepo.Add(newDish);
            }
        }
  
        public bool DeleteDish(int idDish)
        {
            if (idDish <= 0)
            {
                return false;
            }
            else
            {
                Dish dishToDelete = dishRepo.GetById(idDish);

                if (dishToDelete != null)
                {
                    return dishRepo.Delete(dishToDelete.Id);
                }
                else
                {
                    return false;
                }
            }
        }

        public bool EditDish(Dish dish)
        {
            if (dish == null)
            {
                return false;
            }
            else
            {
                return dishRepo.Edit(dish);
            }
        }

        public List<Dish> FetchDishes()
        {
            return dishRepo.Fetch();
        }

        public Dish GetDishById(int id)
        {
            if (id <= 0)
            {
                return null;
            }
            return dishRepo.GetById(id);
        }
        #endregion


        #region User
        public User GetUser(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                return null;
            }
            return userRepo.GetByUsername(username);
        }
        #endregion



        #region Menù
        public bool AddNewMenu(Menù newMenu)
        {
            if (newMenu == null)
            {
                return false;
            }
            else
            {
                return menuRepo.Add(newMenu);
            }
        }

        public bool DeleteMenu(int idMenu)
        {

            if (idMenu <= 0)
            {
                return false;
            }
            else
            {
                Menù menuToDelete = menuRepo.GetById(idMenu);

                if (menuToDelete != null)
                {
                    return menuRepo.Delete(menuToDelete.Id);
                }
                else
                {
                    return false;
                }
            }
        }

        public bool EditMenu(Menù menu)
        {
            if (menu == null)
            {
                return false;
            }
            else
            {
                return menuRepo.Edit(menu);
            }
        }

        public List<Menù> FetchMenu()
        {
            return menuRepo.Fetch();
        }

        public Menù GetMenuById(int id)
        {
            if (id <= 0)
            {
                return null;
            }
            return menuRepo.GetById(id);
        }
        #endregion
    }
}
