using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FavFay.Models;

namespace FavFay
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //projeye mvc dahil ediliyor
            services.AddControllersWithViews();

            //db
            services.AddDbContext<Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnect")));

            //session
            services.AddSession();
            services.AddDistributedMemoryCache();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles(); //www klasörünü açtýk
            //Burada kullanýcýya http response gönderiyoruz. Belli ara yazýlýmlarý süreç içine burdan dahil edebilirsin.
            app.UseRouting();
            app.UseSession();
      
            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllerRoute(
                    name:"default",
                    pattern: "{controller=Account}/{action=Anonymous}/{id?}"
                    );
            });

        }

        
    }
}
