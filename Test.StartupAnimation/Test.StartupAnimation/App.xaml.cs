using Prism;
using Prism.Ioc;
using Test.StartupAnimation.ViewModels;
using Test.StartupAnimation.Views;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;

namespace Test.StartupAnimation
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

      // Create a navigation stack starting with our Splash animation page
      await NavigationService.NavigateAsync($"{nameof(NavigationPage)}/{nameof(SplashPage)}");
    }

    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
      containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

      containerRegistry.RegisterForNavigation<NavigationPage>();
      containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
      containerRegistry.RegisterForNavigation<SplashPage, SplashPageViewModel>();
    }
  }
}
