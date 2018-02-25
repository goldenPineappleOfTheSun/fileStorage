using Goldenpineappleofthesun.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goldenpineappleofthesun.Database.Repositories
{
    public class NHSampleRepository : NHRepository<SampleItem>
    {
        public SampleItem GetByPath(string path)
        {
            var session = NHHelper.GetCurrentSession();

            return session
                .QueryOver<SampleItem>()
                .And(i => i.RelPath == path)
                .SingleOrDefault();
        }
    }
}
