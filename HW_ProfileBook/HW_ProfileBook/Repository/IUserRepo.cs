using HW_ProfileBook.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HW_ProfileBook.Repository
{
    public interface IUserRepo
    {
        IEnumerable<User> GetUsers();
        void AddContact(User contact);
        int GetUserId(string login, string password);
        bool GetSameUser(string login);

    }
}
