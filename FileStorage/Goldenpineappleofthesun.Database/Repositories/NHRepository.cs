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
            var item = Find(id);

            if (item != null)
            {
                var session = NHHelper.GetCurrentSession();
                try
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        session.Delete(item);
                        transaction.Commit();
                    }
                }
                finally
                {
                    NHHelper.CloseSession();
                }
            }
        }

        public T Find(long id)
        {
            var session = NHHelper.GetCurrentSession();

            return session.Get<T>(id);
        }

        public IList<T> GetAll()
        {
            using (var session = NHHelper.GetCurrentSession())
            {
                return session.CreateCriteria<T>().List<T>();
            }
        }

        public IEnumerable<T> GetAll(string condition)
        {
            return GetAll();
        }

        public void Save(T item)
        {
            var session = NHHelper.GetCurrentSession();
            try
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.SaveOrUpdate(item);
                    transaction.Commit();
                }
            }
            finally
            {
                NHHelper.CloseSession();
            }
        }
    }
}
