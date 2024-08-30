using Acr.UserDialogs;
using Microsoft.Extensions.Logging;
using Spherum.Models;
using Spherum.ViewModels;
using Spherum.ViewModels.Base;
using Spherum.Views;

namespace Spherum;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .RegisterViewModel()
            .RegisterViews()
            .RegisterAppServices()
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }


    private static MauiAppBuilder RegisterViews(this MauiAppBuilder mauiAppBuilder)
    {
        mauiAppBuilder.Services.AddTransient<StudentsView>();
        mauiAppBuilder.Services.AddTransient<StudentDetailsView>();
        mauiAppBuilder.Services.AddTransient<StudentFormViewModel>();
        mauiAppBuilder.Services.AddSingleton<Testing>();

        return mauiAppBuilder;
    }

    private static MauiAppBuilder RegisterViewModel(this MauiAppBuilder mauiAppBuilder)
    {
        mauiAppBuilder.Services.AddTransient<StudentsViewModel>();
        mauiAppBuilder.Services.AddTransient<StudentDetailsViewModel>();
        mauiAppBuilder.Services.AddTransient<ViewModels.StudentFormViewModel>();
        mauiAppBuilder.Services.AddSingleton<ItemsViewModel>();
        return mauiAppBuilder;
    }

    private static MauiAppBuilder RegisterAppServices(this MauiAppBuilder mauiAppBuilder)
    {
        mauiAppBuilder.Services.AddSingleton<IUserDialogs>(UserDialogs.Instance);
        mauiAppBuilder.Services.AddSingleton<IItemService, ItemService>();
        return mauiAppBuilder;
    }
}

