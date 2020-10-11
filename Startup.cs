using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppDemo.Data.Repository;
using AppDemo.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace AppDemo
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //Mapping Repositorios
            services.AddScoped<IRepository<Jogos>, Repository<Jogos>>();

            services.AddScoped<IJogosRepository, JogosRepository>();

            services.AddScoped<localContext>();

            // Configurando o acesso a dados
            services.AddDbContext<localContext>(options =>
                options.UseSqlServer("Server=127.0.0.1;Database=local;User Id=teste;Password=123456;MultipleActiveResultSets=true"));

            services.AddMvc(options => options.EnableEndpointRouting = false)
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                .AddJsonOptions(options => options.JsonSerializerOptions.IgnoreNullValues = true);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            var locOptions = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();

            app.UseRequestLocalization(locOptions.Value);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            //Using static files
            app.UseStaticFiles();
            app.UseRouting();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("", async context =>
            //    {
            //        context.Response.Redirect("Pontos/#/app/dashboard");
            //    });
            //});

            app.UseMvc();
            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "default", template: "{controller=Pontos}/{action=Index}/{id?}");
                //routes.MapSpaFallbackRoute(name: "spa-fallback", defaults: new { controller = "Home", action = "Index" });
            });
            //app.UseMvc(routes =>
            //{
            //    routes.MapAreaRoute(name: "default", areaName: "Pontos", template: "{controller=Pontos}/{action=Index}/{id?}");
            //    //routes.MapSpaFallbackRoute(name: "spa-fallback", defaults: new { controller = "Home", action = "Index" });
            //});
        }
    }
}
