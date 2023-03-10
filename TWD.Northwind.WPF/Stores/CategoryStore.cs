using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWD.Northwind.Entities.Concrete;

namespace TWD.Northwind.WPF.Stores
{
    public  class CategoryStore
    {
        public event Action<Category> CategoryAdded;

        public void AddCategory(Category category)
        {
            CategoryAdded?.Invoke(category);    
        }
    }
}
