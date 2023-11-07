global using Microsoft.EntityFrameworkCore;

namespace Dotnetcore_seven_api.DataContext
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<SuperHero> SuperHeroes { get; set; }
    }
}
