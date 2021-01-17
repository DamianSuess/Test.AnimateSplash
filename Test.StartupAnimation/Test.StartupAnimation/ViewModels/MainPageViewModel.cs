using Prism.Navigation;

namespace Test.StartupAnimation.ViewModels
{
  public class MainPageViewModel : ViewModelBase
  {
    public MainPageViewModel(INavigationService navigationService)
      : base(navigationService)
    {
      Title = "Main Page";
    }
  }
}