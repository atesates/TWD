using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TWD.Northwind.WPF.Commands;
using TWD.Northwind.WPF.Models;
using TWD.Northwind.WPF.Services;
using TWD.Northwind.WPF.Stores;

namespace TWD.Northwind.WPF.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public string WelcomeMessage => "Welcome to my application";
        public readonly AccountStore _accountStore;
        public ICommand NavigateAccountCommand { get; }
      

        public HomeViewModel(AccountStore accountStore, 
            INavigationService accountNavigationService)
        {
            _accountStore = accountStore;   
              //NavigateAccountCommand = new NavigateAccountCommand(navigationStore);
              //NavigateAccountCommand = new NavigateCommand<AccountViewModel>(navigationStore, () => new AccountViewModel(navigationStore));
              NavigateAccountCommand = new NavigateCommand(accountNavigationService);    
        }
    }
}
