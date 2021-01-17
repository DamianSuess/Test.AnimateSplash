using System.Threading.Tasks;
using Test.StartupAnimation.ViewModels;
using Xamarin.Forms;

namespace Test.StartupAnimation.Views
{
  public partial class SplashPage : ContentPage
  {
    public SplashPage()
    {
      InitializeComponent();

      // Hide navigation bar
      NavigationPage.SetHasNavigationBar(this, false);
    }

    protected override void OnAppearing()
    {
      base.OnAppearing();

      ExplodeImageAsync();
    }

    private async void ExplodeImageAsync()
    {
      // Give the UI a moment to load
      await Task.Delay(300);

      await SplashIcon.ScaleTo(0.5, 500, Easing.CubicInOut);

      var animationTasks = new[]
      {
        SplashIcon.ScaleTo(100.0, 1000, Easing.CubicInOut),
        SplashIcon.FadeTo(0, 700, Easing.CubicInOut)
      };

      await Task.WhenAll(animationTasks);

      // Navigate to MainPage via our ViewModel
      SplashPageViewModel viewModel = (SplashPageViewModel)this.BindingContext;
      if (viewModel.CmdNavigateToMain.CanExecute())
      {
        viewModel.CmdNavigateToMain.Execute();
      }
    }
  }
}
