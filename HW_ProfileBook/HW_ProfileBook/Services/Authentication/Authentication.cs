using HW_ProfileBook.Model;
using HW_ProfileBook.Repository;
using SQLite;
using System.Linq;

namespace HW_ProfileBook.Services.Authentication
{
    public class Authentication : IAuthentication
    {
        IRepository _repository;

        public Authentication(IRepository repository)
        {
            _repository = repository;
        }

        public bool GetSameUser(string login)
        {
            var usersList = _repository.GetItems<User>();
            foreach (var user in usersList)
            {
                if (user.Login == login)
                    return true;
            }
            return false;
        }

        public int GetUserId(string login, string password)
        {
            int id = 0;
            var list = _repository.GetItems<User>()
                .Where(user => user.Login == login && user.Password == password)
                .Select(user => user.Id);
            foreach (var item in list)
                id = item;
            return id;
        }
    }
}
