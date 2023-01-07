using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWD.Northwind.WPF.Models;
using TWD.Northwind.WPF.Stores;

namespace TWD.Northwind.WPF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;

        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;
        //=> means below
        //public ViewModelBase CurrentViewModel()
        //{
        //    return _navigationStore.CurrentViewModel;   
        //}

        public MainViewModel(NavigationStore navigationStore)
        {          
            _navigationStore = navigationStore;
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
