using Microsoft.EntityFrameworkCore;
using QueensApp.Server.Models;

namespace QueensApp.Server.Properties.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Player> Players { get; set; }
        public DbSet<Score> Scores { get; set; }



        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Player>().HasData(
                new Player { Id = 1, Username = "Player1", TimeCreate = DateTime.UtcNow },
                new Player { Id = 2, Username = "Player2", TimeCreate = DateTime.UtcNow },
                new Player { Id = 3, Username = "Player3", TimeCreate = DateTime.UtcNow }
                
                );

            modelBuilder.Entity<Score>().HasData(
                new Score { Id = 100, ScoreAmount = 200, PlayerId = 3 },
                new Score { Id = 101, ScoreAmount = 500, PlayerId = 2 },
                new Score { Id = 102, ScoreAmount = 10, PlayerId = 1 }
            );
        }
    }
}
