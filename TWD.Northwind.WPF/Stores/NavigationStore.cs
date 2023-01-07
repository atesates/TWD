using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWD.Northwind.WPF.ViewModels;

namespace TWD.Northwind.WPF.Stores
{
    public class NavigationStore
    {
        public event Action? CurrentViewModelChanged;

        //Below method is append to above Action in MainViewModel to subscribe to CurrentViewModel to get informed whenever CurrentViewModel is changed
        //private void OnCurrentViewModelChanged()
        //{
        //    OnPropertyChanged(nameof(CurrentViewModel));
        //}

        private ViewModelBase? _currentViewModel;

        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel?.Dispose();
                _currentViewModel = value;
                OnCurrentViewModelChanged();//tell users when it is changed 
            }
        }

        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }
    }
}
