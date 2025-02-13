using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Repository.Models;
using Microsoft.Extensions.Configuration;


namespace Repository.Context
{
    public class WeatherContext : DbContext
    {
        public WeatherContext(DbContextOptions<WeatherContext> options) : base(options) { }

        DbSet<WeatherForecast> Weathers { get; set; }
        DbSet<ForecastDay> ForecastsDays { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WeatherForecast>()
                .HasMany(w => w.Forecasts)
                .WithOne(f => f.WeatherForecast)
                .HasForeignKey(f => f.IdWeatherForecast);

            base.OnModelCreating(modelBuilder);
        }

    }
}


