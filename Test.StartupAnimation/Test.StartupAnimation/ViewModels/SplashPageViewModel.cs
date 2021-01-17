using Prism.Commands;
using Prism.Navigation;
using Test.StartupAnimation.Views;

namespace Test.StartupAnimation.ViewModels
{
  public class SplashPageViewModel : ViewModelBase
  {
    public SplashPageViewModel(INavigationService navigationService)
      : base(navigationService)
    {
      Title = string.Empty;
    }

    public DelegateCommand CmdNavigateToMain => new DelegateCommand(async () =>
    {
      // Swap the navigation stack
      await NavigationService.NavigateAsync($"../{nameof(MainPage)}");

      // No noticeable difference on Android 10
      ////await NavigationService.NavigateAsync($"../{nameof(MainPage)}",
      ////                                      new NavigationParameters(),
      ////                                      null,
      ////                                      animated: false);
    });
  }
}