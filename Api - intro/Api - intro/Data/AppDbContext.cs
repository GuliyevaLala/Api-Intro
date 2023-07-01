using Api___intro.Models;
using Microsoft.EntityFrameworkCore;

namespace Api___intro.Data {
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> option) : base(option)
        {
        }
        public DbSet<Country> Countries { get; set; }
    }
}
