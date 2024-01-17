﻿using Microsoft.EntityFrameworkCore;
using Nqueens.Models.Entities;

namespace Nqueens.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Player> Players { get; set; }
    }
}
