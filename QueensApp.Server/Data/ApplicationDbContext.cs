using Microsoft.EntityFrameworkCore;
using QueensApp.Server.Models;

namespace QueensApp.Server.Properties.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Score> Scores { get; set; }



        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Username = "Player1", TimeCreate = new DateTime() },
                new User { Id = 2, Username = "Player2", TimeCreate = new DateTime() },
                new User { Id = 3, Username = "Player3", TimeCreate = new DateTime() }
                
                );

            modelBuilder.Entity<Score>().HasData(
                new Score { Id = 100, ScoreAmount = 200, UserId = 3 },
                new Score { Id = 101, ScoreAmount = 500, UserId = 2 },
                new Score { Id = 102, ScoreAmount = 10, UserId = 1 }
            );
        }
    }
}
