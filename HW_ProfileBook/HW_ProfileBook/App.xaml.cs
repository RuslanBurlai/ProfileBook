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
using HW_ProfileBook.Dialogs;
using HW_ProfileBook.Services.ProfileService;
using HW_ProfileBook.Services.Theme;
using HW_ProfileBook.Services.Localize;

namespace HW_ProfileBook
{
    public partial class App
    {
        private IAutorithation _autorithation => Container.Resolve<IAutorithation>();
        private ILoadAppereance _loadAppereance => Container.Resolve<ILoadAppereance>();

        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected async override void OnInitialized()
        {
            InitializeComponent();
            _loadAppereance.SetAppTheme();
            if (_autorithation.IsAutorized())
            {
                await NavigationService.NavigateAsync($"{nameof(NavigationPage)}/{nameof(MainList)}");
            }
            else
            {
                await NavigationService.NavigateAsync($"{nameof(NavigationPage)}/{nameof(SignIn)}");
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
            containerRegistry.RegisterInstance<IAuthentication>(Container.Resolve<Authentication>());
            containerRegistry.RegisterInstance<IProfileDataBase>(Container.Resolve<ProfileDataBase>());
            containerRegistry.RegisterInstance<IProfileSort>(Container.Resolve<ProfileSort>());
            containerRegistry.RegisterInstance<ILoadAppereance>(Container.Resolve<LoadAppereance>());
            containerRegistry.RegisterInstance<ILocalize>(Container.Resolve<Localize>());

            //Dialogs
            containerRegistry.RegisterDialog<SelectImage, SelectImageViewModel>();
            containerRegistry.RegisterForNavigation<Settings, SettingsViewModel>();
        }
    }
}
