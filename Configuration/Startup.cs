using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Configuration
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public Startup()
        {
            var builder = new ConfigurationBuilder().AddInMemoryCollection(
                new Dictionary<string, string>
                {
                    {"firstname", "Tom" },
                    {"lastname", "Simpson" }
                });
            AppConfiguration = builder.Build();
        }
        public IConfiguration AppConfiguration { get; set; }
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            AppConfiguration["age"] = "19";
            app.Run(async context =>
            {
                await context.Response.WriteAsync($"firstname {AppConfiguration["firstname"]}, lastname {AppConfiguration["lastname"]}, age {AppConfiguration["age"]}");
            });
        }
    }
}
