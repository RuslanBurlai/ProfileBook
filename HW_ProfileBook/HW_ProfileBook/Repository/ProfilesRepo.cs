using HW_ProfileBook.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace HW_ProfileBook.Repository
{
    public class ProfilesRepo : IProfilesRepo
    {
        private SQLiteConnection _connection;
        public ProfilesRepo(IConnectionSQLiteDb db)
        {
            _connection = db.GetProfileConnection();
            _connection.CreateTable<Profile>();
        }

        public void AddProfile(Profile profile)
        {
            if (profile.Id != 0)
            {
                _connection.Update(profile);
                //_connection.Insert(profile);
            }
            else
                _connection.Insert(profile);

        }

        public void DeleteProfile(Profile profile) => _connection.Delete(profile);

        public IEnumerable<Profile> GetProfiles(int id) => _connection.Table<Profile>().Where(p => p.UserId == id).ToList();

        public void UpdateProfile(Profile profile) => _connection.Update(profile);
    }
}
