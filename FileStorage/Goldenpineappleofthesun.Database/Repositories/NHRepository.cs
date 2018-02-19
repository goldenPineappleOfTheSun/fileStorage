using Goldenpineappleofthesun.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goldenpineappleofthesun.Database.Repositories
{
    public class NHRepository<T> : IRepository<T>
         where T : class, IEntity
    {
        public void Delete(long id)
        {
            throw new NotImplementedException();
        }

        public T Find(long id)
        {
            throw new NotImplementedException();
        }

        public IList<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Save(T item)
        {
            throw new NotImplementedException();
        }
    }
}
