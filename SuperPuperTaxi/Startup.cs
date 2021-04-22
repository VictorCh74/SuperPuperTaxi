using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SuperPuperTaxi.Models;


namespace SuperPuperTaxi
{
    public class Startup
    { 
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddMvcCore().AddRazorViewEngine();
        
            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationContext>(options =>
               options.UseSqlServer(connection));

            services.AddTransient<IRepository, OrderRepository>();
            services.AddTransient<IDriverRepository, DriverRepository>();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}");

                routes.MapRoute(
                    name: "copyDown",
                    template: "{controller=CompleteOrder}/{action=RecordOrder}");

                routes.MapRoute(
                    name: "addDriver",
                    template: "{controller=AddDriver}/{action=AddDriver}");

                routes.MapRoute(
                    name: "removeDriver",
                    template: "{controller=RemoveDriver}/{action=Remove}");
            });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("We are glad to serve you again");
            });
        }
    }
}
