using Goldenpineappleofthesun.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goldenpineappleofthesun.Database.Repositories
{
    public class NHRoleRepository : NHRepository<RoleItem>
    {
        public RoleItem GetByName(string name)
        {
            var session = NHHelper.GetCurrentSession();

            return session
                .QueryOver<RoleItem>()
                .And(i => i.Name == name)
                .SingleOrDefault();
        }
    }
}
