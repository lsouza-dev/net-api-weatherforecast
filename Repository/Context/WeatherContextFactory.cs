using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Repository.Context
{
    public class WeatherContextFactory : IDesignTimeDbContextFactory<WeatherContext>
    {
        public WeatherContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../WeatherForecast"))
                .AddJsonFile("appsettings.json",optional: false,reloadOnChange: true)
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<WeatherContext>();
            var connectionString = configuration.GetConnectionString("MySql");

            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

            return new WeatherContext(optionsBuilder.Options);
        }
    }
}
