using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Goldenpineappleofthesun.Database.Models;
using Goldenpineappleofthesun.Database.Repositories;

namespace Goldenpineappleofthesun.MVC
{
    public class DBHelper
    {
        private static NHUserRepository Users = new NHUserRepository();
        private static NHDocumentRepository Documents = new NHDocumentRepository();
        private static NHRoleRepository Roles = new NHRoleRepository();
        private static NHSampleRepository Samples = new NHSampleRepository();

        public DBHelper()
        {

        }

        #region User

        // TODO: закешить юзера
        public static UserItem GetUserByLogin(string login)
        {
            return Users.GetByLogin(login);
        }

        /// <summary>
        /// Добавить пользователя
        /// </summary>
        /// <param name="user"></param>
        public static void AddUser(string login, string pass, string name, RoleItem role)
        {
            var user = new UserItem();
            user.Id = 0;
            user.Login = login;
            user.Password = pass;
            user.Name = name;
            user.Role = role;

            AddUser(user);
        }
        
        /// <summary>
        /// Добавить пользователя
        /// </summary>
        /// <param name="user"></param>
        public static void AddUser(string login, string pass, string name, string role)
        {
            // TODO: Check
            var user = new UserItem();
            user.Id = 0;
            user.Login = login;
            user.Password = pass;
            user.Name = name;
            user.Role = DBHelper.GetRoleByName(role);

            AddUser(user);
        }

        /// <summary>
        /// Добавить пользователя
        /// </summary>
        /// <param name="user"></param>
        public static void AddUser(UserItem user)
        {
            Users.Save(user);
        }

        public static bool CheckUser(string login, string pass)
        {
            return DBHelper.Users.Check(login, pass);
        }

        #endregion

        #region Document

        /// <summary>
        /// Добавить пользователя
        /// </summary>
        /// <param name="user"></param>
        public static void AddDocument(string name, string path, UserItem user)
        {
            var doc = new DocumentItem();
            doc.Id = 0;
            doc.Name = name;
            doc.FileName = path;
            doc.Author = user;
            doc.CreationDate = DateTime.Now;

            AddDocument(doc);
        }

        /// <summary>
        /// Добавить пользователя
        /// </summary>
        /// <param name="user"></param>
        public static void AddDocument(string name, string path, string user)
        {
            var doc = new DocumentItem();
            doc.Id = 0;
            doc.Name = name;
            doc.FileName = path;
            doc.Author = DBHelper.GetUserByLogin(user);

            AddDocument(doc);
        }

        /// <summary>
        /// Добавить пользователя
        /// </summary>
        /// <param name="doc"></param>
        public static void AddDocument(DocumentItem doc)
        {
            Documents.Save(doc);
        }

        /// <summary>
        /// получить документ по ид
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static DocumentItem GetDocument(long id)
        {
            return Documents.Find(id);
        }

        /// <summary>
        /// получить список документов пользователя
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static IEnumerable<DocumentItem> GetAllUserDocuments(UserItem user)
        {
            return Documents.GetAllUserDocuments(user);
        }

        /// <summary>
        /// Удалить документ
        /// </summary>
        /// <param name="dov"></param>
        public static void DeleteDocument(DocumentItem doc)
        {
            DeleteDocument(doc.Id);
        }

        /// <summary>
        /// Удалить документ
        /// </summary>
        /// <param name="id"></param>
        public static void DeleteDocument(long id)
        {
            Documents.Delete(id);
        }

        /// <summary>
        /// Получить все документы
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<DocumentItem> GetAllDocuments()
        {
            return Documents.GetAll();
        }

        /// <summary>
        /// Получить все документы пользователей из списка
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<DocumentItem> GetAllDocumentsOfUsers(IEnumerable<string> users)
        {
            return Documents.GetAllDocumentsOfUsers(users);
        }

        /// <summary>
        /// Получить все документы пользователей из списка
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<DocumentItem> GetAllDocumentsOfUsers(IEnumerable<UserItem> users)
        {
            return Documents.GetAllDocumentsOfUsers(users);
        }

        /// <summary>
        /// Найти документ по автору и названию
        /// </summary>
        /// <param name="login"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static DocumentItem GetUserDocument(string login, string name)
        {
            return Documents.GetUserDocument(DBHelper.GetUserByLogin(login), name);
        }


        /// <summary>
        /// Найти документ по автору и названию
        /// </summary>
        /// <param name="author"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        internal static object GetUserDocument(UserItem author, string name)
        {
            return Documents.GetUserDocument(author, name);
        }

        /// <summary>
        /// назначить документу статус "Missed"
        /// </summary>
        /// <param name="doc"></param>
        public static void MarkDocumentAsMissed(DocumentItem doc)
        {
            Documents.MarkAs(doc.Id, DocumentStatus.Missed);
        }

        /// <summary>
        /// назначить документу статус "Missed"
        /// </summary>
        /// <param name="doc"></param>
        public static void MarkDocumentAsMissed(long id)
        {
            Documents.MarkAs(id, DocumentStatus.Missed);
        }

        /// <summary>
        /// назначить документу статус "Normal"
        /// </summary>
        /// <param name="doc"></param>
        public static void MarkDocumentAsNormal(DocumentItem doc)
        {
            Documents.MarkAs(doc.Id, DocumentStatus.Normal);
        }

        /// <summary>
        /// назначить документу статус "Normal"
        /// </summary>
        /// <param name="doc"></param>
        public static void MarkDocumentAsNormal(long id)
        {
            Documents.MarkAs(id, DocumentStatus.Normal);
        }

        #endregion

        #region Role

        public static RoleItem GetRoleByName(string name)
        {
            return Roles.GetByName(name);
        }

        #endregion

        #region Samples

        /// <summary>
        /// Добавить образец
        /// </summary>
        /// <param name="user"></param>
        public static void AddSample(string title, string path)
        {
            var sample = new SampleItem();
            sample.Id = 0;
            sample.Title = title;
            sample.RelPath = path;

            Samples.Save(sample);
        }

        /// <summary>
        /// Добавить образец
        /// </summary>
        /// <param name="user"></param>
        public static void AddSample(SampleItem sample)
        {
            Samples.Save(sample);
        }

        /// <summary>
        /// Удалить образец
        /// </summary>
        /// <param name="sample"></param>
        public static void DeleteSample(SampleItem sample)
        {
            DeleteSample(sample.Id);
        }


        /// <summary>
        /// Удалить образец
        /// </summary>
        /// <param name="id"></param>
        public static void DeleteSample(long id)
        {
            Samples.Delete(id);
        }

        /// <summary>
        /// Получить все образцы
        /// </summary>
        /// <param name="user"></param>
        public static IEnumerable<SampleItem> GetAllSamples()
        {
            return Samples.GetAll();
        }

        /// <summary>
        /// Получить образец по ид
        /// </summary>
        /// <param name="user"></param>
        public static SampleItem GetSample(long id)
        {
            return Samples.Find(id);
        }

        /// <summary>
        /// Получить образец по переданному относительному пути
        /// </summary>
        /// <param name="user"></param>
        public static SampleItem GetSampleByPath(string path)
        {
            return Samples.GetByPath(path);
        }

        #endregion
    }
}