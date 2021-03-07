using HW_ProfileBook.Model;
using HW_ProfileBook.Repository;
using HW_ProfileBook.Services.Autorization;
using HW_ProfileBook.Services.Settings;
using HW_ProfileBook.Views;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace HW_ProfileBook.ViewModels
{
    public class MainListViewModel : ViewModelBase
    {
        private ISettingsManager _settingsManager;
        private IAutorithation _autorithation;
        private IRepository _repository;

        public MainListViewModel(
            INavigationService navigationService,
            ISettingsManager settingsManager,
            IAutorithation autorithation,
            IRepository repository) :
            base(navigationService)
        {
            Title = "Main List";
            _settingsManager = settingsManager;
            _autorithation = autorithation;
            _repository = repository;
        }

        #region --- Public Properties ---

        private IEnumerable<Profile> _profiles;
        public IEnumerable<Profile> Profiles
        {
            get => _profiles;
            set => SetProperty(ref _profiles, value);
        }

        private ObservableCollection<Profile> _profilesO;
        public ObservableCollection<Profile> ProfilesO
        {
            get { return _profilesO; }
            set { SetProperty(ref _profilesO, value); }
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


        private DelegateCommand _settings;
        public DelegateCommand SettingsCommand =>

            _settings ?? (_settings = new DelegateCommand(ExecuteSettings));

        private DelegateCommand<object> _navigateToAddEditProfile;
        public DelegateCommand<object> NavigateToAddEditProfile =>
            _navigateToAddEditProfile ?? (_navigateToAddEditProfile = new DelegateCommand<object>(ExecuteNavigateToAddEditProfile));

        private DelegateCommand<object> _deleteProfile;
        public DelegateCommand<object> DeleteProfile =>
            _deleteProfile ?? (_deleteProfile = new DelegateCommand<object>(ExecuteDeleteProfile));

        private DelegateCommand<object> _editProfile;
        public DelegateCommand<object> EditProfile =>
            _editProfile ?? (_editProfile = new DelegateCommand<object>(ExecuteEditProfile));

        #endregion

        #region --- Private Helpers ---

        private void ExecuteSettings()
        {
            NavigationService.NavigateAsync(nameof(Settings)); 
        }

        private void ExecuteNavigateToAddEditProfile(object parameter)
        {
            NavigationService.NavigateAsync(nameof(AddEditProfile));
        }

        private void ExecuteEditProfile(object parameter)
        {
            var selectedProfile = new NavigationParameters();
            selectedProfile.Add("p", parameter);
            NavigationService.NavigateAsync(nameof(AddEditProfile), selectedProfile);
        }

        private void ExecuteLogout()
        {
            _autorithation.LogOut();
            NavigationService.NavigateAsync($"/{nameof(NavigationPage)}/{nameof(SignIn)}");
        }

        private void ExecuteDeleteProfile(object parameter)
        {
            _repository.DeleteItem<Profile>(parameter as Profile);
            Profiles = _repository.GetItems<Profile>();
        }

        #endregion

        #region --- Overrides ---

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            Profiles = _repository.GetItems<Profile>().Where(x => x.UserId == _settingsManager.Id);
        }

        public override void Initialize(INavigationParameters parameters)
        {
            //Profiles = _repository.GetItems<Profile>().Where(x => x.UserId == _settingsManager.Id);
        }

        #endregion
    }
}