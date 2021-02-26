using System;
using System.Collections.Generic;
using System.Text;

namespace HW_ProfileBook.Services.Autorization
{
    public interface IAutorithation
    {
        bool IsAutorized(int id);
        int LogOut();
    }
}
