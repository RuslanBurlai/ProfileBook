using HW_ProfileBook.Model;
using HW_ProfileBook.Services.Settings;
using System;
using System.Collections.Generic;
using System.Text;

namespace HW_ProfileBook.Services.ProfileService
{
    public interface IProfileDataBase
    {
        void AddProfile(Profile profile);
        void DeleteProfile(Profile profile);
        IEnumerable<Profile> GetProfiles();
        int GetUserId();
    }
}
