using HW_ProfileBook.Model;
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

        public MainListViewModel(
            INavigationService navigationService) :
            base(navigationService)
        {
            Title = "Main List";
        }

        private DelegateCommand _logOut;
        public DelegateCommand LogOut =>
            _logOut ?? (_logOut = new DelegateCommand(ExecuteLogOut));

        private DelegateCommand _navigateToAddEditProfile;
        public DelegateCommand NavigateToAddEditProfile =>
            _navigateToAddEditProfile ?? (_navigateToAddEditProfile = new DelegateCommand(ExecuteNavigateToAddEditProfile));

        void ExecuteNavigateToAddEditProfile()
        {
            NavigationService.NavigateAsync("AddEditProfile");
        }
        void ExecuteLogOut()
        {
            NavigationService.NavigateAsync($"/{nameof(NavigationPage)}/{nameof(SignIn)}");
        }
        private void ExecuteEditProfile(object parameter)
        {
        }

        private void ExecuteDeleteProfile(object parameter)
        {
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            Profile p = new Profile()
            {
                NameLabel = "asdfg",
                NickNameLabel = "asdfg",
                DateLabel = DateTime.Now
            };
            List<Profile> lp = new List<Profile>();
            lp.Add(p);
            Profiles = lp;
        }

        public override void OnNavigatedFrom(INavigationParameters parameters)
        {
        }
    }
}
