using HW_ProfileBook.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HW_ProfileBook.Services.Validators
{
    public static class Validator
    {
        public static string GetError { get; private set; }

        public static bool PasswordValid(string password, string confirmPassword)
        {
            if (password.Length < 4)
            {
                GetError = "Login must be at least 4 characters.";
                return false; 
            }
            if (password.Length > 16)
            {
                GetError = "Login must be more than 16 characters.";
                return false;
            }
            if (!password.Any(char.IsLetterOrDigit))
            {
                GetError = "Password must contain at lowercase letter and number.";
                return false;
            }
            if (!password.Any(char.IsUpper))
            {
                GetError = "Password must contain at uppercase letter";
                return false;
            }
            if(!password.Equals(confirmPassword, StringComparison.OrdinalIgnoreCase))
            {
                GetError = "The values in the password and confirm password fields must match.";
                return false;
            }
            return true;
        }

        public static bool LoginValid(string login)
        {
            return !(char.IsDigit(login, 0));
        }
    }
}
