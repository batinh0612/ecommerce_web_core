using System;
using AutoMapper;
using Ecommerce.ApiIntegration;
using Ecommerce.ApiIntegration.Interfaces;
using Ecommerce.Domain;
using Ecommerce.Repository;
using Ecommerce.Repository.Common;
using Ecommerce.Repository.Interfaces;
using Ecommerce.Service.Interface;
using Ecommerce.Service.Services;
using EcommerceCommon.Utilities.Configurations;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Ecommerce.Admin
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
            });

            services.AddControllersWithViews().AddRazorRuntimeCompilation();

            services.AddHttpClient();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
            {
                options.LoginPath = "/Login/Index/";
                options.AccessDeniedPath = "/User/Forbidden/";
            });

            services.AddAutoMapper(typeof(Ecommerce.Core.ViewModels.MappingProfile));

            //inject repository,service
            ConfigureCoreAndRepositoryService(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Login}/{action=Index}/{id?}");
            });
        }

        /// <summary>
        /// Dependency Injection
        /// </summary>
        /// <param name="services"></param>
        private void ConfigureCoreAndRepositoryService(IServiceCollection services)
        {
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();

            services.AddTransient(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddTransient(typeof(IServices<>), typeof(EcommerceServices<>));

            services.AddTransient<IDashboardService, DashboardService>();
            services.AddTransient<IStorageRepository, StorageRepository>();

            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IOrderService, OrderService>();

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserService, UserService>();

            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IProductSevice, ProductService>();

            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<ICategoryService, CategoryService>();

            services.AddTransient<ISupplierRepository, SupplierRepository>();
            services.AddTransient<ISupplierService, SupplierService>();

            services.AddTransient<IManufactureRepository, ManufactureRepository>();
            services.AddTransient<IManufactureService, ManufactureService>();

            services.AddTransient<ILanguageRepository, LanguageRepository>();
            services.AddTransient<ILanguageService, LanguageService>();

            services.AddTransient<IUserApiClient, UserApiClient>();
            services.AddTransient<ISupplierApiClient, SupplierApiClient>();
            services.AddTransient<IManufactureApiClient, ManufactureApiClient>();

            services.AddSingleton<Tokens>();
        }
    }
}
