using HW_ProfileBook.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HW_ProfileBook.Repository
{
    public interface IProfilesRepo
    {
        IEnumerable<Profile> GetProfiles(int id);
        //Task<Profile> GetProfile(int id);
        void AddProfile(Profile profile);
        void UpdateProfile(Profile profile);
        void DeleteProfile(Profile profile);
    }
}
