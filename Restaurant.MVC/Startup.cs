using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Restaurant.Core.BusinessLayer;
using Restaurant.Core.Interfaces;
using Restaurant.EF;
using Restaurant.EF.RepositoryEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.MVC
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
            services.AddControllersWithViews();

            services.AddScoped<IBusinessLayer, MainBusinessLayer>();

            services.AddScoped<IDishRepository, DishRepositoryEF>();
            services.AddScoped<IMenùRepository, MenùRepositoryEF>();
            services.AddScoped<IUserRepository, UserRepositoryEF>();

            services.AddDbContext<RestaurantContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("EFConnection"));
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(option =>
                {
                    option.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Users/Login");
                    option.AccessDeniedPath = new Microsoft.AspNetCore.Http.PathString("/Users/Forbidden");
                });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Manager", policy => policy.RequireRole("Manager"));
                options.AddPolicy("Client", policy => policy.RequireRole("Client"));
            });
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

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
