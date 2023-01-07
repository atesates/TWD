using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWD.Core.Utilities.IoC;
using TWD.Core.CrossCuttingConcerns.Caching;
using TWD.Core.CrossCuttingConcerns.Caching.Microsoft;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;

namespace TWD.Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddSingleton<ICacheManager, MemoryCacheManager>();//When we change MemoryCacheManager, it means we will be changed cache infrastructure for example Redis
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();//to use claims in core and business layer, because there are api environent in this project
            services.AddSingleton<Stopwatch>();



        }
    }
}
