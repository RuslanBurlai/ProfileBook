﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HW_ProfileBook.Services.Validators
{
    public class CheckEntry : IEmptyEnrty
    {
        public bool EntryIsEmpty(params string[] entryInput)
        {
            var count = 0;
            foreach (var item in entryInput)
            {
                if (!string.IsNullOrWhiteSpace(item))
                    count++;
            }
            return count == entryInput.Length;
        }

        public void ResetEntry(params string[] entryInput)
        {
            for (int i = 0; i < entryInput.Length; i++)
            {
                entryInput[i] = string.Empty;
            }
        }
    }
}