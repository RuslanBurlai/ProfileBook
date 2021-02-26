using Prism.Commands;
using Prism.Navigation;
using HW_ProfileBook.Services.Validators;
using System;
using HW_ProfileBook.Views;
using Prism.Services;
using HW_ProfileBook.Model;
using HW_ProfileBook.Repository;

namespace HW_ProfileBook.ViewModels
{
    public class SignUpViewModel : ViewModelBase
    {
        private ILoginValidators _loginValidators;
        private IPasswordValidators _passwordValidators;
        private IPageDialogService _pageDialogService;
        private IUserRepo _userRepo;
        private IConnectionSQLiteDb _connectionSQLiteDb;

        public SignUpViewModel(
            INavigationService navigationService,
            ILoginValidators loginValidators,
            IPasswordValidators passwordValidators,
            IPageDialogService pageDialogService,
            IUserRepo userRepo,
            IConnectionSQLiteDb connectionSQLiteDb)
            : base(navigationService)
        {
            Title = "Users SignUp";
            _loginValidators = loginValidators;
            _passwordValidators = passwordValidators;
            _pageDialogService = pageDialogService;
            _userRepo = userRepo;
            _connectionSQLiteDb = connectionSQLiteDb;
        }

        #region --- Properties ---
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

        private DelegateCommand<string> _navigateToSignInView;
        public DelegateCommand<string> NavigateToSignInView =>
            _navigateToSignInView ?? (_navigateToSignInView = new DelegateCommand<string>(ExecuteNavigateToSignInView, CanExecuteNavigateToSignInView)
            .ObservesProperty<String>(() => UserLogin)
            .ObservesProperty<String>(() => UserPassword)
            .ObservesProperty<String>(() => ConfirmUserPassword));

        #endregion

        #region --- Private Helpers ---

        private bool CanExecuteNavigateToSignInView(string parameter)
        {
            return CheckEntry.EntryIsEmpty(_userLogin, _userPassword, _confirmUserPassword);
        }

        private void ExecuteNavigateToSignInView(string parameter)
        {
            if(_loginValidators.LoginValid(_userLogin))
            {
                if (_passwordValidators.PasswordValid(_userPassword, _confirmUserPassword))
                {
                    User user = new User()
                    {
                        Login = _userLogin,
                        Password = _userPassword
                    };

                    if (!_userRepo.GetSameUser(user.Login))
                    {
                        using (_connectionSQLiteDb.GetUserConnection())
                        {
                            _userRepo.AddContact(user);
                        }
                        var login = new NavigationParameters();
                        login.Add("loginFromSignUpView", parameter);
                        NavigationService.NavigateAsync($"{nameof(SignIn)}", login);
                    }
                    else
                    {
                        _pageDialogService.DisplayAlertAsync("Login error", "This login already taken.", "ok");
                    }
                }
                else
                {
                    _pageDialogService.DisplayAlertAsync("Password is not valid", _passwordValidators.PasswarodError, "ok");
                }
            }
            else
            {
                _pageDialogService.DisplayAlertAsync("Login is not valid", "Login should not start with numbers.", "ok");
            }
        }

        #endregion
    }

    //"Password is not valid", "Password be at least 4 and no more than 16 and must contain at least one uppercase letter, one lowercase letter and one number."
}
