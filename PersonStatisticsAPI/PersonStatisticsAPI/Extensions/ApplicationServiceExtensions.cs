using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PersonStatisticsAPI.Business.Interfaces;
using PersonStatisticsAPI.Business.Managers;
using PersonStatisticsAPI.Data;
using PersonStatisticsAPI.Data.Db;
using PersonStatisticsAPI.Data.Interfaces;
using PersonStatisticsAPI.Helpers;

namespace PersonStatisticsAPI.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddAplicationServices(this IServiceCollection services, IConfiguration config) 
        {
            services.AddDbContext<AppliacationDbContext>(option =>
                option.UseSqlServer(config.GetConnectionString("DefaultConnection"),
                settings => settings.EnableRetryOnFailure().CommandTimeout(60)));
            
            IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddSingleton(mapper);
            services.AddTransient<IPersonManager, PersonManager>();
            //services.AddSingleton<IPersonRepository, PersonRepository>();
            services.AddScoped<IPersonRepository, PersonRepository>();
            return services;
        }
    }
}
