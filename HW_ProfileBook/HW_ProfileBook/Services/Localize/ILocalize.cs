using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace HW_ProfileBook.Services.Localize
{
    public interface ILocalize
    {
        void SetCurrentCultureInfo(string language);
        void GetCurrentCultureInfo();
    }
}
