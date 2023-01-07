using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWD.Northwind.BLL.Abstract;
using TWD.Northwind.BLL.Concrete;
using TWD.Northwind.DAL.Abstract;
using TWD.Northwind.DAL.Concrete.EntityFramework;
using TWD.Northwind.WPF.Stores;
using TWD.Northwind.WPF.ViewModels;

namespace TWD.Northwind.WPF.Services
{
    public class WpfAppServices
    {
        public void SetServices(IServiceCollection services)
        {
            services.AddSingleton<IProductService>(s => CreateProductService(s));
            services.AddSingleton<ICategoryService>(s => new CategoryManager(s.GetRequiredService<EfCategoryDal>()));
            services.AddSingleton<ICategoryDal>(s => new EfCategoryDal());

            services.AddSingleton<AccountStore>();
            services.AddSingleton<ProductStore>();
            services.AddSingleton<NavigationStore>();
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<ProductManager>();
            services.AddSingleton<EfProductDal>();
            services.AddSingleton<CategoryManager>();

            services.AddSingleton<NavigationBarViewModel>(CreateNavigationBarViewModel);

            //services.AddSingleton<ICategoryService>();
            services.AddSingleton<INavigationService>(s => CreateAccountNavigationService(s));

            services.AddTransient<AccountViewModel>(s => new AccountViewModel(
                s.GetRequiredService<AccountStore>(),
                CreateHomeNavigationService(s)));

            services.AddTransient<HomeViewModel>(s => new HomeViewModel(
                s.GetRequiredService<AccountStore>(),
                CreateAccountNavigationService(s)));

            services.AddSingleton<ProductListingViewModel>(s => new ProductListingViewModel(
                s.GetRequiredService<ProductStore>(),
                CreateAddProductNavigationService(s),
                CreateProductService(s),
                s.GetRequiredService<AccountStore>()));

            services.AddTransient<AddProductViewModel>(s => new AddProductViewModel(
                s.GetRequiredService<ProductStore>(),
                s.GetRequiredService<AccountStore>(),
                CreateProductsListingNavigationService(s),
                CreateAddProductService(s)
                ));


            services.AddSingleton<MainWindow>(s => new MainWindow()
            {
                DataContext = s.GetRequiredService<MainViewModel>()
            });
        }

        private ICategoryService CreateCategoryService(IServiceProvider s)
        {
            return new CategoryManager(s.GetRequiredService<EfCategoryDal>());
        }

        private IProductService CreateProductService(IServiceProvider serviceProvider)
        {
            return new ProductManager(serviceProvider.GetRequiredService<EfProductDal>(),
               serviceProvider.GetRequiredService<CategoryManager>());
        }

        private IProductService CreateAddProductService(IServiceProvider serviceProvider)
        {
            return new ProductManager(serviceProvider.GetRequiredService<EfProductDal>(),
                serviceProvider.GetRequiredService<CategoryManager>());
        }

        private NavigationBarViewModel CreateNavigationBarViewModel(IServiceProvider serviceProvider)
        {
            return new NavigationBarViewModel(
                            // _accountStore,
                            CreateHomeNavigationService(serviceProvider),
                            CreateAccountNavigationService(serviceProvider),
                            CreateProductsListingNavigationService(serviceProvider)
                            );
        }




        private INavigationService CreateAddProductNavigationService(IServiceProvider serviceProvider)
        {
            return new NavigationService<AddProductViewModel>(
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<AddProductViewModel>());
        }


        private INavigationService CreateProductsListingNavigationService(IServiceProvider serviceProvider)
        {
            return new LayoutNavigationService<ProductListingViewModel>(
           serviceProvider.GetRequiredService<NavigationStore>(),
           () => serviceProvider.GetRequiredService<ProductListingViewModel>(),
           () => serviceProvider.GetRequiredService<NavigationBarViewModel>());
        }

        private INavigationService CreateHomeNavigationService(IServiceProvider serviceProvider)
        {
            return new LayoutNavigationService<HomeViewModel>(
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<HomeViewModel>(),
                () => serviceProvider.GetRequiredService<NavigationBarViewModel>());
        }

        private INavigationService CreateAccountNavigationService(IServiceProvider serviceProvider)
        {// to navigate a view without layout just use NavigationService instead of LayoutNavigationService
            return new LayoutNavigationService<AccountViewModel>(
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<AccountViewModel>(),
                () => serviceProvider.GetRequiredService<NavigationBarViewModel>());
        }
    }
}
