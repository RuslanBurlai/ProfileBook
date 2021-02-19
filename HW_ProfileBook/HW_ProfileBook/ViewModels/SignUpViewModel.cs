using Prism.Commands;
using Prism.Navigation;
using HW_ProfileBook.Services.Validators;

namespace HW_ProfileBook.ViewModels
{
    public class SignUpViewModel : ViewModelBase
    {
        private ILoginValidators _loginValidators;
        private IPasswordValidators _passwordValidators;
        private IEmptyEnrty _emptyEnrty;
        public SignUpViewModel(
            INavigationService navigationService,
            ILoginValidators loginValidators,
            IPasswordValidators passwordValidators,
            IEmptyEnrty emptyEnrty)
            : base(navigationService)
        {
            Title = "Users SignUp";
            _loginValidators = loginValidators;
            _passwordValidators = passwordValidators;
            _emptyEnrty = emptyEnrty;
        }

        private string _userLogin;
        public string UserLogin
        {
            get { return _userLogin; }
            set
            {
                SetProperty(ref _userLogin, value);
                _emptyEnrty.EntryIsEmpty(_userLogin, _userPassword, _confirmUserPassword);
            }
        }

        private string _userPassword;
        public string UserPassword
        {
            get { return _userPassword; }
            set
            {
                SetProperty(ref _userPassword, value);
                IsEnabled = _emptyEnrty.EntryIsEmpty(_userLogin, _userPassword, _confirmUserPassword);
            }
        }

        private string _confirmUserPassword;
        public string ConfirmUserPassword
        {
            get { return _confirmUserPassword; }
            set
            {
                SetProperty(ref _confirmUserPassword, value);
                IsEnabled = _emptyEnrty.EntryIsEmpty(_userLogin, _userPassword, _confirmUserPassword);
            }
        }

        private bool _isEnabled;
        public bool IsEnabled
        {
            get { return _isEnabled; }
            set { SetProperty(ref _isEnabled, value); }
        }

        private DelegateCommand _navigateToSignInView;
        public DelegateCommand NavigateToSignInView =>
            _navigateToSignInView ?? (_navigateToSignInView = new DelegateCommand(ExecuteNavigateToSignInView));

        void ExecuteNavigateToSignInView()
        {

        }
    }
}
