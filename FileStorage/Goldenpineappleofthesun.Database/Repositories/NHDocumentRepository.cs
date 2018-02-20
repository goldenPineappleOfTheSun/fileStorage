using Goldenpineappleofthesun.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goldenpineappleofthesun.Database.Repositories
{
    public class NHDocumentRepository : NHRepository<DocumentItem>
    {
        public void Save(DocumentItem item)
        {
            var session = NHHelper.GetCurrentSession();
            var result = session
                .CreateSQLQuery("EXEC CreateDocument  @Name=:Name, @Date=:Date, @Author=:Author, @FileName=:FileName")
                .SetParameter("Name", item.Name)
                .SetParameter("Date", item.CreationDate)
                .SetParameter("Author", 4)
                .SetParameter("FileName", item.FileName)
                .ExecuteUpdate();
        }
    }
}
