using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataEntities;

public partial class PortfolioMessagesContext : DbContext
{
    public PortfolioMessagesContext(DbContextOptions<PortfolioMessagesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<UserMessage> UserMessages { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserMessage>(entity =>
        {
            entity.ToTable("UserMessage");

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
