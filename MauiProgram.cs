
using CommunityToolkit.Maui;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Maui;
using Mopups.Hosting;
using System.Reflection;
using VisitorManagement.CustomControls;
using VisitorManagement.Interface;
#if ANDROID
using VisitorManagement.Platforms.Android;
using VisitorManagement.Platforms.Android.Dependency;
#endif
using VisitorManagement.viewModels;
using VisitorManagement.Views;

namespace VisitorManagement;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
            .UseMauiApp<App>().UseMauiCommunityToolkit()
            .UseMauiApp<App>().ConfigureMopups()
            .ConfigureMopups()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
				fonts.AddFont("grialshape.ttf", "grialshape");
			});


		Microsoft.Maui.Handlers.ElementHandler.ElementMapper.AppendToMapping("classic", (handler, view) =>
		{

			if (view is BorderWithEntry)
			{
#if ANDROID
                HandlerEntry.map(handler, view);
#endif
			}

		});
        var executingAssembly = Assembly.GetExecutingAssembly();

        using var stream = executingAssembly.GetManifestResourceStream("VisitorManagement.appsettings.json");

        var configuration = new ConfigurationBuilder()
            .AddJsonStream(stream)

            .Build();



#if DEBUG
        builder.Logging.AddDebug();
#endif
        builder.Services.AddTransient<LoginPage>();
        builder.Services.AddTransient<VisitOtpPageViewModel>();
		builder.Services.AddTransient<VisitorEntryPage_Step2>();
		builder.Services.AddTransient<Visitor_EntryPage>();
        builder.Services.AddTransient<VisitorInformationPage>();
        builder.Services.AddTransient<VisitorInformationpageViewModel>();
        builder.Services.AddTransient<ConfirmVisitorPass>();

        //Interface
#if ANDROID
        builder.Services.AddSingleton<INativeHelper, NativeHelper>();
        builder.Services.AddSingleton<IToastPopUp, ToastPopUp>();
        builder.Services.AddSingleton<ICameraProvider, CameraProvider>();
#endif



        builder.Configuration
              .AddConfiguration(configuration);

        return builder.Build();
	}
}
