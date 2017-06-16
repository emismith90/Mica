﻿using System;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Mica.Infrastructure.IoC;
using Mica.Infrastructure.IoC.Autofac;
using Mica.Infrastructure.Logger;
using Mica.Domain.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Mica.Presentation.Web
{
    public class Startup
    {
        public IApplicationContainerManager ContainerManager { get; private set; }

        public Startup(IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                Log.Logger = new LoggerConfiguration()
                 .MinimumLevel.Is(Serilog.Events.LogEventLevel.Debug)
                 .Enrich.FromLogContext()
                 .WriteTo.Seq("http://localhost:5341")
                 .CreateLogger();
            }
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            var config = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json")
              .Build();

            // Add framework services.
            //services.AddDbContext<MicaContext>(options =>
            //    options.UseSqlServer(config.GetConnectionString("MicaConnection")));

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<MicaContext>()
                .AddDefaultTokenProviders();

            services.AddMvc();

            services.AddOptions();

            // Create the IServiceProvider based on the container.
            ContainerManager = new AutofacIoCManager();

            return ContainerManager.PopulateAndGetServiceProvider(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IMicaLogManager micaLogManager)
        {
            loggerFactory.AddSerilog(micaLogManager.CreateLogger());
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            var context = app.ApplicationServices.GetService<MicaContext>();
            if (!context.Database.EnsureCreated())
                context.Database.Migrate();

            app.UseIdentity();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
