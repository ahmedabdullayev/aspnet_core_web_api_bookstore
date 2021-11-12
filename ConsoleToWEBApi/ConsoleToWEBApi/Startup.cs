using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ConsoleToWEBApi
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddTransient<CustomMiddleware>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

           // app.UseMiddleware<CustomMiddleware>();
            
            // app.Use(async (context, next) =>
            // {
            //     await context.Response.WriteAsync("hello from use 1 \n");
            //     await next();
            // });
            //
            //  app.Map("/ahab", CustomCode);
            //  
            //  app.Use(async (context, next) =>
            //  {
            //      await context.Response.WriteAsync(" keke \n");
            //  });
            //
           

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void CustomCode(IApplicationBuilder app)
        {
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("hello path middleware \n");
            });
        }
    }
}