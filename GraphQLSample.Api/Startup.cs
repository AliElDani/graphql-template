using GraphiQl;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using GraphQLSample.Storage.SqlServer;
using GraphQLSample.Api.Infrastructure;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace GraphQLSample
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
            services
            .AddMvc()
            .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddApiServices(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostEnvironment env, IMigrationsRunner migrationsRunner)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseGraphiQl("/graphql/users");
            app.UseMvc();
            app.UseHttpsRedirection();
            
            migrationsRunner.Run();
        }
    }
}
