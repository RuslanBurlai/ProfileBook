using System;
using System.Collections.Generic;
using System.Text;

namespace HW_ProfileBook.Services.Settings
{
    public interface ISettingsManager
    {
        int Id { get; set; }
        string SortMethod { get; set; }
    }
}
