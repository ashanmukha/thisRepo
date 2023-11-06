
using Microsoft.Extensions.Configuration;
using VisitorManagement.Interface;
using VisitorManagement.Views;


namespace VisitorManagement;

public partial class App : Application
{
	public static INativeHelper GetNativeHelper {get; set;}
	public static IToastPopUp GetToast { get; set;}
   
    public static ICameraProvider GetCameraProvider { get; set;}
    public App(INativeHelper nativeHelper,IToastPopUp toast,ICameraProvider camera, IConfiguration configuration)
	{
       
        GetCameraProvider = camera;
		GetNativeHelper = nativeHelper;
		GetToast = toast;
        Application.Current.UserAppTheme = AppTheme.Light;
        InitializeComponent();

		MainPage = new AppShell();
		Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping(nameof(CustomControls.CustomEntry),(Handler, view)=>{
			Handler.PlatformView.SetBackgroundColor(Android.Graphics.Color.White);
		});
		Microsoft.Maui.Handlers.PickerHandler.Mapper.AppendToMapping(nameof(CustomControls.Custompicker), (Handler, view) => {

			Handler.PlatformView.SetBackgroundColor(Android.Graphics.Color.White);
		});
		Microsoft.Maui.Handlers.TimePickerHandler.Mapper.AppendToMapping(nameof(TimePicker), (Handler, view) => {

			Handler.PlatformView.SetBackgroundColor(Android.Graphics.Color.White);
		});
		Microsoft.Maui.Handlers.SearchBarHandler.Mapper.AppendToMapping(nameof(SearchBar), (Handler, view) => {

			Handler.PlatformView.Background = null;
		});
	}
}
