using Microsoft.EntityFrameworkCore;
using Restaurant.Core;
using Restaurant.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.EF.RepositoryEF
{
    public class DishRepositoryEF : IDishRepository
    {
        private readonly RestaurantContext ctx;
        public DishRepositoryEF(RestaurantContext context)
        {
            this.ctx = context;
        }


        public bool Add(Dish newItem)
        {
            if (newItem == null)
            {
                return false;
            }
            try
            {
                ctx.Dishes.Add(newItem);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                string message = ex.Message;
                return false;
            }
        }

        public bool Delete(int id)
        {
            if (id <= 0)
            {
                return false;
            }
            try
            {
                var dish = ctx.Dishes.Find(id);

                if (dish != null)

                    ctx.Dishes.Remove(dish);
                ctx.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Edit(Dish itemToEdit)
        {

            if (itemToEdit == null)
            {
                return false;
            }
            try
            {
                ctx.Dishes.Update(itemToEdit);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Dish> Fetch()
        {
            try
            {
                return ctx.Dishes.Include(x => x.Menu).ToList();
            }
            catch (Exception)
            {
                return new List<Dish>();
            }
        }

        public Dish GetById(int id)
        {
            if (id <= 0)
            {
                return null;
            }
            return ctx.Dishes.Include(x => x.Menu).FirstOrDefault(d => d.Id == id);
        }
    }
}
