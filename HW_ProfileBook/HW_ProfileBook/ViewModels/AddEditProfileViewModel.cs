using HW_ProfileBook.Model;
using HW_ProfileBook.Repository;
using HW_ProfileBook.Services.Settings;
using HW_ProfileBook.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HW_ProfileBook.ViewModels
{
    public class AddEditProfileViewModel : ViewModelBase
    {
        private IConnectionSQLiteDb _connectionSQLiteDb;
        private IProfilesRepo _profilesRepo;
        private ISettingsManager _settingsManager;

        public AddEditProfileViewModel(
            INavigationService navigationService,
            IConnectionSQLiteDb connectionSQLiteDb,
            IProfilesRepo profilesRepo,
            ISettingsManager settingsManager) : 
            base(navigationService)
        {
            Title = "Add Profile";
            _connectionSQLiteDb = connectionSQLiteDb;
            _profilesRepo = profilesRepo;
            _settingsManager = settingsManager;
        }

        #region --- Property ---

        private string _profileImage;
        public string ProfileImage
        {
            get { return _profileImage; }
            set { SetProperty(ref _profileImage, value); }
        }

        private string _nickName;
        public string NickName
        {
            get { return _nickName; }
            set { SetProperty(ref _nickName, value); }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            set { SetProperty(ref _description, value); }
        }

        private DelegateCommand _saveProfile;
        public DelegateCommand SaveProfile =>
            _saveProfile ?? (_saveProfile = new DelegateCommand(ExecuteSaveProfile));

        #endregion

        #region --- Private Helpers ---

        private void ExecuteSaveProfile()
        {
            var newProfile = CreateProfile(_settingsManager.Id, _name, _nickName, _description, _profileImage);
            _profilesRepo.AddProfile(newProfile);
            IEnumerable<Profile> p = _profilesRepo.GetProfiles(_settingsManager.Id);
            NavigationService.GoBackAsync();
        }

        private Profile CreateProfile(int userId, string name, string nickName, string description, string profImage)
        {
            var newProfile = new Profile
            {
                //ProfileImage = ""
                UserId = userId,
                NickNameLabel = nickName,
                NameLabel = name,
                DateLabel = DateTime.Now,
                Description = description
            };
            return newProfile;
        }

        #endregion
    }
}
