using HCI_main_project.Model.Services;
using HCI_main_project.Models;
using HCI_main_project;
using HCI_main_project.UserControls;
using HCI_main_project.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;


namespace HCI_main_project
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static ServiceProvider serviceProvider;

        public App()
        {
            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            serviceProvider = services.BuildServiceProvider();
        }

        [STAThread]
        private void ConfigureServices(ServiceCollection services)
        {
            services.AddDbContext<TripagoContext>(options =>
            {
                options.UseSqlite("Data Source = Tripago.db");
            });

            services.AddSingleton<MainWindow>();
            services.AddSingleton<IRestaurantService, RestaurantService>();
            services.AddTransient<AddEditRestaurantPage>();
            services.AddTransient<AddressFormControl>();
            services.AddTransient<NameAndPhotoFormControl>();
            services.AddTransient<AddressFormViewModel>();
            services.AddTransient<AddRestaurantPageViewModel>();
            services.AddTransient<NameAndPhotoFormViewModel>();
        }
        private void OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }

        
    }
}
