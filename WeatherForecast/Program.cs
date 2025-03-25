using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Teste.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<NewsApiService>();

builder.Services.AddControllers();

builder.Services.AddDbContext<WeatherContext>(options =>
   options.UseMySql(
           builder.Configuration.GetConnectionString("MySql"),
           ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("MySql"))
       )
);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200") // Permite o Angular acessar a API
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAngular");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();