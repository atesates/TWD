using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWD.Northwind.BLL.Abstract;
using TWD.Northwind.Entities.Concrete;
using TWD.Northwind.WPF.Services;
using TWD.Northwind.WPF.Stores;
using TWD.Northwind.WPF.ViewModels;

namespace TWD.Northwind.WPF.Commands
{
    public  class DeleteProductCommand : CommandBase
    {
        private readonly ProductListingViewModel _productListingViewModel;
        private readonly ProductStore _productStore;
        private readonly IProductService _productService;

        public DeleteProductCommand(ProductListingViewModel productListingViewModel,
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
            _productService.Delete(product.ProductID);
        }
    }
}
