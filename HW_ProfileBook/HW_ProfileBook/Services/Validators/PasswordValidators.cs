using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HW_ProfileBook.Services.Validators
{
    public class PasswordValidators : IPasswordValidators
    {
        public bool PasswordConfirm(string password, string confirmPassword)
        {
            return password.Equals(confirmPassword, StringComparison.OrdinalIgnoreCase);
        }

        public bool PasswordValid(string password)
        {
            return password.Length >= 4 &&
           password.Length <= 16 &&
           password.Any(char.IsLetterOrDigit) &&
           password.Any(char.IsUpper);
        }
    }
}
