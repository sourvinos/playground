using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Playground.Implementations;
using Playground.Interfaces;

namespace Playground
{
    public class Startup
    {
        IConfigurationRoot Configuration;

        public Startup(IHostingEnvironment env)
        {
            Configuration = new ConfigurationBuilder().SetBasePath(env.ContentRootPath).AddJsonFile("appSettings.json").Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<PlaygroundContext>(options => options.UseSqlServer(Configuration.GetConnectionString("playgroundConnection")));
            services.AddDistributedMemoryCache();
            services.AddMvc();
            services.AddTransient<IClock, Clock>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseStaticFiles();
            app.UseDeveloperExceptionPage();
            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "areaRoute",
                template: "{area:exists}/{controller=home}/{action=index}");

                routes.MapRoute(
                name: "default",
                template: "{controller=home}/{action=index}");
            });
        }
    }
}
