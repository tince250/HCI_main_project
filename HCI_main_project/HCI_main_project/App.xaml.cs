using HCI_main_project.Model.Services;
using HCI_main_project.Models;
using HCI_main_project.Pages;
﻿using HCI_main_project.Model.Services;
using HCI_main_project.Models;
using HCI_main_project.View;
using HCI_main_project.ViewModel;
using HCI_main_project;
using HCI_main_project.UserControls;
using HCI_main_project.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;


namespace HCI_main_project
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static ServiceProvider serviceProvider;

        private static NavigationService navigator;

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
                options.UseLazyLoadingProxies().
                UseSqlite("Data Source = Tripago.db");
            });

            services.AddSingleton<MainWindow>();
            services.AddSingleton<IRestaurantService, RestaurantService>();
            services.AddSingleton<IAttractionService, AttractionService>();
            services.AddSingleton<IAccommodationService, AccommodationService>();
            services.AddTransient<AddEditRestaurantPage>();
            services.AddTransient<AddressFormControl>();
            services.AddTransient<NameAndPhotoFormControl>();
            services.AddTransient<AddressFormViewModel>();
            services.AddTransient<AddRestaurantPageViewModel>();
            services.AddTransient<NameAndPhotoFormViewModel>();
            services.AddSingleton<IAuthService, AuthService>();
            services.AddSingleton<LoginViewModel>();
            services.AddSingleton<RegisterViewModel>();
            services.AddSingleton<TripDetailsViewModel>();
            services.AddSingleton<LoginPage>();
            //services.AddSingleton<RegisterPage>();
        }
        protected override async void OnStartup(StartupEventArgs e)
        {
            //base.OnStartup(e);
            //this.StartupUri =
            // new Uri("View/TripDetailsPage.xaml", UriKind.Relative);
            var mainWindow = serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }

        protected override void OnNavigated(NavigationEventArgs e)
        {
            base.OnNavigated(e);
            Page page = e.Content as Page;
            if (page != null)
                ApplicationHelper.NavigationService = page.NavigationService;
        }
    }
}
