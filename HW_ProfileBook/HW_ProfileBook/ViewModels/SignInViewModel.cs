﻿using Prism.Commands;
using Prism.Navigation;
using System;
using HW_ProfileBook.Services.Validators;
using HW_ProfileBook.Services.Autorization;
using Prism.Services;
using HW_ProfileBook.Views;
using Xamarin.Forms;
using HW_ProfileBook.Repository;

namespace HW_ProfileBook.ViewModels
{
    public class SignInViewModel : ViewModelBase
    {
        private ILoginValidators _loginValidators;
        private IPasswordValidators _passwordValidators;
        private IAutorithation _autorithation;
        private IPageDialogService _dialogService;
        private IUserRepo _userRepo;

        public SignInViewModel(
           INavigationService navigationService,
           ILoginValidators loginValidators,
           IPasswordValidators passwordValidators,
           IAutorithation autorithation,
           IPageDialogService dialogService,
           IUserRepo userRepo)
           : base(navigationService)
        {
            Title = "Users SignIn";
            _loginValidators = loginValidators;
            _passwordValidators = passwordValidators;
            _autorithation = autorithation;
            _dialogService = dialogService;
            _userRepo = userRepo;
        }

        private string _userLogin;
        public string UserLogin
        {
            get { return _userLogin; }
            set { SetProperty(ref _userLogin, value); }
        }

        private string _userPassword;
        public string UserPassword
        {
            get { return _userPassword; }
            set { SetProperty(ref _userPassword, value); }
        }

        public DelegateCommand _navigateToMainList;
        public DelegateCommand NavigateToMainList =>
            _navigateToMainList ?? (_navigateToMainList = new DelegateCommand(ExecuteNavigateToMainList, CanExecuteNavigateToMainListCommand)
            .ObservesProperty<String>(() => UserPassword)
            .ObservesProperty<String>(() => UserLogin));

        private bool CanExecuteNavigateToMainListCommand()
        {
            return CheckEntry.EntryIsEmpty(_userLogin, _userPassword);
        }

        private void ExecuteNavigateToMainList()
        {
            if (_userRepo.GetUserId(_userLogin, _userPassword) != null)
            {
                var i = _userRepo.GetUserId(_userLogin, _userPassword);
                NavigationService.NavigateAsync($"/{nameof(NavigationPage)}/{nameof(MainList)}");

            }
            else
            {
                _dialogService.DisplayAlertAsync("Error", "Invalid login or password!", "OK");
                UserPassword = CheckEntry.ResetEntry();
            }
        }

        private DelegateCommand _navigateToSignUpView;
        public DelegateCommand NavigateToSingUpView =>
            _navigateToSignUpView ?? (_navigateToSignUpView = new DelegateCommand(ExecuteNavigateToSingUpView));

        void ExecuteNavigateToSingUpView()
        {
            NavigationService.NavigateAsync($"{nameof(SignUp)}");
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            UserLogin = parameters.GetValue<string>("loginFromSignUpView");
        }

        public override void OnNavigatedFrom(INavigationParameters parameters)
        {
            UserPassword = CheckEntry.ResetEntry();
        }
    }
}
