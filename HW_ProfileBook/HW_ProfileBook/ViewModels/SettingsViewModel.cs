using HW_ProfileBook.Services.ProfileService;
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
        private IProfileSort _profileSort;
        public SettingsViewModel(
            INavigationService navigationService,
            IProfileSort profileSort) 
            : base(navigationService)
        {
            Title = "Settings";
            _profileSort = profileSort;
        }

        #region --- Public Properties ---

        private string GroupName;
        public string _groupName
        {
            get { return GroupName; }
            set { SetProperty(ref GroupName, value); }
        }

        private object _selection;
        public object Selection
        {
            get { return _selection; }
            set { SetProperty(ref _selection, value); }
        }
        private DelegateCommand _sortByName;
        public DelegateCommand SortByName =>
            _sortByName ?? (_sortByName = new DelegateCommand(ExecuteSortByName)
            .ObservesProperty(() => _groupName));

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
            _profileSort.SortProfilesByName();
        }

        private void ExecuteSortByNickName()
        {
            
        }
        private void ExecuteSortByDate()
        {
            
        }

        #endregion
    }
}
