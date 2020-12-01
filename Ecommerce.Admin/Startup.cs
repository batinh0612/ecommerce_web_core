using System;
using System.Security.Claims;
using AutoMapper;
using Ecommerce.Admin.CustomHandler;
//using Ecommerce.Admin.CustomHandler;
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
using Microsoft.AspNetCore.Authorization;
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

            //services.AddHttpContextAccessor();

            services.AddControllersWithViews().AddRazorRuntimeCompilation();

            services.AddHttpClient();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
            {
                options.Cookie.Name = "UserLoginCookie"; // Name of cookie     
                options.LoginPath = "/Login/Index"; // Path for the redirect to user login page    
                options.AccessDeniedPath = "/Login/UserAccessDenied";
            });

            services.AddAuthorization(config =>
            {
                config.AddPolicy("UserPolicy", policyBuilder =>
                {
                    policyBuilder.UserRequireCustomClaim(ClaimTypes.Email);
                    //policyBuilder.UserRequireCustomClaim(ClaimTypes.DateOfBirth);
                });
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

            Endpoints(app);
        }

        /// <summary>
        /// Dependency Injection
        /// </summary>
        /// <param name="services"></param>
        private void ConfigureCoreAndRepositoryService(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

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

            services.AddTransient<IRoleRepository, RoleRepository>();
            services.AddTransient<IRoleServices, RoleService>();

            services.AddTransient<ISupplierRepository, SupplierRepository>();
            services.AddTransient<ISupplierService, SupplierService>();

            services.AddTransient<IManufactureRepository, ManufactureRepository>();
            services.AddTransient<IManufactureService, ManufactureService>();

            services.AddTransient<ILanguageRepository, LanguageRepository>();
            services.AddTransient<ILanguageService, LanguageService>();

            services.AddTransient<IUserApiClient, UserApiClient>();
            services.AddTransient<ISupplierApiClient, SupplierApiClient>();
            services.AddTransient<IManufactureApiClient, ManufactureApiClient>();

            services.AddTransient<Tokens>();

            services.AddScoped<IAuthorizationHandler, PoliciesAuthorizationHandler>();
            services.AddScoped<IAuthorizationHandler, RolesAuthorizationHandler>();
        }

        private void Endpoints(IApplicationBuilder app)
        {
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "Product details",
                    pattern: "/product-details/{id}",
                    new
                    {
                        controller = "Product",
                        action = "Details"
                    });

                endpoints.MapControllerRoute(
                    name: "Supplier details",
                    pattern: "/supplier-details/{id}",
                    new
                    {
                        controller = "Supplier",
                        action = "Details"
                    });

                endpoints.MapControllerRoute(
                    name: "Manufacture details",
                    pattern: "/manufacture-details/{id}",
                    new
                    {
                        controller = "Manufacture",
                        action = "Details"
                    });

                endpoints.MapControllerRoute(
                   name: "Edit user",
                   pattern: "/edit-user/{id}",
                   new
                   {
                       controller = "User",
                       action = "Edit"
                   });

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Login}/{action=Index}/{id?}");
            });
        }
    }
}
