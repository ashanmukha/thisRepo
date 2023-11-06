
using VisitorManagement.Views;

namespace VisitorManagement;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		//Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
      //  Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));      
        //Routing.RegisterRoute(nameof(Visitor_EntryPage), typeof(Visitor_EntryPage));
		Routing.RegisterRoute(nameof(VisitorEntryPage_Step2), typeof(VisitorEntryPage_Step2));
		Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
		//Routing.RegisterRoute(nameof(SettingsPage), typeof(SettingsPage));
		//Routing.RegisterRoute(nameof(VisitorLogPage), typeof(VisitorLogPage));
		Routing.RegisterRoute(nameof(VisitorInformationPage), typeof(VisitorInformationPage));
		Routing.RegisterRoute(nameof(CaptureDetailsPage), typeof(CaptureDetailsPage));
		Routing.RegisterRoute(nameof(ConfirmVisitorPass), typeof(ConfirmVisitorPass));
		Routing.RegisterRoute(nameof(PrintVisitordetailsPage), typeof(PrintVisitordetailsPage));
		
	}
    //ShellContent _previousShellContent;

    //protected override void OnNavigated(ShellNavigatedEventArgs args)
    //{
    //    base.OnNavigated(args);
    //    if (CurrentItem?.CurrentItem?.CurrentItem is not null &&
    //        _previousShellContent is not null)
    //    {
    //        var property = typeof(ShellContent)
    //            .GetProperty("ContentCache", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.FlattenHierarchy);

    //        property.SetValue(_previousShellContent, null);
    //    }

    //    _previousShellContent = CurrentItem?.CurrentItem?.CurrentItem;
    //}
}
