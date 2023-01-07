using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TWD.Northwind.BLL.Abstract;
using TWD.Northwind.BLL.Concrete;
using TWD.Northwind.DAL.Abstract;
using TWD.Northwind.DAL.Concrete.EntityFramework;
using TWD.Northwind.MVCUI.Entities;
using TWD.Northwind.MVCUI.Middlewares;
using TWD.Northwind.MVCUI.Services;

namespace TWD.Northwind.MVCUI
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            //We use autofac to do dependancy injections

           /* //services.AddSingleton => one object is created for everybody (Database)
            //services.AddTransient => one object is created for every calls
            //services.AddScoped  => one object is created for a caller
            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<IProductDal, EfProductDal>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICategoryDal, EfCategoryDal>();
            services.AddSingleton<ICartSessionService, CartSessionManager>();
            services.AddScoped<ICartService, CartManager>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();*/

            //services.AddSingleton<CrossCuttingConcerns.Logging.ILogger, Logger>();
            //services.AddSingleton<CrossCuttingConcerns.Cahching.ICache, CacheService>();

            services.AddDbContext<CustomIdentityDbContext>
               (options => options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Northwind;Trusted_Connection=true"));
            services.AddIdentity<CustomIdentityUser, CustomIdentityRole>()
                .AddEntityFrameworkStores<CustomIdentityDbContext>()
                .AddDefaultTokenProviders();

            


            services.AddSession();
            services.AddDistributedMemoryCache();
            services.AddMvc();
            //try
            services.AddMvc(option => option.EnableEndpointRouting = false);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
           // loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseFileServer();
            app.UseStaticFiles();//package managing

            app.UseNodeModules(env.ContentRootPath);
           // app.UseIdentity();
            app.UseSession();

            //app.UseMvcWithDefaultRoute();//go to url HomeController/Index
            // app.UseMvc(ConfigureRoutes);//.Net Core 2.1
              
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}");
            });



            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});
        }
        public void ConfugireServices(IServiceCollection services)
        {
            services.AddMvc(option => option.EnableEndpointRouting = false);
            services.AddOptions();
        }
        private void ConfigureRoutes(IRouteBuilder routeBuilder)
        {
            //Home/Index
            routeBuilder.MapRoute("Default", "{controller=Product}/{action=Index}/{id?}");
        }
    }
}
