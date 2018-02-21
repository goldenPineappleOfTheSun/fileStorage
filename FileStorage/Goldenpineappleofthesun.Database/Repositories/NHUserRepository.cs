using Goldenpineappleofthesun.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goldenpineappleofthesun.Database.Repositories
{
    public class NHUserRepository : NHRepository<UserItem>
    {
        private IList<UserItem> Users = new List<UserItem>();

        public void Save(UserItem item)
        {
            var session = NHHelper.GetCurrentSession();
            var result = session
                .CreateSQLQuery("EXEC CreateUser  @Login=:Login, @Password=:Password, @Name=:Name, @Role=:Role")
                .SetString("Login", item.Login)
                .SetString("Password", item.Password)
                .SetString("Name", item.Name)
                .SetInt64("Role", item.Role.Id)
                .ExecuteUpdate();
        }

        public UserItem GetByLogin(string login)
        {
            var session = NHHelper.GetCurrentSession();

            return session
                .QueryOver<UserItem>()
                .And(i => i.Login == login)
                .SingleOrDefault();
        }

        public bool Check(string login, string password)
        {
            var session = NHHelper.GetCurrentSession();

            return session
                .QueryOver<UserItem>()
                .And(u => u.Login == login && u.Password == password && u.Status == UserStatus.Active)
                .RowCount() > 0;
        }

        public void Delete(long id)
        {
            var user = Find(id);
            if (user != null)
            {
                user.Status = UserStatus.Deleted;
                Save(user);
            }
        }
    }
}
