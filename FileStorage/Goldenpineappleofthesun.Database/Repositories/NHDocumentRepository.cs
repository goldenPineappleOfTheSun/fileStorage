﻿using Goldenpineappleofthesun.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goldenpineappleofthesun.Database.Repositories
{
    public class NHDocumentRepository : NHRepository<DocumentItem>
    {

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
            var session = NHHelper.GetCurrentSession();
            var result = session
                .CreateSQLQuery("EXEC CreateDocument  @Name=:Name, @Date=:Date, @Author=:Author, @FileName=:FileName")
                .SetParameter("Name", item.Name)
                .SetParameter("Date", item.CreationDate)
                .SetParameter("Author", item.Author.Id)
                .SetParameter("FileName", item.FileName)
                .ExecuteUpdate();
        }

        public void MarkAsMissed(long id)
        {
            var doc = Find(id);
            if (doc != null)
            {
                doc.Status = DocumentStatus.Missed;
                Save(doc);
            }
        }
    }
}
