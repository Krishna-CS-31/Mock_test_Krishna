using Microsoft.EntityFrameworkCore;
using PracWebApi.Controllers;
using PracWebApi.Models;

namespace PracWebApi.Data
{
    public class ApplicationDbContext:DbContext
    {
       public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<WeatherForecast> WeatherForecasts { get; set; }

        public DbSet<MarvelComics> Comics { get; set; }

    }
}
