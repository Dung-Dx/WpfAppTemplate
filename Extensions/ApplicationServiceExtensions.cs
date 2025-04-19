using Microsoft.Extensions.DependencyInjection;
using WpfAppTemplate.Views;
using WpfAppTemplate.Configs;
using WpfAppTemplate.Helpers;
using WpfAppTemplate.Repositories;
using WpfAppTemplate.Services;
using WpfAppTemplate.ViewModels;

namespace WpfAppTemplate.Extensions;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection ConfigureServices(this IServiceCollection services)
    {
        // Register database
        services.AddSingleton<DatabaseConfig>();

        services.AddTransient<Views.MainWindow>();

        // Register repositories and services
        services.AddScoped<IDaiLyServices, DaiLyRepository>();
        services.AddScoped<IQuanServices, QuanRepository>();
        services.AddScoped<ILoaiDaiLyServices, LoaiDaiLyRepository>();

        // Register helpers
        services.AddSingleton<ComboBoxItemConverter>();

        // Register ViewModels
        services.AddTransient<MainWindowViewModel>();
        services.AddTransient<HoSoDaiLyViewModel>();
        services.AddTransient<CapNhatDaiLyViewModel>();
        services.AddTransient<Func<int, CapNhatDaiLyViewModel>>(sp => dailyId =>
            new CapNhatDaiLyViewModel(
                sp.GetRequiredService<IDaiLyServices>(),
                sp.GetRequiredService<IQuanServices>(),
                sp.GetRequiredService<ILoaiDaiLyServices>(),
                dailyId
            )
        );

        // Register Views
        services.AddTransient<MainWindow>();
        services.AddTransient<HoSoDaiLyWinDow>();
        services.AddTransient<CapNhatDaiLyWindow>();

        return services;
    }
}
