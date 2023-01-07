using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Builder.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;
using TWD.Core.DependencyResolvers;
using TWD.Core.Extensions;
using TWD.Core.Utilities.IoC;
using TWD.Northwind.BLL.Abstract;
using TWD.Northwind.BLL.Concrete;
using TWD.Northwind.DAL.Abstract;
using TWD.Northwind.DAL.Concrete.EntityFramework;
using TWD.Northwind.WPF.Models;
using TWD.Northwind.WPF.Services;
using TWD.Northwind.WPF.Stores;
using TWD.Northwind.WPF.ViewModels;

namespace TWD.Northwind.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //private readonly AccountStore _accountStore;
        //private readonly NavigationStore _navigationStore;
        private readonly IServiceProvider _serviceProvider;
        private readonly IApplicationBuilder _applicationBuilder;

        // private readonly NavigationBarViewModel _navigationBarViewModel;

        public App()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddDependencyResolvers(new ICoreModule[]
            {
                new CoreModule(),
            });

            WpfAppServices wpfAppServices = new WpfAppServices();
            wpfAppServices.SetServices(services);

            _serviceProvider = services.BuildServiceProvider();

            


        }


        protected override void OnStartup(StartupEventArgs e)
        {
            //_navigationStore.CurrentViewModel = new HomeViewModel(_accountStore, _navigationStore);

            //INavigationService<AccountViewModel> accountNavigationService = CreateAccountNavigationService();
            INavigationService initialNavigationService = _serviceProvider.GetRequiredService<INavigationService>();
            //_applicationBuilder.ConfigureCustomExceptionMiddleware();
          
            //NavigationService<HomeViewModel> homeNavigationService = CreateHomeNavigationService();
            //accountNavigationService.Navigate();
            initialNavigationService.Navigate();
            //homeNavigationService.Navigate();

            MainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            MainWindow.Show();

            base.OnStartup(e);
        }
       

 
    }
}
