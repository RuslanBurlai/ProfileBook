using Plugin.Media;
using Plugin.Media.Abstractions;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;

namespace HW_ProfileBook.Dialogs
{
    public class SelectImageViewModel : BindableBase, IDialogAware
    {
        #region --- Public Properties---

        private DelegateCommand _pickItGalarry;
        public DelegateCommand PickAtGelarry =>
            _pickItGalarry ?? (_pickItGalarry = new DelegateCommand(ExecutePickAtGelarry));

        private DelegateCommand _pickWithCamera;
        public DelegateCommand PickWithCamera =>
            _pickWithCamera ?? (_pickWithCamera = new DelegateCommand(ExecutePickWithCamera));

        #endregion

        #region --- Private Helpers ---

        private async void ExecutePickWithCamera()
        {
            if (CrossMedia.Current.IsTakePhotoSupported && CrossMedia.Current.IsCameraAvailable)
            {
                var file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
                {
                    SaveToAlbum = true
                });
                if (file == null)
                {
                    return;
                }
                RequestClose(new DialogParameters { { nameof(SelectImage), file.Path } });
            }
        }

        private async void ExecutePickAtGelarry()
        {
            var file = await CrossMedia.Current.PickPhotoAsync();
            RequestClose(new DialogParameters { { nameof(SelectImage), file.Path } });
        }

        #endregion


        #region --- Implement IDialogAware ---

        public event Action<IDialogParameters> RequestClose;

        public bool CanCloseDialog() => true;

        public void OnDialogClosed()
        {
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
        }

        #endregion
    }
}
