using HW_ProfileBook.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HW_ProfileBook.Services.Validators
{
    public static class Validator
    {
        #region --- Public Property ---

        public static string GetError { get; private set; }

        #endregion

        public static bool PasswordValid(string password, string confirmPassword)
        {
            if (!password.Any(char.IsLower) 
                || !password.Any(char.IsUpper) 
                || !password.Any(char.IsDigit))
            {
                GetError = GetErrorText(EntryErrors.PasswordNotValid);
                return false;
            }
            if (!password.Equals(confirmPassword, StringComparison.OrdinalIgnoreCase))
            {
                GetError = GetErrorText(EntryErrors.PasswordDoesNotMatch);
                return false;
            }
            return true;
        }

        public static bool LoginValid(string login)
        {
            if (char.IsDigit(login, 0))
            {
                GetError = GetErrorText(EntryErrors.LoginStartsWithNumbers);
                return false;
            }
            if (login.Length < 4 || login.Length > 16)
            {
                GetError = GetErrorText(EntryErrors.LoginShortOrLoginLong);
                return false;
            }

            return true; ;
        }

        #region --- Private Helpers ---

        private static string GetErrorText(EntryErrors entryErrors)
        {
            switch (entryErrors)
            {
                case EntryErrors.LoginShortOrLoginLong:
                    { return Resource.Resource.Login_must_be_at_least_4_and_no_more_than_16_characters_; }

                case EntryErrors.LoginStartsWithNumbers:
                    { return Resource.Resource.Login_should_not_start_with_numbers_; }

                case EntryErrors.PasswordDoesNotMatch:
                    { return  Resource.Resource.The_values_in_the_password_and_confirm_password_fields_must_match_; }

                case EntryErrors.PasswordNotValid:
                    { return Resource.Resource.Password_must_contain_at_least_one_uppercase_letter__one_lowercase_letter_and_one_number_; }

                default: { return string.Empty; }
            }
        }

        #endregion
    }
}
