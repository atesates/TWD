using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWD.Northwind.BLL.Abstract;
using TWD.Northwind.Entities.Concrete;
using TWD.Northwind.WPF.Stores;

namespace TWD.Northwind.WPF.ViewModels
{
    public  class CategoryListingViewModel : ViewModelBase  
    {
        private readonly ObservableCollection<Category> _categories;
        private readonly CategoryStore _categoryStore;
        private readonly ICategoryService _categoryService;

        public CategoryListingViewModel(
            ObservableCollection<Category> categories, 
            CategoryStore categoryStore,
            ICategoryService categoryService)
        {
            _categories = categories;
            _categoryStore = categoryStore;
            _categoryService = categoryService;
        }
    }
}
