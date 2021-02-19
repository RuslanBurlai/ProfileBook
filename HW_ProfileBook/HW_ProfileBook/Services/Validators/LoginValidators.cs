using System;
using System.Collections.Generic;
using System.Text;

namespace HW_ProfileBook.Services.Validators
{
    public class LoginValidators : ILoginValidators
    {
        public bool LoginValid(string login)
        {
            return !(char.IsDigit(login, 0));
        }
    }
}
