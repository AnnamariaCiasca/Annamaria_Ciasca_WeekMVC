using Microsoft.EntityFrameworkCore;
using Restaurant.Core.Interfaces;
using Restaurant.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.EF.RepositoryEF
{
    public class MenùRepositoryEF : IMenùRepository
    {
        private readonly RestaurantContext ctx;
        public MenùRepositoryEF(RestaurantContext context)
        {
            this.ctx = context;
        }

        public bool Add(Menù newItem)
        {
            if (newItem == null)
            {
                return false;
            }
            try
            {
                ctx.Menus.Add(newItem);
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
                var menu = ctx.Menus.Find(id);

                if (menu != null)

                ctx.Menus.Remove(menu);
                ctx.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Edit(Menù itemToEdit)
        {
            if (itemToEdit == null)
            {
                return false;
            }
            try
            {
                ctx.Menus.Update(itemToEdit);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Menù> Fetch()
        {
            try
            {
                return ctx.Menus.Include(m => m.Dishes).ToList();
            }
            catch (Exception)
            {
                return new List<Menù>();
            }
        }

        public Menù GetById(int id)
        {

            if (id <= 0)
            {
                return null;
            }
            return ctx.Menus.Include(m => m.Dishes).FirstOrDefault(m => m.Id == id);
        }
    }
    }

