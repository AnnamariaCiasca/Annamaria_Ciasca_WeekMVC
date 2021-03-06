using Restaurant.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        User GetByUsername(string username);

    }
}
