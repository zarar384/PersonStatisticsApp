using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PersonStatisticsAPI.Business.Interfaces;
using PersonStatisticsAPI.Business.Managers;
using PersonStatisticsAPI.Data;
using PersonStatisticsAPI.Data.Db;
using PersonStatisticsAPI.Data.Interfaces;
using PersonStatisticsAPI.Helpers;
using PersonStatisticsAPI.Interfaces;
using PersonStatisticsAPI.Services;

namespace PersonStatisticsAPI.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddAplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<AppDbContext>(option =>
                option.UseSqlServer(config.GetConnectionString("DefaultConnection"),
                settings => settings.EnableRetryOnFailure().CommandTimeout(60)));
            services.AddCors();
            IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddSingleton(mapper);
            services.AddScoped<ITokenService, TokenService>();
            services.AddTransient<IBoxManager, PackManager>();
            services.AddScoped<IBoxRepository, BoxRepository>();
            //services.AddSingleton<IPersonRepository, PersonRepository>();
            services.AddTransient<IUserManager, UserManager>();
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }
    }
}
