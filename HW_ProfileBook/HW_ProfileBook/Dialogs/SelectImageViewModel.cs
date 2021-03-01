using Prism.Commands;
using Prism.Services.Dialogs;
using System;

namespace HW_ProfileBook.Dialogs
{
    public class SelectImageViewModel : IDialogAware
    {
        public DelegateCommand CloseCommand { get; }

        public SelectImageViewModel()
        {
            CloseCommand = new DelegateCommand(() => RequestClose(null));
        }

        public event Action<IDialogParameters> RequestClose;

        public bool CanCloseDialog() => true;

        public void OnDialogClosed()
        {
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
        }
    }
}
