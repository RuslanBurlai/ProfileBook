using HW_ProfileBook.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HW_ProfileBook.Services.Validators
{
    public class PasswordValidators : IPasswordValidators
    {
        private string _passwarodError;
        public string PasswarodError 
        { 
            get => _passwarodError; 
            set => _passwarodError = value; 
        }

        public bool PasswordConfirm(string password, string confirmPassword)
        {
            return password.Equals(confirmPassword, StringComparison.OrdinalIgnoreCase);
        }

        public bool PasswordValid(string password, string confirmPassword)
        {
            if (password.Length < 4)
            {
                PasswarodError = "Login must be at least 4 characters.";
                return false; 
            }
            if (password.Length > 16)
            {
                PasswarodError = "Login must be more than 16 characters.";
                return false;
            }
            if (!password.Any(char.IsLetterOrDigit))
            {
                PasswarodError = "Password must contain at lowercase letter and number.";
                return false;
            }
            if (!password.Any(char.IsUpper))
            {
                PasswarodError = "Password must contain at uppercase letter";
                return false;
            }
            if(!password.Equals(confirmPassword, StringComparison.OrdinalIgnoreCase))
            {
                PasswarodError = "The values in the password and confirm password fields must match.";
                return false;
            }
            return true;
        }
    }
}
