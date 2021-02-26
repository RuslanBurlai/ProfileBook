using HW_ProfileBook.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HW_ProfileBook.Repository
{
    public class UserRepo : IUserRepo
    {
        private SQLiteConnection _connection;
        public UserRepo(IConnectionSQLiteDb db)
        {
            _connection = db.GetUserConnection();
            _connection.CreateTable<User>();
        }

        public void AddContact(User user) => _connection.Insert(user);

        public bool GetSameUser(string login)
        {
            var usersList = GetUsers();
            foreach (var user in usersList)
            {
                if (user.Login == login)
                    return true;
            }
            return false;
        } 

        public IEnumerable<User> GetUsers() => _connection.Table<User>().ToList();

        public int GetUserId(string login, string password)
        {
            int id = 0;
            var list = _connection.Table<User>()
                .Where(user => user.Login == login && user.Password == password)
                .Select(user => user.Id);
            foreach (var item in list)
                id = item;
            return id;
        }

        //public bool GetUser(string login, string password) => (_connection.Table<User>().Where(u => u.Login == login && u.Password == password).Count() == 1);
    }
}
