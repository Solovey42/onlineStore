using Domain;
using Microsoft.ApplicationInsights.Extensibility.Implementation;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            string connection = Configuration.GetConnectionString("DefaultConnection");
            //services.AddDbContext<ApplicationContext>(options => options.UseNpgsql(connection)); //для запуска с PostgreSQL
            services.AddDbContext<ApplicationContext>(options => options.UseSqlite(connection)); //для запуска с SQLite
            services.AddEntityFrameworkSqlite().AddDbContext<ApplicationContext>();

            // установка конфигурации подключения
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
                });
            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();

            app.UseStaticFiles();

            app.UseRouting();


            app.UseAuthentication();    // аутентификация
            app.UseAuthorization();     // авторизация

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "Catalog",
                    pattern: "{controller=Home}/{action=Catalog}/{id?}");
                endpoints.MapControllerRoute(
                    name: "ProductList",
                    pattern: "{controller=Home}/{action=ProductList}/{id}");
                endpoints.MapControllerRoute(
                   name: "Cart",
                   pattern: "{controller=Cart}/{action=Cart}/{id}");
            });
        }
    }
}
