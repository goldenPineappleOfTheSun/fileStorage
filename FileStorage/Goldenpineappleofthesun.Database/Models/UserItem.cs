using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goldenpineappleofthesun.Database.Models
{
    class UserItem : IEntity
    {
        public virtual long Id { get; set; }

        public virtual string Name { get; set; }

        public virtual string Login { get; set; }

        public virtual string Password { get; set; }

        public virtual RoleItem Role { get; set; }
    }
}
