using MediaBrowser.Model.Services;
using Microsoft.OpenApi.Models;
using PersonStatisticsAPI.Extensions;
using PersonStatisticsAPI.Middleware;
using PersonStatisticsAPI.Models.Extensions;

var builder = WebApplication.CreateBuilder(args);
IConfiguration config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddJsonFile("appsettings.development.json")
    .AddEnvironmentVariables().Build();

// Add services to the container.
builder.Services.AddAplicationServices(config);
builder.Services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Converters.Add(new DateOnlyJsonConverter());
                });
builder.Services.AddCors();
builder.Services.AddIdentityServices(config);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPIv5", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMiddleware<ExceptionMiddleware>();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPIv5 v1"));
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors(x => x
    .AllowAnyHeader()
    .AllowAnyMethod()
    .SetIsOriginAllowed(origin =>
    {
        var allowedOrigins = new List<string> { "http://localhost:4200" };
        return allowedOrigins.Contains(origin);
    }
    )
    .AllowCredentials());
// .WithOrigins("https://localhost:4200"));


app.UseAuthentication();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

//app.UsePacktHeaderValidator();

app.Run();
