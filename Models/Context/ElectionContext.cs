using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models.Context
{
    public class ElectionContext : DbContext
    {
        public DbSet<Election> Elections { get; set; }

        public ElectionContext(DbContextOptions<ElectionContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=D662-ETHANLIM;Database=Test07;Trusted_Connection=True;TrustServerCertificate=True");
        }
    }
}
