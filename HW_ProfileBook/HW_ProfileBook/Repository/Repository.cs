using HW_ProfileBook.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HW_ProfileBook.Repository
{
    public class Repository : IRepository
    {
        private Lazy<SQLiteConnection> _database;
        public Repository()
        {
            _database = new Lazy<SQLiteConnection>(() =>
            {
                var dataBaseName = "Profiles.db";
                var documentsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), dataBaseName);
                var dataBase = new SQLiteConnection(documentsPath);

                dataBase.CreateTable<User>();
                dataBase.CreateTable<Profile>();

                return dataBase;
            });
        }

        public void AddItem<T>(T item) where T : IEntityBaseForModel, new()
        {
            if (item.Id != 0)
            {
                _database.Value.Update(item);
            }
            else
                _database.Value.Insert(item);

        }

        public int DeleteItem<T>(T item) where T : IEntityBaseForModel, new()
        {
            return _database.Value.Delete(item);
        }

        public IEnumerable<T> GetItems<T>() where T : IEntityBaseForModel, new()
        {
            return _database.Value.Table<T>();
        }

        public void UpdateItem<T>(T item) where T : IEntityBaseForModel, new()
        {
            throw new NotImplementedException();
        }

        public int GetId<T>(string login, string password) where T : IEntityBaseForModel, new()
        {
            int id = 0;
            var list = GetItems<User>()
                .Where(user => user.Login == login && user.Password == password)
                .Select(user => user.Id);
            foreach (var item in list)
                id = item;
            return id;
        }

        public bool GetSameUser<T>(string login) where T : IEntityBaseForModel, new()
        {
            var usersList = GetItems<User>();
            foreach (var user in usersList)
            {
                if (user.Login == login)
                    return true;
            }
            return false;
        }
    }
}
