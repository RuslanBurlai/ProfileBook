using Prism.Commands;
using Prism.Navigation;
using HW_ProfileBook.Services.Validators;
using System;

namespace HW_ProfileBook.ViewModels
{
    public class SignUpViewModel : ViewModelBase
    {
        private ILoginValidators _loginValidators;
        private IPasswordValidators _passwordValidators;
        public SignUpViewModel(
            INavigationService navigationService,
            ILoginValidators loginValidators,
            IPasswordValidators passwordValidators)
            : base(navigationService)
        {
            Title = "Users SignUp";
            _loginValidators = loginValidators;
            _passwordValidators = passwordValidators;
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

        private string _confirmUserPassword;
        public string ConfirmUserPassword
        {
            get { return _confirmUserPassword; }
            set { SetProperty(ref _confirmUserPassword, value); }
        }

        private bool _isEnabled;
        public bool IsEnabled
        {
            get { return _isEnabled; }
            set { SetProperty(ref _isEnabled, value); }
        }

        private DelegateCommand _navigateToSignInView;
        public DelegateCommand NavigateToSignInView =>
            _navigateToSignInView ?? (_navigateToSignInView = new DelegateCommand(ExecuteNavigateToSignInView, CanExecuteNavigateToSignInView)
            .ObservesProperty<String>(() => UserLogin)
            .ObservesProperty<String>(() => UserPassword)
            .ObservesProperty<String>(() => ConfirmUserPassword));


        private bool CanExecuteNavigateToSignInView()
        {
            return CheckEntry.EntryIsEmpty(_userLogin, _userPassword, _confirmUserPassword);
        }

        void ExecuteNavigateToSignInView()
        {

        }
    }
}
