using System;
using System.Collections.Generic;
using System.Text;

namespace HW_ProfileBook.Services.Authentication
{
    public interface IAuthentication
    {
        bool GetSameUser(string login);
        int GetUserId(string login, string password);
    }
}
