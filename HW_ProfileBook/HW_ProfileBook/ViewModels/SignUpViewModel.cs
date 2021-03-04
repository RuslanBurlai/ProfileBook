using Prism.Commands;
using Prism.Navigation;
using HW_ProfileBook.Services.Validators;
using System;
using HW_ProfileBook.Views;
using Prism.Services;
using HW_ProfileBook.Model;
using HW_ProfileBook.Repository;
using HW_ProfileBook.Services.Authentication;

namespace HW_ProfileBook.ViewModels
{
    public class SignUpViewModel : ViewModelBase
    {
        private IPageDialogService _pageDialogService;
        private IRepository _repository;
        private IAuthentication _authentication;

        public SignUpViewModel(
            INavigationService navigationService,
            IPageDialogService pageDialogService,
            IRepository repository,
            IAuthentication authentication)
            : base(navigationService)
        {
            Title = "Users SignUp";
            _pageDialogService = pageDialogService;
            _repository = repository;
            _authentication = authentication;
        }

        #region --- Public Properties ---

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
            return EntryHelper.EntryIsEmpty(_userLogin, _userPassword, _confirmUserPassword);
        }

        private void ExecuteNavigateToSignInView(string parameter)
        {
            if (Validator.LoginValid(_userLogin))
            {
                if (Validator.PasswordValid(_userPassword, _confirmUserPassword))
                {
                    User user = new User()
                    {
                        Login = _userLogin,
                        Password = _userPassword
                    };

                    if (!_authentication.GetSameUser(user.Login))
                    {
                        _repository.AddItem(user);
                        var login = new NavigationParameters
                        {
                            { nameof(SignUp), parameter }
                        };
                        NavigationService.NavigateAsync($"{nameof(SignIn)}", login);
                    }
                    else
                    {
                        _pageDialogService.DisplayAlertAsync("Login error", "This login already taken.", "ok");
                    }
                }
                else
                {
                    _pageDialogService.DisplayAlertAsync("Password is not valid", Validator.GetError, "ok");
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
