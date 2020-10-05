using Application.Services;
using Domain.Services;
using Domain.UnitOfWorks;
using Domain.UnitOfWorks.Repositories;
using Infrastructure.UnitOfWorks.EFCore;
using Infrastructure.UnitOfWorks.EFCore.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Api
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
            // Database
            services.AddDbContext<SeriesListContext>(
                options => options.UseSqlite("Data Source=serieslist.db"));


            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ISerieRepository, SerieRepository>();
            services.AddScoped<ISerieService, SerieService>();


            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
