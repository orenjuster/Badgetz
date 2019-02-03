using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Badgetz.Definition.Entities;
using Badgetz.Definition.Model.Entities;
using Badgetz.Definition.Model.Repositories;
using Badgetz.Definition.MongoRepository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Badgetz.Definition.WebService
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddScoped<IBadgetDefinitionConfigurationRepository, BadgetDefinitionConfigurationMongoRepository>();
            services.AddScoped<IBadgetDefinitionRepository, BadgetDefinitionMongoRepository>();
            services.AddTransient<IBadgetDefinitionFactory, BadgetDefinitionFactory>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
