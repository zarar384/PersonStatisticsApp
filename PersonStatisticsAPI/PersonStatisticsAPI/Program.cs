using PersonStatisticsAPI.Extensions;
using PersonStatisticsAPI.Business.Interfaces;
using AutoMapper;
using PersonStatisticsAPI.Helpers;
using PersonStatisticsAPI.Data;
using PersonStatisticsAPI.Business.Managers;

var builder = WebApplication.CreateBuilder(args);
IConfiguration config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddEnvironmentVariables().Build();

// Mapper
MapperConfiguration mapperConfiguration = new MapperConfiguration(cfg =>
{
    cfg.AddProfile(new AutoMapperProfiles());
});

// Add framework services
builder.Services.AddTransient<IPersonManager, PersonManager>();
builder.Services.AddSingleton<IDataStore, DataStore>();
builder.Services.AddSingleton(sp => mapperConfiguration.CreateMapper());
builder.Services.AddMvc();

// Add services to the container.
builder.Services.AddAplicationServices(config);
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
