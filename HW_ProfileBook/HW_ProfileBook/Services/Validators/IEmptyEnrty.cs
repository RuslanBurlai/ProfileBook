using System;
using System.Collections.Generic;
using System.Text;

namespace HW_ProfileBook.Services.Validators
{
    public interface IEmptyEnrty
    {
        bool EntryIsEmpty(params string[] entryInput);
        void ResetEntry(params string[] entryInput);
    }
}
