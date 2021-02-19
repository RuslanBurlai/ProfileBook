using System;
using System.Collections.Generic;
using System.Text;

namespace HW_ProfileBook.Services.Validators
{
    public interface IPasswordValidators
    {
        bool PasswordValid(string password);
        bool PasswordConfirm(string password, string confirmPassword);
    }
}
