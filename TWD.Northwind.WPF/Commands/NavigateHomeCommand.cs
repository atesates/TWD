using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWD.Northwind.WPF.Services;
using TWD.Northwind.WPF.Stores;
using TWD.Northwind.WPF.ViewModels;

namespace TWD.Northwind.WPF.Commands
{
    public class NavigateHomeCommand : CommandBase
    {
        //private readonly NavigationStore _navigationStore;

        //public NavigateHomeCommand(NavigationStore navigationStore)
        //{
        //    _navigationStore = navigationStore;
        //}

        private readonly AccountViewModel _accountViewModel;
        private readonly NavigationService<AccountViewModel> _navigationService;

        public NavigateHomeCommand(AccountViewModel accountViewModel,
            NavigationService<AccountViewModel> navigationService)
        {
            _accountViewModel = accountViewModel;
            _navigationService = navigationService;
        }

        public override void Execute(object parameter)
        {
            // _navigationStore.CurrentViewModel = new HomeViewModel(_navigationStore);
            _navigationService.Navigate();
        }
    }
}
