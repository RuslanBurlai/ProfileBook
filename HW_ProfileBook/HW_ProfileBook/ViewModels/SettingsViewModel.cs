using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HW_ProfileBook.ViewModels
{
    public class SettingsViewModel : ViewModelBase
    {
        public SettingsViewModel(INavigationService navigationService) 
            : base(navigationService)
        {
            Title = "Settings";
        }

        #region --- Public Properties ---

        private DelegateCommand _sortByName;
        public DelegateCommand SortByName =>
            _sortByName ?? (_sortByName = new DelegateCommand(ExecuteSortByName));

        private DelegateCommand _sortByNickName;
        public DelegateCommand SortByNickName =>
            _sortByNickName ?? (_sortByNickName = new DelegateCommand(ExecuteSortByNickName));

        private DelegateCommand _sortByDate;
        public DelegateCommand SortByDate =>
            _sortByDate ?? (_sortByDate = new DelegateCommand(ExecuteSortByDate));

        
        #endregion

        #region --- Private Helpers ---

        private void ExecuteSortByName()
        {
            NavigationService.GoBackAsync();
        }

        private void ExecuteSortByNickName()
        {
            NavigationService.GoBackAsync();
        }
        private void ExecuteSortByDate()
        {
            NavigationService.GoBackAsync();
        }

        #endregion
    }
}
