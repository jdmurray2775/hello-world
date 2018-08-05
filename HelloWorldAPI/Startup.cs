using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using HelloWorldAPI.Models;
using HelloWorldAPI.Interfaces;

namespace HelloWorldAPI
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<HelloWorldContext>(opt =>
                opt.UseInMemoryDatabase("HelloWorld"));
            services.AddMvc()
                    .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddScoped<IHelloWorldRepository, HelloWorldRepository>();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseMvc();
        }
    }
}