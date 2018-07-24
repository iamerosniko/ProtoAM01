using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;

namespace BusinessWorkflow
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static IConfiguration Configuration { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSession();
            services.AddMvc()
                 .AddJsonOptions(o =>
                 {
                     if (o.SerializerSettings.ContractResolver != null)
                     {
                         var castedResolver = o.SerializerSettings.ContractResolver
                                 as DefaultContractResolver;
                         castedResolver.NamingStrategy = null;
                     }
                 });
            services.AddCors(options =>
            {
                options.AddPolicy("CORS",
                corsPolicyBuilder => corsPolicyBuilder.AllowAnyOrigin()
                // Apply CORS policy for any type of origin
                .AllowAnyMethod()
                // Apply CORS policy for any type of http methods
                .AllowAnyHeader()
                // Apply CORS policy for any headers
                .AllowCredentials());
                // Apply CORS policy for all users
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSession();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("CORS");

            app.UseMvc();
        }
    }
}
