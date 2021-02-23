using System;
using System.Collections.Generic;
using System.Text;

namespace HW_ProfileBook.Services.Validators
{
    public static class CheckEntry
    {
        public static bool EntryIsEmpty(params string[] entryInput)
        {
            var count = 0;
            foreach (var item in entryInput)
            {
                if (!string.IsNullOrWhiteSpace(item))
                    count++;
            }
            return count == entryInput.Length;
        }

        public static string ResetEntry()
        {
            return string.Empty;
        }
    }
}
