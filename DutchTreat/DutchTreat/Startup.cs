using DutchTreat.Data;
using DutchTreat.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DutchTreat
{
    public class Startup
    {


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DutchContext>(
            //    cfg =>
            //{
            //    cfg.UseSqlServer(_config.GetConnectionString("DutchConnectionString"));
            //}
            );
            services.AddTransient<IMailService, NullMailService>();
            services.AddTransient<DutchSeeder>();

            services.AddScoped<IDutchRepository, DutchRepository>();

            services.AddMvc();


            //services.AddRazorPages();
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
                app.UseExceptionHandler("/error");
            }

            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(cfg =>
           {
               cfg.MapControllerRoute("Default",
                   "{controller}/{action}/{id?}",
                   new { controller = "App", action = "Index" });
           });
     
        }
    }
}
