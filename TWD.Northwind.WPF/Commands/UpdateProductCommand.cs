using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWD.Northwind.BLL.Abstract;
using TWD.Northwind.Entities.Concrete;
using TWD.Northwind.WPF.Stores;
using TWD.Northwind.WPF.ViewModels;

namespace TWD.Northwind.WPF.Commands
{
    public class UpdateProductCommand : CommandBase
    {
        private readonly ProductListingViewModel _productListingViewModel;
        private readonly ProductStore _productStore;
        private readonly IProductService _productService;

        public UpdateProductCommand(
            ProductListingViewModel productListingViewModel,
            ProductStore productStore, 
            IProductService productService)
        {
            _productListingViewModel = productListingViewModel;
            _productStore = productStore;
            _productService = productService;
        }

        public override void Execute(object parameter)
        {
            Product product = _productListingViewModel.SelectedProduct;
            product.ProductName = _productListingViewModel.SelectedProduct.ProductName;
            product.UnitPrice = _productListingViewModel.SelectedProduct.UnitPrice;
            
            _productService.Update(product);
        }
    }
}
