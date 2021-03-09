using System;
using System.Collections.Generic;
using System.Text;
using HW_ProfileBook;

namespace HW_ProfileBook.Services.Settings
{
    public interface ISettingsManager
    {
        int Id { get; set; }
        string SortMethod { get; set; }
        string Appearance { get; set; }
    }
}
