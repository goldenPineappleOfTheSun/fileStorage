using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goldenpineappleofthesun.Database.Models
{
    class DocumentItem : IEntity
    {
        public virtual long Id { get; set; }

        public virtual string Name { get; set; }

        public virtual DateTime Date { get; set; }

        public virtual UserItem Author { get; set; }

        public virtual string FileName { get; set; }
    }
}
