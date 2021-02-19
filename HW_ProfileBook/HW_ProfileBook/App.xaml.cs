using HW_ProfileBook.Services.Validators;
using HW_ProfileBook.Services.Autorization;
using HW_ProfileBook.ViewModels;
using HW_ProfileBook.Views;
using Prism;
using Prism.Ioc;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;

namespace HW_ProfileBook
{
    public partial class App
    {
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/SignIn");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<SignIn, SignInViewModel>();
            containerRegistry.RegisterForNavigation<SignUp, SignUpViewModel>();
            containerRegistry.RegisterForNavigation<MainList, MainListViewModel>();
            containerRegistry.RegisterForNavigation<AddEditProfile, AddEditProfileViewModel>();

            containerRegistry.RegisterInstance<ILoginValidators>(Container.Resolve<LoginValidators>());
            containerRegistry.RegisterInstance<IPasswordValidators>(Container.Resolve<PasswordValidators>());
            containerRegistry.RegisterInstance<IAutorithation>(Container.Resolve<Autorithation>());
            containerRegistry.RegisterInstance<IEmptyEnrty>(Container.Resolve<CheckEntry>());
        }
    }
}
