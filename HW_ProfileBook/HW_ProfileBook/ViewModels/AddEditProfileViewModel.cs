using HW_ProfileBook.Dialogs;
using HW_ProfileBook.Model;
using HW_ProfileBook.Repository;
using HW_ProfileBook.Services.Settings;
using HW_ProfileBook.Services.Validators;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services.Dialogs;
using System;

namespace HW_ProfileBook.ViewModels
{
    public class AddEditProfileViewModel : ViewModelBase
    {
        private ISettingsManager _settingsManager;
        private IRepository _repository;
        private IDialogService _dialogService;

        public AddEditProfileViewModel(
            INavigationService navigationService,
            ISettingsManager settingsManager,
            IRepository repository,
            IDialogService dialogService) :
            base(navigationService)
        {
            Title = "Add Profile";
            _settingsManager = settingsManager;
            _repository = repository;
            _dialogService = dialogService;
        }

        #region --- Property ---

        private Profile _profile;

        private string _profileImage;
        public string ProfileImage
        {
            get { return _profileImage; }
            set { SetProperty(ref _profileImage, value); }
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
            _saveProfile ?? (_saveProfile = new DelegateCommand(ExecuteSaveProfile, CanExecuteSaveProfile))
            .ObservesProperty<string>(() => NickName)
            .ObservesProperty<string>(() => Name)
            .ObservesProperty<string>(() => Description);

        private DelegateCommand _changeImage;

        public DelegateCommand ChangeImage =>
            _changeImage ?? (_changeImage = new DelegateCommand(ExecuteChangeImage));

        void ExecuteChangeImage()
        {
            _dialogService.ShowDialog(nameof(SelectImage));
        }

        #endregion

        #region --- Private Helpers ---

        private void ExecuteSaveProfile()
        {
            if(_profile == null)
            {
                var newProfile = CreateProfile(_settingsManager.Id, _name, _nickName, _description, _profileImage);

                _repository.AddItem<Profile>(newProfile);
            }  
            else
            {
                var updateProfile = CreateProfile(_settingsManager.Id, _name, _nickName, _description, _profileImage);
                _repository.AddItem(updateProfile);
            }
            NavigationService.GoBackAsync(null, false, false);
        }

        private bool CanExecuteSaveProfile()
        {
            return EntryHelper.EntryIsEmpty(_name, _nickName, _description);
        }

        private Profile CreateProfile(int userId, string name, string nickName, string description, string profImage)
        {
            if(_profile == null)
            {
                var _profile = new Profile
                {
                    //ProfileImage = ""
                    UserId = userId,
                    NickNameLabel = nickName,
                    NameLabel = name,
                    DateLabel = DateTime.Now,
                    Description = description
                };
            }
            else
            {
                _profile.NickNameLabel = NickName;
                _profile.NameLabel = Name;
                _profile.Description = Description;
                _profile.ProfileImage = ProfileImage;
            }
            return _profile;
        }

        #endregion

        #region --- Overrides ---

        public override void Initialize(INavigationParameters parameters)
        {
            var selectedProfile = parameters.GetValue<Profile>("p");
            if (selectedProfile != null)
            {
                _profile = selectedProfile;
                Name = _profile.NameLabel;
                NickName = _profile.NameLabel;
                Description = _profile.Description;
                ProfileImage = _profile.ProfileImage;
            }
        }

        #endregion
    }
}
