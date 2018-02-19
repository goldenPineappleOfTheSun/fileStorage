using Goldenpineappleofthesun.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goldenpineappleofthesun.Database.Repositories
{
    public interface IRepository<T>
         where T : IEntity
    {
        T Find(long id);

        void Save(T item);

        void Delete(long id);

        IList<T> GetAll();
    }
}
