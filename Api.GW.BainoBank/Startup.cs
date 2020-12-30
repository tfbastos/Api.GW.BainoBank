using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Api.GW.BainoBank.ClientsApi;
using Api.GW.BainoBank.Interface;
using Api.GW.BainoBank.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Api.GW.BainoBank
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSwaggerGen(options =>
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "API.GW.Bank", Version = "v1" }));

            services.AddHttpClient<BainoBankApi>(client =>
            {
                client.BaseAddress = new Uri(Configuration.GetSection(Path.BASE.ToString()).Value);
            });
        }


        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
                   c.SwaggerEndpoint("/swagger/v1/swagger.json", "API.GW.Bank"));

            //app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
