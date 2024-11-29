using Microsoft.EntityFrameworkCore;
using SeasonalStory;
using SeasonalStory.EFDbContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<SSDbContext>();

builder.Services.AddScoped<TemperatureRepo>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
