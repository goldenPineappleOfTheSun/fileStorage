using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goldenpineappleofthesun.Database.Models
{
    public class DocumentItem : IEntity
    {
        public virtual long Id { get; set; }

        public virtual string Name { get; set; }

        public virtual DateTime CreationDate { get; set; }

        public virtual UserItem Author { get; set; }

        public virtual string FileName { get; set; }

        public virtual DocumentStatus Status { get; set; }
    }

    public enum DocumentStatus
    {
        Missed = 0,
        Normal = 1,
    }
}
