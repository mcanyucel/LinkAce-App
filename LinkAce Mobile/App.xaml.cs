using LinkAce_Mobile.Repositories;
using LinkAce_Mobile.Repositories.Implementations;
using LinkAce_Mobile.Services;
using LinkAce_Mobile.Services.Implementations;
using LinkAce_Mobile.ViewModels;
using Serilog;
using Serilog.Core;

namespace LinkAce_Mobile;

public partial class App : Application
{

    public static new App Current => Application.Current as App ?? throw new InvalidOperationException("Application.Current is null");

    public Logger Logger => logger;

    public IServiceProvider ServiceProvider { get; init; }



    public App()
    {
        InitializeComponent();

        logger = new LoggerConfiguration()
           .MinimumLevel.Debug()
           .WriteTo.Console()
           .CreateLogger();

        ServiceProvider = ConfigureServices();

        MainPage = new AppShell();
    }

    private ServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();

        // Singletons
        services.AddSingleton<MainViewModel>();
        services.AddSingleton<IPreferenceService, MAUIPreferenceService>();
        services.AddSingleton<PreferenceViewModel>();
        // for now inject here as we do not support other backends - later refactor to use a factory
        services.AddSingleton<ILinkRepository, LinkAceRepository>();

        // Transients
        services.AddTransient<DetailsViewModel>();

        return services.BuildServiceProvider();
    }

    readonly Logger logger;
}
