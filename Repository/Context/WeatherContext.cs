using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Repository.Models;

namespace Repository.Context
{
    public class WeatherContext : DbContext
    {


        public WeatherContext(DbContextOptions options) : base(options) { }


        DbSet<WeatherForecast> Weathers { get; set; }
    }
}
