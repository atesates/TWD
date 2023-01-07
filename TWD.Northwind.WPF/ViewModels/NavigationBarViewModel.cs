using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TWD.Northwind.WPF.Commands;
using TWD.Northwind.WPF.Services;
using TWD.Northwind.WPF.Stores;

namespace TWD.Northwind.WPF.ViewModels
{
    public class NavigationBarViewModel : ViewModelBase
    {
        public ICommand NavigateHomeCommand { get; }
        public ICommand NavigateAccountCommand { get; }
        public ICommand NavigateProductListingCommand { get; }

        public NavigationBarViewModel(INavigationService homeNavigationService,
            INavigationService accountNavigationService,
            INavigationService productListingService)
        {
            NavigateHomeCommand = new NavigateCommand(homeNavigationService);
            NavigateAccountCommand = new NavigateCommand(accountNavigationService);
            NavigateProductListingCommand = new NavigateCommand(productListingService);
        }

        public override void Dispose()
        {
           // _accountStore.CurrentAccountChanged -= OnCurrenAccountChanged;
            base.Dispose();
        }
    }
}
