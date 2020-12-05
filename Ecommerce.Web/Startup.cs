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

namespace Ecommerce.Web
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
            services.AddDbContext<ApplicationDbContext>(options =>
               options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
            {
                options.Cookie.Name = "UserLoginCookie"; // Name of cookie     
                options.LoginPath = "/Login/Index"; // Path for the redirect to user login page    
                options.AccessDeniedPath = "/Login/UserAccessDenied";
            });

            services.AddControllersWithViews().AddRazorRuntimeCompilation();

            services.AddHttpClient();
            
            services.AddAutoMapper(typeof(Ecommerce.Core.ViewModels.MappingProfile));

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
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        private void ConfigureCoreAndRepositoryService(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddTransient<IProductApiClient, ProductApiClient>();
            services.AddTransient<IStorageRepository, StorageRepository>();
            services.AddTransient<IUserApiClient, UserApiClient>();

            services.AddTransient(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddTransient(typeof(IServices<>), typeof(EcommerceServices<>));
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<ICategoryService, CategoryService>();

            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IProductSevice, ProductService>();

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserService, UserService>();

            services.AddTransient<IRoleRepository, RoleRepository>();
            services.AddTransient<IRoleServices, RoleService>();

            services.AddTransient<Tokens>();

        }
    }
}
