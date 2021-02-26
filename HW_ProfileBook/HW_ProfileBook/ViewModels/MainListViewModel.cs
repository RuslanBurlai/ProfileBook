using HW_ProfileBook.Model;
using HW_ProfileBook.Repository;
using HW_ProfileBook.Services.Autorization;
using HW_ProfileBook.Services.Settings;
using HW_ProfileBook.Views;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace HW_ProfileBook.ViewModels
{
    public class MainListViewModel : ViewModelBase
    {
        private ISettingsManager _settingsManager;
        private IAutorithation _autorithation;
        private IConnectionSQLiteDb _connectionSQLiteDb;
        private IProfilesRepo _profilesRepo;

        public MainListViewModel(
            INavigationService navigationService,
            ISettingsManager settingsManager,
            IAutorithation autorithation,
            IConnectionSQLiteDb connectionSQLiteDb,
            IProfilesRepo profilesRepo) :
            base(navigationService)
        {
            Title = "Main List";
            _settingsManager = settingsManager;
            _autorithation = autorithation;
            _connectionSQLiteDb = connectionSQLiteDb;
            _profilesRepo = profilesRepo;
        }

        #region --- Public Properties ---
        private IEnumerable<Profile> _profiles;
        public IEnumerable<Profile> Profiles
        {
            get => _profiles;
            set => SetProperty(ref _profiles, value);
        }
        private Profile _selectProfiles;
        public Profile SelectProfiles
        {
            get { return _selectProfiles; }
            set { SetProperty(ref _selectProfiles, value); }
        }

        private DelegateCommand _logOut;
        public DelegateCommand LogOut =>
            _logOut ?? (_logOut = new DelegateCommand(ExecuteLogout));


        private DelegateCommand _navigateToAddEditProfile;
        public DelegateCommand NavigateToAddEditProfile =>
            _navigateToAddEditProfile ?? (_navigateToAddEditProfile = new DelegateCommand(ExecuteNavigateToAddEditProfile));

        private DelegateCommand<object> _deleteProfile;
        public DelegateCommand<object> DeleteProfile =>
            _deleteProfile ?? (_deleteProfile = new DelegateCommand<object>(ExecuteDeleteProfile));

        void ExecuteDeleteProfile(object parameter)
        {
            Profile selectedProfile = (Profile)parameter;
            _profilesRepo.DeleteProfile(selectedProfile);
            Profiles = _profilesRepo.GetProfiles(_settingsManager.Id);
        }

        #endregion

        #region --- Private Helpers ---
        private void ExecuteNavigateToAddEditProfile()
        {
            NavigationService.NavigateAsync(nameof(AddEditProfile));
        }

        private void ExecuteEditProfile(object parameter)
        {
            Profile selectedProfile = (Profile)parameter;
            _profilesRepo.DeleteProfile(selectedProfile);
        }

        void ExecuteLogout()
        {
            NavigationService.NavigateAsync("/NavigationPage/SignIn");
        }

        #endregion

        #region --- Overrides ---

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            Profiles = _profilesRepo.GetProfiles(_settingsManager.Id);
        }

        public override void Initialize(INavigationParameters parameters)
        {
            Profiles = _profilesRepo.GetProfiles(_settingsManager.Id);
        }

        #endregion
    }
}
