using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TWD.Core.Utilities.IoC
{
    public static class ServiceTool//to reach serviceProvider of.Net Core 
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        public static IServiceCollection Create(IServiceCollection services)
        {
            ServiceProvider = services.BuildServiceProvider();//in startup  in public void ConfigureServices(IServiceCollection services) there would be same
            return services;
        }
    }
}
