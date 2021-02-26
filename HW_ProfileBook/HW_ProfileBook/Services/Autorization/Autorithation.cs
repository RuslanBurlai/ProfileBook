using System;
using System.Collections.Generic;
using System.Text;

namespace HW_ProfileBook.Services.Autorization
{
    public class Autorithation : IAutorithation
    {
        public bool IsAutorized(int id) => id != 0;
        public int LogOut() => 0;
    }
}
