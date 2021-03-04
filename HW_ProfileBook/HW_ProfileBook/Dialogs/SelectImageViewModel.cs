using Plugin.Media;
using Plugin.Media.Abstractions;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services.Dialogs;
using System;

namespace HW_ProfileBook.Dialogs
{
    public class SelectImageViewModel : BindableBase, IDialogAware
    {
        private string _ia;
        public SelectImageViewModel()
        {
        }

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
            await CrossMedia.Current.Initialize();

            if (CrossMedia.Current.IsTakePhotoSupported && CrossMedia.Current.IsCameraAvailable)
            {
                var file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
                {
                    SaveToAlbum = true
                });
                if (file == null)
                {
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
