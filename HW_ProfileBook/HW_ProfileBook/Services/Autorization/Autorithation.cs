using System;
using System.Collections.Generic;
using System.Text;

namespace HW_ProfileBook.Services.Autorization
{
    public class Autorithation : IAutorithation
    {
        public bool CheckLoginPassword(string login, string password)
        {
            return login == "a" && password == "a";
        }
    }
}
