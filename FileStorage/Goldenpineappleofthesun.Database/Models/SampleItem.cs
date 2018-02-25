using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goldenpineappleofthesun.Database.Models
{
    public class SampleItem : IEntity
    {
        public virtual long Id { get; set; }

        public virtual string Title { get; set; }

        public virtual string RelPath { get; set; }
    }

    // TODO: statuses
}
