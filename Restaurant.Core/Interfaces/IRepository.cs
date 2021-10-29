using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Interfaces
{
    public interface IRepository<T>
    {
        List<T> Fetch();
        T GetById(int id);
        bool Add(T newItem);
        bool Edit(T itemToEdit);
        bool Delete(int id);
    }
}