using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWD.Core.CrossCuttingConcerns.Caching;
using TWD.Core.Utilities.Interceptors;
using TWD.Core.Utilities.IoC;

namespace TWD.Core.CrossCuttingConcerns.Aspects.Autofac.Caching
{
    public class CacheAspect : MethodInterception
    {
        private int _duration;
        private ICacheManager _cacheManager;// memoryCacheManager or redis ..

        public CacheAspect(int duration = 60)//default 60 minutes
        {
            _duration = duration;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        public override void Intercept(IInvocation invocation)
        {
            var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");//(ProductManager.GetByCategory(categoryId,1))
            //{invocation.Method.ReflectedType.FullName} => class name
            //{invocation.Method.Name} => method name (GetCategory())           
            var arguments = invocation.Arguments.ToList();
            var key = $"{methodName}({string.Join(separator: ",", values: arguments.Select(x => x?.ToString() ?? "<Null>"))})";//GetCategory(categoryId, 1)
            if (_cacheManager.IsAdd(key))
            {//if key added in cache before
                invocation.ReturnValue = _cacheManager.Get(key);
                return;
            }
            invocation.Proceed();
            _cacheManager.Add(key, invocation.ReturnValue, _duration);//add to cache
        }
    }
}
