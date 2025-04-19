using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using WpfAppTemplate.Configs;
using WpfAppTemplate.Extensions;

namespace WpfAppTemplate;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public IServiceProvider ServiceProvider { get; private set; } = null!;

    protected override async void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        var services = new ServiceCollection();
        services.ConfigureServices();
        ServiceProvider = services.BuildServiceProvider();

        var dbService = ServiceProvider.GetRequiredService<DatabaseConfig>();
        await dbService.Initialize();

        var mainWindow = ServiceProvider.GetRequiredService<Views.MainWindow>();
        mainWindow.Show();
    }
}

