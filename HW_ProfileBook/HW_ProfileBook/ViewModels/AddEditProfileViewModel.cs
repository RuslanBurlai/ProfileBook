using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HW_ProfileBook.ViewModels
{
    public class AddEditProfileViewModel : ViewModelBase
    {
        public AddEditProfileViewModel(
            INavigationService navigationService) : 
            base(navigationService)
        {
            Title = "Add Profile";
        }
    }
}
