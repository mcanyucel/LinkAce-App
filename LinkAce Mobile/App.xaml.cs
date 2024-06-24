using Serilog;
using Serilog.Core;

namespace LinkAce_Mobile
{
    public partial class App : Application
    {

        public static new App Current => Application.Current as App ?? throw new InvalidOperationException("Application.Current is null");

        public Logger Logger => logger;
        


        public App()
        {
            InitializeComponent();

             logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .CreateLogger();

            MainPage = new AppShell();
        }

        readonly Logger logger;
    }
}
