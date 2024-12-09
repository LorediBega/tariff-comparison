using TariffComparision.API.Helpers.Extensions;
using TariffComparision.API.Helpers.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddServiceDependencies();

builder.Services.AddControllers(options =>
{
    options.Filters.Add(typeof(GlobalExceptionFilter));
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.EnableAnnotations();
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();
