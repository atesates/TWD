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
    public class AccountViewModel : ViewModelBase
    {
        public string WelcomeMessage => "Willkomen " + _accountStore.CurrentAccount?.UserName;
        public readonly AccountStore _accountStore;
        public ICommand NavigateHomeCommand { get; }

       
        public AccountViewModel(AccountStore accountStore, 
            INavigationService homeNavigationService)
        {
           
            _accountStore = accountStore;
            //NavigateHomeCommand = new NavigateHomeCommand(navigationStore);
            //NavigateHomeCommand = new NavigateCommand<HomeViewModel>(navigationStore, () => new HomeViewModel(navigationStore));
            NavigateHomeCommand = new NavigateCommand(homeNavigationService);

        }
        ~AccountViewModel() 
        {

        } 
        //public override void Dispose()
        //{
        //    _accountStore.CurrentAccountChanged -= OnCurrentAccountChanged;

        //}
    }
}
