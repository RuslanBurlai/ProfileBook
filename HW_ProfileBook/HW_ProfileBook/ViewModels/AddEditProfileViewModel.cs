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
        public AddEditProfileViewModel(
            INavigationService navigationService) : 
            base(navigationService)
        {
            Title = "Add Profile";
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

        void ExecuteSaveProfile()
        {
            NavigationService.NavigateAsync(nameof(MainList));
        }
    }
}
