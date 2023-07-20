using Microsoft.EntityFrameworkCore;
using PersonStatisticsAPI.Db;

namespace PersonStatisticsAPI.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddAplicationServices(this  IServiceCollection services, IConfiguration config) 
        {
            services.AddDbContextPool<AppDbContext>(option =>
                option.UseSqlServer(config.GetConnectionString("DefaultConnection"),
                settings => settings.EnableRetryOnFailure().CommandTimeout(60)));
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            return services;
        }
    }
}
