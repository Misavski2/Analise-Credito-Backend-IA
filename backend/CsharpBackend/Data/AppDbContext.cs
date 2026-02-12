using CsharpBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace CsharpBackend.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<AnaliseCredito> AnaliseCreditos { get; set; }
        public DbSet<AnaliseCredito> Analises { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        { 
        }

        internal async Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
