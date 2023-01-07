using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWD.Core.Utilities.IoC;
using TWD.Northwind.BLL.Abstract;
using TWD.Northwind.Entities.Concrete;
using TWD.Northwind.WPF.Services;
using TWD.Northwind.WPF.Stores;
using TWD.Northwind.WPF.ViewModels;

namespace TWD.Northwind.WPF.Commands
{
    public class AddProductCommand : CommandBase
    {
        private readonly AddProductViewModel _addProductViewModel;
        private readonly ProductStore _productStore;
        private readonly INavigationService _navigationService;
        private readonly IProductService _productService;

        public AddProductCommand(
            AddProductViewModel addProductViewModel,
            ProductStore productStore,
            INavigationService navigationService,
            IProductService productService )
        {
            _addProductViewModel = addProductViewModel;
            _productStore = productStore;
            _navigationService = navigationService;
            _productService = productService;
        }

        public override void Execute(object parameter)
        {
            Product product = new Product();
            product.ProductName = _addProductViewModel.ProductName;
            product.UnitPrice = 10;
            product.CategoryID = 1;
            product.UnitsInStock = 10;
            _productService.Add(product);
            _productStore.AddProduct(product);
            _navigationService.Navigate();
        }
    }
}
