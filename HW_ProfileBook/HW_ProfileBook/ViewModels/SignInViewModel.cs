using Prism.Commands;
using Prism.Navigation;
using System;
using HW_ProfileBook.Services.Validators;
using HW_ProfileBook.Services.Autorization;
using Prism.Services;

namespace HW_ProfileBook.ViewModels
{
    public class SignInViewModel : ViewModelBase
    {
        private ILoginValidators _loginValidators;
        private IPasswordValidators _passwordValidators;
        private IAutorithation _autorithation;
        private IPageDialogService _dialogService;


        public SignInViewModel(
           INavigationService navigationService,
           ILoginValidators loginValidators,
           IPasswordValidators passwordValidators,
           IAutorithation autorithation,
           IPageDialogService dialogService)
           : base(navigationService)
        {
            Title = "Users SignIn";
            _loginValidators = loginValidators;
            _passwordValidators = passwordValidators;
            _autorithation = autorithation;
            _dialogService = dialogService;
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

        private bool _isEnabled;
        public bool IsEnabled
        {
            get { return _isEnabled; }
            set { SetProperty(ref _isEnabled, value); }
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
            if (_autorithation.CheckLoginPassword(_userLogin, _userPassword))
                NavigationService.NavigateAsync("/NavigationPage/MainList");
            else
            {
                _dialogService.DisplayAlertAsync("Error", "Invalid login or password!", "OK");
                CheckEntry.ResetEntry(UserPassword);
            }
        }

        private DelegateCommand _navigateToSignUpView;
        public DelegateCommand NavigateToSingUpView =>
            _navigateToSignUpView ?? (_navigateToSignUpView = new DelegateCommand(ExecuteNavigateToSingUpView));

        void ExecuteNavigateToSingUpView()
        {
            NavigationService.NavigateAsync("SignUp");
        }
    }
}
