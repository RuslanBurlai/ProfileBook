using HW_ProfileBook.Services.Settings;
using Prism.Navigation;
using System;
using System.ComponentModel;

namespace HW_ProfileBook.ViewModels
{
    public class SettingsViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private ISettingsManager _settingsManager;
        public SettingsViewModel(
            INavigationService navigationService,
            ISettingsManager settingsManager) :
            base(navigationService)
        {
            _settingsManager = settingsManager;
        }

        #region --- Public Properties ---

        private object _selectedValue;
        public object SelectedValue
        {
            get { return _selectedValue; }
            set { SetProperty(ref _selectedValue, value); }
        }

        #endregion

        #region --- Overrides ---

        protected override void OnPropertyChanged(PropertyChangedEventArgs args)
        {
            _settingsManager.SortMethod = SelectedValue as String;
        }

        #endregion
    }
}
