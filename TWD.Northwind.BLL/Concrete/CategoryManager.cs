using System;
using System.Collections.Generic;
using System.Text;
using TWD.Core.Utilities.Results;
using TWD.Northwind.BLL.Abstract;
using TWD.Northwind.BLL.Constants;
using TWD.Northwind.DAL.Abstract;
using TWD.Northwind.DAL.Concrete.EntityFramework;
using TWD.Northwind.Entities.Concrete;

namespace TWD.Northwind.BLL.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }
      
        public IResult Add(Category category)
        {
            _categoryDal.Add(category);
            return new SuccesResult(message: Messages.CategoryAdded);

        }

        public IResult Delete(int categoryId)
        {
            _categoryDal.Delete(new Category { CategoryID = categoryId });
            return new SuccesResult(message: Messages.CategoryDeleted);

        }

        public IDataResult<List<Category>> GetList()
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetList());
        }

        public IDataResult<Category> GetById(int categoryId)
        {
            return new SuccessDataResult<Category>(_categoryDal.Get(filter: p => p.CategoryID == categoryId));
        }

        public IResult Update(Category category)
        {
            _categoryDal.Update(category);
            return new SuccesResult(message: Messages.CategoryUpdated);

        }
    }
}
