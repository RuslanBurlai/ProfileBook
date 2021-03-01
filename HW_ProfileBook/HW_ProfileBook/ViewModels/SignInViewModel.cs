using Prism.Commands;
using Prism.Navigation;
using System;
using HW_ProfileBook.Services.Validators;
using HW_ProfileBook.Services.Autorization;
using Prism.Services;
using HW_ProfileBook.Views;
using Xamarin.Forms;
using HW_ProfileBook.Repository;
using HW_ProfileBook.Model;
using System.Collections.Generic;
using HW_ProfileBook.Services.Settings;

namespace HW_ProfileBook.ViewModels
{
    public class SignInViewModel : ViewModelBase
    {
        private IAutorithation _autorithation;
        private IPageDialogService _dialogService;
        //private IUserRepo _userRepo;
        private ISettingsManager _settingsManager;
        private IRepository _repository;

        public SignInViewModel(
           INavigationService navigationService,
           IAutorithation autorithation,
           IPageDialogService dialogService,
           //IUserRepo userRepo,
           IRepository repository,
           ISettingsManager settingsManager)
           : base(navigationService)
        {
            Title = "Users SignIn";
            _dialogService = dialogService;
            //_userRepo = userRepo;
            _settingsManager = settingsManager;
            _autorithation = autorithation;
            _repository = repository;
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

        public DelegateCommand _navigateToMainList;
        public DelegateCommand NavigateToMainList =>
            _navigateToMainList ?? (_navigateToMainList = new DelegateCommand(ExecuteNavigateToMainList, CanExecuteNavigateToMainListCommand)
            .ObservesProperty<String>(() => UserPassword)
            .ObservesProperty<String>(() => UserLogin));

        private DelegateCommand _navigateToSignUpView;
        public DelegateCommand NavigateToSingUpView =>
            _navigateToSignUpView ?? (_navigateToSignUpView = new DelegateCommand(ExecuteNavigateToSingUpView));

        #endregion

        #region --- Private Helpers ---

        private bool CanExecuteNavigateToMainListCommand()
        {
            return EntryHelper.EntryIsEmpty(_userLogin, _userPassword);
        }

        private void ExecuteNavigateToMainList()
        {
            //_settingsManager.Id = _authentication.GetUserId(_userLogin, _userPassword);
            _settingsManager.Id = _repository.GetId<User>(_userLogin, _userPassword);
            if (_autorithation.IsAutorized())
            {
                NavigationService.NavigateAsync("/NavigationPage/MainList");
            }
            else
            {
                _dialogService.DisplayAlertAsync("Error", "Invalid login or password!", "OK");
                UserPassword = EntryHelper.ResetEntry();
            }
        }

        private void ExecuteNavigateToSingUpView()
        {
            NavigationService.NavigateAsync(nameof(SignUp));
        }

        #endregion

        #region --- Overrides ---

        public override void OnNavigatedFrom(INavigationParameters parameters)
        {
            UserPassword = EntryHelper.ResetEntry();
        }

        #endregion
    }
}
