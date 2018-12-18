using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentHealth.Core.Services;
using FluentHealth.Data;
using FluentHealth.Data.Repositories;
using FluentHealth.Data.Repositories.Core;
using FluentHealth.Services.Storage;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FluentHealth.Web
{
    public class Startup
    {
        private readonly IConfigurationRoot _configurationRoot;
        private readonly IHostingEnvironment _hostingEnvironment;

        public Startup(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
            _configurationRoot = new ConfigurationBuilder()
                .SetBasePath(hostingEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .Build();
            
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<EFDBContext>(options =>
            {
                options.UseSqlServer(_configurationRoot.GetConnectionString("FluentHealthDB_CSI"));
            }, ServiceLifetime.Singleton);

            services.AddScoped<IFilesStorage>(f => new LocalStorage(_hostingEnvironment.ContentRootPath, null));
           
            //TO DO - remove
            services.Configure<FormOptions>(c =>
            {
                c.ValueLengthLimit = int.MaxValue;
                c.MultipartBodyLengthLimit = int.MaxValue;
            });

            ConfigureRepositories(services);

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
        }


        private void ConfigureRepositories(IServiceCollection services)
        {
            services
                .AddScoped<IFilesRepository, EFFilesRepository>()
                .AddScoped<IDiseasesRepository, EFDiseasesRepository>()
                .AddScoped<IPersonsRepository, EFPersonsRepository>()
                .AddScoped<ISymptomsRepository, EFSymptomsRepository>()
                .AddScoped<IDiagnosesRepositories, EFDiagnosesRepositories>();
        }
    }
}
