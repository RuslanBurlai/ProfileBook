using HW_ProfileBook.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HW_ProfileBook.Services.ProfileService
{
    public interface IProfileSort
    {
        IEnumerable<Profile> SortProfilesByName();
        IEnumerable<Profile> SortProfilesByNickName();
        IEnumerable<Profile> SortProfilesByDate();
    }
}
