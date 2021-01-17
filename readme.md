# Xamarin.Forms Startup Animation
This lesson shows you how to create a light-weight startup animation using static images.

## Hiding Splash Animation Navigation
After validating our animation, we need to hide UI stuff such as the Navigation Bar. To do so we need to add, ``NavigationPage.SethasNavigationBar(this, false);`` inside the constructor of our ``SplashPage.xml.cs`` file.

```cs
public SplashPage()
{
  InitializeComponent();

  // Hide navigation bar
  NavigationPage.SetHasNavigationBar(this, false);
}
```

## Further Mods
To hide status bar, we'll need to perform some native-side code.

### Single Page Use
**NOTE: THIS IS UNTESTED!!**

Create the IStatusBar interface in our client-side project
```cs
public interface IStatusBar
{
  void HideStatusBar();
  void ShowStatusBar();
}
```

Android:
```cs
public class StatusBarImplementation : IStatusBar
{
  WindowManagerFlags _originalFlags;

  public void HideStatusBar()
  {
    var activity = (Activity)Forms.Context;
    var attrs = activity.Window.Attributes;
    _originalFlags = attrs.Flags;
    attrs.Flags |= Android.Views.WindowManagerFlags.Fullscreen;
    activity.Window.Attributes = attrs;
  }
  public void ShowStatusBar()
  {
    var activity = (Activity)Forms.Context;
    var attrs = activity.Window.Attributes;
    attrs.Flags = _originalFlags;
    activity.Window.Attributes = attrs;
  }
}
```

iOS:
```cs
public class StatusBarImplementation : IStatusBar
{
  WindowManagerFlags _originalFlags;

  public void HideStatusBar()
  {
    var activity = (Activity)Forms.Context;
    var attrs = activity.Window.Attributes;
    _originalFlags = attrs.Flags;
    attrs.Flags |= Android.Views.WindowManagerFlags.Fullscreen;
    activity.Window.Attributes = attrs;
  }
  public void ShowStatusBar()
  {
    var activity = (Activity)Forms.Context;
    var attrs = activity.Window.Attributes;
    attrs.Flags = _originalFlags;
    activity.Window.Attributes = attrs;
  }
}
```

Inside our SplashPage
```cs
// to hide
DependencyService.Get<IStatusBar>().HideStatusBar();
// to show
DependencyService.Get<IStatusBar>().ShowStatusBar();
```

#### References
This code snip was borrowed from a StackOverflow discussion on [Hide StatusBar for Specific ContentPage](https://stackoverflow.com/questions/36449480/hide-statusbar-for-specific-contentpage) [2](https://medium.com/@fairushyn/how-to-hide-status-bar-for-specific-content-page-in-xamarin-d8d02a00f18c)

### For the whole app

For Android it would be the following in the Activity's OnCreate (_i.e. ``MainActivity``_):
```cs
this.Window.AddFlags(WindowManagerFlags.Fullscreen); //to show
this.Window.ClearFlags(WindowManagerFlags.Fullscreen); //to hide
```

And for iOS, you'd open your ``Info.plist`` and add the following lines:
```xml
<key>UIStatusBarHidden</key><true/>
<key>UIViewControllerBasedStatusBarAppearance</key><false/>
```


## Without Prism

For use with standard Xamarin Navigation stack, check out this article at [Mallibone.com](https://mallibone.com/post/lets-improve-that-xamarin-forms-startup-experience)
