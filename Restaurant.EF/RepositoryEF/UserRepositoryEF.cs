using Restaurant.Core.Interfaces;
using Restaurant.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.EF.RepositoryEF
{
    public class UserRepositoryEF : IUserRepository
    {
        private readonly RestaurantContext ctx;

    public UserRepositoryEF(RestaurantContext context)
    {
        this.ctx = context;
    }

        public bool Add(User newItem)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool Edit(User itemToEdit)
        {
            throw new NotImplementedException();
        }

        public List<User> Fetch()
        {
            throw new NotImplementedException();
        }

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public User GetByUsername(string username)
        {
            if (String.IsNullOrEmpty(username))
            {
                throw new ArgumentException("Invalid username");
            }
            try
            {
                return ctx.Users.FirstOrDefault(x => x.Username.Equals(username));
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}