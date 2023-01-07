using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using TWD.Northwind.BLL.Abstract;
using System.Linq;
using TWD.Northwind.Entities;
using TWD.Northwind.Entities.Concrete;
using System.Windows.Input;
using TWD.Northwind.WPF.Services;
using TWD.Northwind.WPF.Commands;
using TWD.Northwind.WPF.Stores;
using System.Windows.Controls;

namespace TWD.Northwind.WPF.ViewModels
{
    public class ProductListingViewModel : ViewModelBase
    {
        private readonly ObservableCollection<Product> _products;
        private readonly ProductStore _productStore;
        private readonly IProductService _productService;
        private string _productName;
        private string _unitPrice;
        private readonly NavigationService<AccountViewModel> _navigationService;
        private readonly AccountStore _accountStore;
        private Product selectedProduct;

        public event Action CurrentProductsChange;
        public event Action ShowDetails;

        #region props
        public Product SelectedProduct
        {
            get { return selectedProduct; }
            set
            {
                if(value!= selectedProduct)
                {
                    selectedProduct = value;
                    OnPropertyChanged(nameof(SelectedProduct));
                }
            }
        }
        public ObservableCollection<Product> Products
        {
            get { return _products; }
            set
            {
                OnPropertyChanged(nameof(CurrentProductsChange));
            }
        }
        private void OnCurrentProductsChanged(Product product)
        {
            _products.Add(product);
        }
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
        #endregion


        public ICommand AddProductCommand { get; }    
        public ICommand UpdateProductCommand { get; }

        public ICommand DeleteProductCommand { get; }

        public ProductListingViewModel(ProductStore productStore, 
            INavigationService addPersonNavigationService,
            IProductService productService, 
            AccountStore accountStore)
        {
            AddProductCommand = new NavigateCommand(addPersonNavigationService);
            _productService = productService;
            _products = new ObservableCollection<Product>();
            _accountStore = accountStore;
            UpdateProductCommand = new UpdateProductCommand(this, productStore, productService);
            DeleteProductCommand = new DeleteProductCommand(this, productStore, productService);
            Product product = new Product();
            var products = _productService.GetListByCategory(1);
            foreach (var productItem in products.Data)
            {
                _products.Add(productItem);
            }
            _productStore = productStore;
            _productStore.ProductAdded += OnCurrentProductsChanged;

        }
       
 
    }
}
