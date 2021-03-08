using HW_ProfileBook.Model;
using HW_ProfileBook.Repository;
using HW_ProfileBook.Services.Settings;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HW_ProfileBook.Services.ProfileService
{
    public class ProfileDataBase : IProfileDataBase
    {
        private readonly ISettingsManager _settings;
        private readonly IRepository _repository;

        public ProfileDataBase(
            ISettingsManager settings,
            IRepository repository)
        {
            _settings = settings;
            _repository = repository;
        }

        public void AddProfile(Profile profile) => _repository.AddItem<Profile>(profile);

        public void DeleteProfile(Profile profile) => _repository.DeleteItem<Profile>(profile);

        public IEnumerable<Profile> GetProfiles() => _repository.GetItems<Profile>().Where(x => x.UserId == _settings.Id);

        public int GetUserId() => _settings.Id;
    }
}
