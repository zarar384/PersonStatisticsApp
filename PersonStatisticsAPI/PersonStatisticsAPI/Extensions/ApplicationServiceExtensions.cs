using Microsoft.EntityFrameworkCore;
using PersonStatisticsAPI.Db;

namespace PersonStatisticsAPI.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddAplicationServices(this  IServiceCollection services, IConfiguration config) 
        {
            services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(config.GetConnectionString("DefaultConnection")));
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            return services;
        }
    }
}
