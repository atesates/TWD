using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TWD.Core.Aspects.Autofac.Caching;
using TWD.Core.Aspects.Autofac.Exception;
using TWD.Core.Aspects.Autofac.Logging;
using TWD.Core.Aspects.Autofac.Performance;
using TWD.Core.CrossCuttingConcerns.Aspects.Autofac.Caching;
using TWD.Core.CrossCuttingConcerns.Aspects.Autofac.Transaction;
using TWD.Core.CrossCuttingConcerns.Logging.Loggers;
using TWD.Core.CrossCuttingConcerns.Validation;
using TWD.Core.Extensions;
using TWD.Core.Utilities.Business;
using TWD.Core.Utilities.Results;
using TWD.Northwind.BLL.Abstract;
using TWD.Northwind.BLL.BusinessAspects;
using TWD.Northwind.BLL.Constants;
using TWD.Northwind.BLL.ValidationRules.FluentValidation;
using TWD.Northwind.Core.Aspects.Autofac.Validation;
using TWD.Northwind.DAL.Abstract;
using TWD.Northwind.Entities.Concrete;

namespace TWD.Northwind.BLL.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;
        private ICategoryService _categoryService;
        //private IHttpContextAccessor _httpContextAccessor;
        public ProductManager(IProductDal productDal, ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService;
        }
        //public ProductManager(IProductDal productDal, IHttpContextAccessor httpContextAccessor)
        //{
        //    _productDal = productDal;
        //    _httpContextAccessor = httpContextAccessor;
        //}
        [LogAspect(typeof(DatabaseLogger))]
        [ValidationAspect(typeof(ProductValidator), Priority = 2)]
        //[CacheRemoveAspect("IProductService.GetListByCategory", Priority = 1)]
        // [CacheRemoveAspect(pattern:"ICategoryService.Get")] // burasi calismiyor
        public IResult Add(Product product)
        {
            //ValidationTool.Validate(new ProductValidator(),product);

            IResult result = BusinessRules.Run(CheckIfProductNameExists(product.ProductName));
            if(result!=null)
            {
                return result;
            }
            _productDal.Add(product);
            return new SuccesResult(Messages.ProductAdded);
        }

        private IResult CheckIfProductNameExists(string productName)
        {
            if (_productDal.Get(p => p.ProductName == productName) != null)
            {
                return new ErrorResult(Messages.ProductNameIsAlreadyExists);
            }
            return new SuccesResult();
        }
        private IResult CheckIfCategoryIsEnabled()
        {
            var result = _categoryService.GetList();
            if(result!=null) 
            {
                return new ErrorResult(Messages.ProductNameIsAlreadyExists);

            }
            return new SuccesResult();

        }
        public IResult Update(Product product)
        {
            //_httpContextAccessor.HttpContext.User.ClaimRoles(); // we could get the claims but we would be independed to http, what would be when we need desktop apps? we use securedOperations in bll
            _productDal.Update(product);
            return new SuccesResult(message: Messages.ProductUpdated);
        }

        [ExceptionLogAspect(loggerService:typeof(FileLogger))] // you must write it above all methods!!
        public IResult Delete(int productId)
        {
            _productDal.Delete(new Product { ProductID = productId });
            return new SuccesResult(message: Messages.ProductDeleted);
        }
        [PerformanceAspect(interval: 5)]
        public IDataResult<List<Product>> GetList()
        {
            Thread.Sleep(5000);
            return new SuccessDataResult<List<Product>>(_productDal.GetList());
        }

        //[SecuredOperation(roles:"Product.List, Admin")]
        //[CacheAspect(duration:10)]
        //[LogAspect(typeof(FileLogger))]
        //[ExceptionLogAspect(loggerService:typeof(FileLogger))] you must write it above all methods!!
        [LogAspect(typeof(DatabaseLogger))]
        public IDataResult<List<Product>> GetListByCategory(int categoryId)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetList(p => p.CategoryID == categoryId || categoryId == 0).ToList());
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(filter: p => p.ProductID == productId));
        }
        [TransactionScopeAspect]
        public IResult TransactionalOperation(Product product)
        {
            _productDal.Update(product);
            //_productDal.Add(product);
            return new SuccesResult(Messages.ProductAdded);
        }
    }
}
