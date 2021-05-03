using System;
using System.Collections.Generic;
using System.Text;

namespace HW_ProfileBook.Services.Validators
{
    public static class EntryHelper
    {
        public static bool EntryIsEmpty(params string[] entrysInput)
        {
            var count = 0;
            foreach (var inputText in entrysInput)
            {
                if (!string.IsNullOrWhiteSpace(inputText))
                    count++;
            }
            return count == entrysInput.Length;
        }

        public static string ResetEntry()
        {
            return string.Empty;
        }
    }
}
