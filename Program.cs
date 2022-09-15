global using DataAccess;
global using Microsoft.EntityFrameworkCore;
global using WebApi.Services;
global using WebApi.Helpers;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddDbContext<DataContext>(options =>
{
  options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<AccountService>();
builder.Services.AddScoped<ArticleService>();
builder.Services.AddScoped<ImageService>();
builder.Services.AddScoped<JwtUtils>();

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddLogging();

builder.Services.AddCors(options =>
{
  options.AddPolicy(name: "*",
                    policy =>
                    {
                      policy.WithOrigins("http://localhost:3001").AllowAnyHeader().AllowAnyMethod();
                    });
});

builder.Services.AddResponseCaching();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
  app.UseCors(builder => {
    builder.AllowAnyHeader();
    builder.AllowAnyMethod();
    builder.AllowAnyOrigin();
    builder.AllowAnyMethod();
  });
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run("http://localhost:8080");

