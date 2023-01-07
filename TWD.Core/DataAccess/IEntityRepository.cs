using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using TWD.Core.Entities;

namespace TWD.Core.DataAccess
{
    public interface IEntityRepository<T> where T:class, IEntity, new()
        //IEntity db object, T is a class but with new(), there shouldn't be an interface
    {
        T Get(Expression<Func<T, bool>> filter = null);//Get(filter: p => p.CategoryID == categoryId))

        List<T> GetList(Expression<Func<T, bool>> filter = null);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}
