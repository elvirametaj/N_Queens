using Microsoft.EntityFrameworkCore;
using NQ.Models.Entities;

namespace NQ.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Player> Players { get; set; }
    }
}
