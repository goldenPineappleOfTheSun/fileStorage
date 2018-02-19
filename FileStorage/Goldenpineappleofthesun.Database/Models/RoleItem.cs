using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goldenpineappleofthesun.Database.Models
{
    class RoleItem : IEntity
    {
        public virtual long Id { get; set; }

        public virtual string Name { get; set; }
    }
}
