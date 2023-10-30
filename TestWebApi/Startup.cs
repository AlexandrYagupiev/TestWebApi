using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using TestWebApi.Models;

namespace TestWebApi
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            string con = "Server=(localdb)\\mssqllocaldb;Database=usersdbstore;Trusted_Connection=True;MultipleActiveResultSets=true";
            services.AddDbContext<GameContext>(options => options.UseSqlServer(con));
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
