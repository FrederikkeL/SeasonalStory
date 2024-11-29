using SeasonalStory;

var builder = WebApplication.CreateBuilder(args);

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://127.0.0.1:5500",
                                              "http://localhost:5500").AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                      });
});

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddSingleton<PhotosRepo>(new PhotosRepo());

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
