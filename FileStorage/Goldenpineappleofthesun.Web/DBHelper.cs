using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Goldenpineappleofthesun.Database.Models;
using Goldenpineappleofthesun.Database.Repositories;

namespace Goldenpineappleofthesun.Web
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
            doc.Author = user;

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

        #endregion

        #region Document

        public static RoleItem GetRoleByName(string name)
        {
            return Roles.GetByName(name);
        }

        #endregion
    }
}