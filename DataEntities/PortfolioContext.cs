using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataEntities;

public partial class PortfolioContext : DbContext
{
    public PortfolioContext(DbContextOptions<PortfolioContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Users> Users { get; set; }

    public virtual DbSet<UserMessages> UserMessages { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Users>(entity =>
        {
            entity.Property(e => e.Id);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PasswordHash).IsUnicode(false);
        });

        modelBuilder.Entity<UserMessages>(entity =>
        {
            entity.Property(e => e.Id);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Message).IsUnicode(false);
            entity.Property(e => e.Subject)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
