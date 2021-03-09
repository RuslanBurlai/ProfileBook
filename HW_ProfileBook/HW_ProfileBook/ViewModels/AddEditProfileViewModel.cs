using HW_ProfileBook.Dialogs;
using HW_ProfileBook.Model;
using HW_ProfileBook.Repository;
using HW_ProfileBook.Services.Authentication;
using HW_ProfileBook.Services.ProfileService;
using HW_ProfileBook.Services.Settings;
using HW_ProfileBook.Services.Validators;
using HW_ProfileBook.Views;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services.Dialogs;
using System;

namespace HW_ProfileBook.ViewModels
{
    public class AddEditProfileViewModel : ViewModelBase
    {
        private IDialogService _dialogService;
        private IProfileDataBase _profileDataBase;

        public AddEditProfileViewModel(
            INavigationService navigationService,
            IProfileDataBase profileDataBase,
            IDialogService dialogService) :
            base(navigationService)
        {
            Title = "Add Profile";
            _profileDataBase = profileDataBase;
            _dialogService = dialogService;
        }

        #region --- Private Fields ---

        private Profile _profile;

        #endregion

        #region --- Public Property ---

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

        #endregion

        #region --- Private Helpers ---

        private void ExecuteChangeImage()
        {
            _dialogService.ShowDialog(nameof(SelectImage), OnDialogClosed);
        }

        private void OnDialogClosed(IDialogResult result)
        {
            if (result.Parameters.ContainsKey(nameof(SelectImage)))
                ProfileImage = result.Parameters.GetValue<string>(nameof(SelectImage));
        }

        private void ExecuteSaveProfile()
        {
            var newProfile = CreateProfile(_profile);
            _profileDataBase.AddProfile(newProfile);
            NavigationService.GoBackAsync(null, false, false);
        }

        private bool CanExecuteSaveProfile()
        {
            return EntryHelper.EntryIsEmpty(_name, _nickName, _description);
        }


        private Profile CreateProfile(Profile profile)
        {
            if (profile == null)
            {
                profile = new Profile
                {
                    ProfileImage = _profileImage,
                    NickNameLabel = _nickName,
                    NameLabel = _name,
                    Description = _description,
                    DateLabel = DateTime.Now,
                    UserId = _profileDataBase.GetUserId()
                };
            }
            else
            {
                profile.ProfileImage = _profileImage;
                profile.NickNameLabel = _nickName;
                profile.NameLabel = _name;
                profile.Description = _description; 
            }
                return profile;
        }

        #endregion

        #region --- Overrides ---

        public override void Initialize(INavigationParameters parameters)
        {
            _profile = parameters.GetValue<Profile>(nameof(AddEditProfile));
            if (_profile != null)
            {
                ProfileImage = _profile.ProfileImage;
                Name = _profile.NameLabel;
                NickName = _profile.NickNameLabel;
                Description = _profile.Description;
            }
            else
                ProfileImage = "pic_profile";
        }

        #endregion
    }
}
