using Restaurant.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.BusinessLayer
{
   public interface IBusinessLayer
    {
        #region Dish
        List<Dish> FetchDishes();
        Dish GetDishById(int id);
        bool AddNewDish(Dish newDish);
        bool EditDish(Dish dish);
        bool DeleteDish(int idDish);
        #endregion


        #region User
        User GetUser(string username);
        #endregion


        #region Menù
        List<Menù> FetchMenu();
        Menù GetMenuById(int id);
        bool AddNewMenu(Menù newMenu);
        bool EditMenu(Menù menu);
        bool DeleteMenu(int idMenu);
        #endregion

    }
}
