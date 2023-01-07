using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Navigation;
using TWD.Northwind.BLL.Abstract;
using TWD.Northwind.WPF.Commands;
using TWD.Northwind.WPF.Services;
using TWD.Northwind.WPF.Stores;

namespace TWD.Northwind.WPF.ViewModels
{
    public  class AddProductViewModel : ViewModelBase   
    {
        private string? _productName;
        private string? _unitPrice;
        private readonly AccountStore _accountStore; 
        public string ProductName
        { 
            get { return _productName; }
            set 
            {
                _productName = value;
                OnPropertyChanged(nameof(ProductName));    
            }
        }
        public string UnitPrice
        {
            get { return _unitPrice; }
            set
            {
                _unitPrice = value;
                OnPropertyChanged(nameof(UnitPrice));
            }
        }

        public ICommand SubmitCommand { get;}
        public ICommand CancelCommand { get; }
        public AddProductViewModel(ProductStore productStore,
            AccountStore accountStore, 
            INavigationService closeNavigationService,
            IProductService productService)
        {
            _accountStore = accountStore;
            CancelCommand = new NavigateCommand(closeNavigationService);
            SubmitCommand = new AddProductCommand(this, productStore, closeNavigationService, productService);
        }

    }
}
