using System;
using System.Collections.Generic;
using System.Text;

namespace HW_ProfileBook.Services.Validators
{
    public interface IPasswordValidators
    {
        string PasswarodError { get; set; }
        bool PasswordValid(string password, string confirmPassword);
        bool PasswordConfirm(string password, string confirmPassword);
    }
}
