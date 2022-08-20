using DAL.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Services.ClientActions;
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
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.


            ApplicationConfiguration.Initialize();
            var services = new ServiceCollection();
            ConfigureServices(services);

            using (var serviceProvider = services.BuildServiceProvider())
            {
                var dataContext = serviceProvider.GetRequiredService<MaravilContext>();
                dataContext.Database.Migrate();
                var frmInicio = serviceProvider.GetRequiredService<Inicio>();
                Application.Run(frmInicio);
            }

        }

        private static void ConfigureServices(ServiceCollection services)
        {
            services.AddDbContext<MaravilContext>(options =>
                                                  options.UseSqlServer(ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString)); 
            
            services.AddScoped<IClientActions, ClientActions>()
                    .AddScoped<IUserActions, UserActions>()
                    .AddScoped<Inicio>();
        }
    }
}