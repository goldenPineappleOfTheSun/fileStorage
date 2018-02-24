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

        public IEnumerable<DocumentItem> GetAllDocumentsOfUsers(IEnumerable<string> logins)
        {
            var session = NHHelper.GetCurrentSession();

            return session
                .QueryOver<DocumentItem>()
                .And(i => logins.Any(j => i.Author.Login == j))
                .List<DocumentItem>();
        }

        public IEnumerable<DocumentItem> GetAllDocumentsOfUsers(IEnumerable<UserItem> users)
        {
            var session = NHHelper.GetCurrentSession();

            return session
                .QueryOver<DocumentItem>()
                .And(i => users.Any(j => i.Author.Id == j.Id))
                .List<DocumentItem>();
        }

        public IEnumerable<DocumentItem> GetAllUserDocuments(UserItem author)
        {
            var session = NHHelper.GetCurrentSession();

            return session
                .QueryOver<DocumentItem>()
                .And(i => i.Author == author)
                .List<DocumentItem>();
        }

        public DocumentItem GetUserDocument(UserItem author, string name)
        {
            var session = NHHelper.GetCurrentSession();

            return session
                .QueryOver<DocumentItem>()
                .And(i => i.Author == author && i.Name == name)
                .SingleOrDefault();
        }

        public void Save(DocumentItem item)
        {
            if (item.Id == 0)
            {
                var session = NHHelper.GetCurrentSession();
                var result = session
                    .CreateSQLQuery("EXEC CreateDocument  @Name=:Name, @Date=:Date, @Author=:Author, @FileName=:FileName")
                    .SetParameter("Name", item.Name)
                    .SetParameter("Date", item.CreationDate)
                    .SetParameter("Author", item.Author.Id)
                    .SetParameter("FileName", item.FileName)
                    .ExecuteUpdate();
            }
            else
            {
                base.Save(item);
            }
        }

        public void MarkAs(long id, DocumentStatus status)
        {
            var doc = Find(id);
            if (doc != null)
            {
                doc.Status = status;
                Save(doc);
            }
        }
    }
}
