using AutoMapper;
using Gaurav.Practical.API.IRepository;
using Gaurav.Practical.API.IService;
using Gaurav.Practical.API.Middleware;
using Gaurav.Practical.API.Repository;
using Gaurav.Practical.API.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.PlatformAbstractions;
using System;

namespace Gaurav.Practical.API
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.IgnoreNullValues = true);

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            #region Add DI
            services.AddScoped<IColorService, ColorService>();
            services.AddScoped<IColorRepository, ColorRepository>();
            #endregion

            // Register the swagger generator, defining swagger documents
            services.AddSwaggerGen(c => 
            {
                c.SwaggerDoc(name: "v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "My API", Version = "v1" });

                // Determine base path for the application.
                var basePath = PlatformServices.Default.Application.ApplicationBasePath;

                //Set the comments path for the swagger json and ui.
                c.IncludeXmlComments(basePath + "\\Gaurav.Practical.API.xml");
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // enable middleware to server generated swagger as a JSON endpoint
            app.UseSwagger();

            // enable middleware to serve swagger-ui
            app.UseSwaggerUI(c => 
            {
                c.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: "My API V1");
            });

            app.UseRouting();

            // global cors policy
            app.UseCors(x => x
                .SetIsOriginAllowed(origin => true)
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());

            // global error handler
            app.UseMiddleware<ErrorHandlerMiddleware>();

            app.UseStaticFiles();

            app.UseEndpoints(x => x.MapControllers());
        }
    }
}
