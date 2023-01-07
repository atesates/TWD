using System;
using System.Collections.Generic;
using System.Text;
using TWD.Northwind.WPF.Stores;
using TWD.Northwind.WPF.ViewModels;

namespace TWD.Northwind.WPF.Services
{
    public class ParameterNavigationService<TParameter, TViewModel>
      where TViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        //private readonly Func<TParameter, TViewModel> _createViewModel;
        private readonly Func<TViewModel> _createViewModel;

        public ParameterNavigationService(NavigationStore navigationStore
            , Func<TViewModel> createViewModel)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
        }

        public void Navigate()
        {
            _navigationStore.CurrentViewModel = _createViewModel();
        }
    }
}
