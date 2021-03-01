using HW_ProfileBook.Services.Validators;
using HW_ProfileBook.Services.Autorization;
using HW_ProfileBook.ViewModels;
using HW_ProfileBook.Views;
using Prism;
using Prism.Ioc;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;
using HW_ProfileBook.Services.Settings;
using HW_ProfileBook.Services.Authentication;
using HW_ProfileBook.Repository;

namespace HW_ProfileBook
{
    public partial class App
    {
        private IAutorithation _autorithation => Container.Resolve<IAutorithation>();
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();
            if(_autorithation.IsAutorized())
            { 
                await NavigationService.NavigateAsync("NavigationPage/MainList");
            }
            else
            {
                await NavigationService.NavigateAsync("NavigationPage/SignIn");
            }
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //Navigation
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<SignIn, SignInViewModel>();
            containerRegistry.RegisterForNavigation<SignUp, SignUpViewModel>();
            containerRegistry.RegisterForNavigation<MainList, MainListViewModel>();
            containerRegistry.RegisterForNavigation<AddEditProfile, AddEditProfileViewModel>();

            //Servies
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

            containerRegistry.RegisterInstance<ISettingsManager>(Container.Resolve<SettingsManager>());
            containerRegistry.RegisterInstance<IAutorithation>(Container.Resolve<Autorithation>());
            containerRegistry.RegisterInstance<IRepository>(Container.Resolve<Repository.Repository>());
        }
    }
}
