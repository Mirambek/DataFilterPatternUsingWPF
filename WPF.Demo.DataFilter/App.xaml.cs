using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WPF.Demo.DataFilter.DAL;
using WPF.Demo.DataFilter.Repository;
using WPF.Demo.DataFilter.ViewModels;

namespace WPF.Demo.DataFilter
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost host;

        public static IServiceProvider ServiceProvider;

        public App()
        {
            host = Host.CreateDefaultBuilder()
                   .ConfigureServices((context, services) =>
                   {
                       ConfigureServices(context.Configuration, services);
                   })
                   .Build();
            ServiceProvider = host.Services;
        }

        private void ConfigureServices(IConfiguration configuration,
            IServiceCollection services)
        {            
            services.AddSingleton<MainWindow>();
            services.AddScoped<IEmployeesRepository, EmployeesRepository>();
            services.AddScoped<EmployeesViewModel>();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await host.StartAsync();

            var mainWindow = host.Services.GetRequiredService<MainWindow>();
            mainWindow.Show();

            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            using (host)
            {
                await host.StopAsync(TimeSpan.FromSeconds(5));
            }

            base.OnExit(e);
        }
    }
}
