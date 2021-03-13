using HW_ProfileBook.Services.Localize;
using HW_ProfileBook.Services.Settings;
using HW_ProfileBook.Services.Theme;
using HW_ProfileBook.Styles;
using Prism.Navigation;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;

namespace HW_ProfileBook.ViewModels
{
    public class SettingsViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private ISettingsManager _settingsManager;
        private ILocalize _localize;
        private ILoadAppereance _loadAppereance;

        public SettingsViewModel(
            INavigationService navigationService,
            ISettingsManager settingsManager,
            ILocalize localize,
            ILoadAppereance loadAppereance) :
            base(navigationService)
        {
            Title = "Settings";
            _settingsManager = settingsManager;
            _localize = localize;
            _loadAppereance = loadAppereance;
        }

        #region --- Public Properties ---

        private object _selectedValue;
        public object SelectedValue
        {
            get { return _selectedValue; }
            set { SetProperty(ref _selectedValue, value); }
        }

        private bool _isSortByName;
        public bool IsSortByName
        {
            get { return _settingsManager.SortMethod == "Name"; }
            set { SetProperty(ref _isSortByName, value); }
        }

        private bool _isSortByNickName;
        public bool IsSortByNickName
        {
            get { return _settingsManager.SortMethod == "NickName"; }
            set { SetProperty(ref _isSortByNickName, value); }
        }

        private bool _isSortByDate;
        public bool IsSortByDate
        {
            get { return _settingsManager.SortMethod == "Date"; }
            set { SetProperty(ref _isSortByDate, value); }
        }

        private bool _isDarkTheme;
        public bool IsDarkTheme
        {
            get { return _settingsManager.Appearance == (nameof(DarkTheme)); }
            set { SetProperty(ref _isDarkTheme, value); }
        }

        private bool _isRuLanguageName;
        public bool IsRuLanguage
        {
            get { return _settingsManager.Language == "ru"; }
            set { SetProperty(ref _isRuLanguageName, value); }
        }

        private bool _isEnLanguage;
        public bool IsEnLanguage
        {
            get { return _settingsManager.Language == "en"; }
            set { SetProperty(ref _isEnLanguage, value); }
        }
        #endregion

        #region --- Overrides ---

        protected override void OnPropertyChanged(PropertyChangedEventArgs args)
        {
            switch (args.PropertyName)
            {
                case nameof(SelectedValue):
                    { _settingsManager.SortMethod = SelectedValue as string; break; }

                case nameof(IsDarkTheme):
                    {
                        ICollection<ResourceDictionary> mergeDictionaries = Application.Current.Resources.MergedDictionaries;
                        mergeDictionaries.Clear();
                        if (_isDarkTheme)
                        {
                            _settingsManager.Appearance = (nameof(DarkTheme));
                            mergeDictionaries.Add(new DarkTheme());
                        }
                        else
                        {
                            _settingsManager.Appearance = (nameof(LightTheme));
                            mergeDictionaries.Add(new LightTheme());
                        }
                        break;
                    }

                case nameof(IsRuLanguage):
                    { _localize.SetCurrentCultureInfo("ru"); }
                    break;
                case nameof(IsEnLanguage):
                    { _localize.SetCurrentCultureInfo("en"); }
                    break;
            }
        }

        #endregion
    }
}
