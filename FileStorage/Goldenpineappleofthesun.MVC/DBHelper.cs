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

        public DBHelper()
        {

        }

        #region User

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
        public static void MarkDocumentAsMissing(DocumentItem doc)
        {
            Documents.MarkAsMissed(doc.Id);
        }

        /// <summary>
        /// назначить документу статус "Missed"
        /// </summary>
        /// <param name="doc"></param>
        public static void MarkDocumentAsMissing(long id)
        {
            Documents.MarkAsMissed(id);
        }

        #endregion

        #region Role

        public static RoleItem GetRoleByName(string name)
        {
            return Roles.GetByName(name);
        }

        #endregion
    }
}