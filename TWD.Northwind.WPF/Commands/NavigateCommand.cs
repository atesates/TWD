using System;
using System.Collections.Generic;
using System.Text;
using TWD.Northwind.WPF.Services;
using TWD.Northwind.WPF.ViewModels;

namespace TWD.Northwind.WPF.Commands
{
    public class NavigateCommand : CommandBase
       // where TViewModel : ViewModelBase
    {
        //private readonly NavigationStore _navigationStore;
        //private readonly Func<TViewModel> _createViewModel;

        //public NavigateCommand(NavigationStore navigationStore, Func<TViewModel> createViewModel)
        //{
        //    _navigationStore = navigationStore;
        //    _createViewModel = createViewModel;
        //}

        //to simplyfy above ctor, it is possible to use  service called NavigationService
        private readonly INavigationService _navigationService;

        public NavigateCommand(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public override void Execute(object parameter)
        {
            //_navigationStore.CurrentViewModel = _createViewModel();
            _navigationService.Navigate();
        }
    }
}
