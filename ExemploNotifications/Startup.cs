using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExemploNotifications.Domain.Services;
using ExemploNotifications.Domain.Services.Abstraction;
using Marraia.Notifications.Configurations;
using Marraia.Notifications.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace ExemploNotifications
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
            services.AddControllers();

            services.AddSwaggerGen(c => {

                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "ExexmploNotification",
                        Version = "v1",
                        Description = "ExexmploNotification",
                        Contact = new OpenApiContact
                        {
                            Name = "Fernando Mendes",
                            Url = new Uri("https://github.com/marraia")
                        }
                    });
            });

            services.AddSmartNotification();
            services.AddScoped<IStudentDomainService, StudentDomainService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ExexmploNotification");
            });
        }
    }
}
