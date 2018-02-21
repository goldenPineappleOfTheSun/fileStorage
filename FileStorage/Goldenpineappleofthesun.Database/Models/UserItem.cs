using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goldenpineappleofthesun.Database.Models
{
    public class UserItem : IEntity
    {
        public virtual long Id { get; set; }

        public virtual string Name { get; set; }

        public virtual string Login { get; set; }

        public virtual string Password { get; set; }

        public virtual RoleItem Role { get; set; }

        public virtual UserStatus Status { get; set; }
    }

    public enum UserStatus
    {
        Deleted = 0,
        Active = 1,
        Banned = 2
    }
}
