using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DataEntities;

public partial class PortfolioContext : DbContext
{
    public PortfolioContext(DbContextOptions<PortfolioContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<StarRating> StarRatings { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserMessage> UserMessages { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Role>().ToTable("Role");
        modelBuilder.Entity<StarRating>().ToTable("StarRating");
        modelBuilder.Entity<User>().ToTable("User");
        modelBuilder.Entity<UserMessage>().ToTable("UserMessage");
    }

    
}
