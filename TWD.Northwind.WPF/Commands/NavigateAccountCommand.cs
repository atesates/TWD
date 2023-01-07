using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWD.Northwind.WPF.Models;
using TWD.Northwind.WPF.Services;
using TWD.Northwind.WPF.Stores;
using TWD.Northwind.WPF.ViewModels;

namespace TWD.Northwind.WPF.Commands
{
    public class NavigateAccountCommand : CommandBase
    {
        //private readonly NavigationStore _navigationStore;

        //public NavigateAccountCommand(NavigationStore navigationStore)
        //{
        //    _navigationStore = navigationStore;
        //}
        private readonly AccountViewModel _accountViewModel;
        private readonly NavigationService<AccountViewModel> _navigationService;

        public NavigateAccountCommand(AccountViewModel accountViewModel, NavigationService<AccountViewModel> navigationService)
        {
            _accountViewModel = accountViewModel;
            _navigationService = navigationService;
        }

        public override void Execute(object parameter)
        {
            //_navigationStore.CurrentViewModel = new AccountViewModel(_navigationStore);
            _navigationService.Navigate();
        }
    }
}
