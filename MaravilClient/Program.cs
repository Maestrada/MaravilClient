using DAL.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Services.ClientActions;
using Services.StatesActions;
using Services.TownActions;
using Services.UserActions;
using System.Configuration;
using System.Windows.Forms;

namespace MaravilClient
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var host = CreateHostBuilder().Build();
            ServiceProvider = host.Services;
            using (var scope =ServiceProvider.CreateScope())
            {
                var dataContext = ServiceProvider.GetRequiredService<MaravilContext>();
                dataContext.Database.Migrate();
                Application.Run(ServiceProvider.GetRequiredService<Inicio>());
            }
        }
        public static IServiceProvider ServiceProvider { get; private set; }
        static IHostBuilder CreateHostBuilder()
        {
           
            return Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration(x=>x.AddJsonFile("appConfig.json"))
                .ConfigureServices((context, services) => {
                    services.AddDbContext<MaravilContext>(options =>
                                                   options.UseSqlServer(context.Configuration.GetConnectionString("SQLConnection")));
                    services.AddTransient<IUserActions, UserActions>();
                    services.AddTransient<IClientActions, ClientActions>();
                    services.AddTransient<IStateActions, StateActions>();
                    services.AddTransient<ITonwActions, TonwActions>();
                    services.AddTransient<Inicio>();
                });
        }       
    }
}