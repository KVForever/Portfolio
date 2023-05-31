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
        //modelBuilder.Entity<Role>(entity =>
        //{
        //    entity.Property(e => e.DateCreated)
        //        .HasDefaultValueSql("(getdate())")
        //        .HasColumnType("datetime");
        //    entity.Property(e => e.DateModified)
        //        .HasDefaultValueSql("(getdate())")
        //        .HasColumnType("datetime");
        //    entity.Property(e => e.Name).HasMaxLength(255);
        //});

        //modelBuilder.Entity<StarRating>(entity =>
        //{
        //    entity.ToTable("StarRating");

        //    entity.Property(e => e.Why);

        //    entity.Property(e => e.DateRated).HasColumnType("date");
        //});

        //modelBuilder.Entity<User>(entity =>
        //{
        //    entity.Property(e => e.DateCreated)
        //        .HasDefaultValueSql("(getdate())")
        //        .HasColumnType("datetime");
        //    entity.Property(e => e.DateModified)
        //        .HasDefaultValueSql("(getdate())")
        //        .HasColumnType("datetime");
        //    entity.Property(e => e.Password).HasMaxLength(255);
        //    entity.Property(e => e.Salt).HasMaxLength(255);
        //    entity.Property(e => e.Username).HasMaxLength(255);

        //    entity.HasMany(d => d.Roles).WithMany(p => p.Users)
        //        .UsingEntity<Dictionary<string, object>>(
        //            "UserRole",
        //            r => r.HasOne<Role>().WithMany()
        //                .HasForeignKey("RoleId")
        //                .OnDelete(DeleteBehavior.ClientSetNull)
        //                .HasConstraintName("FK_UserRoles_Roles"),
        //            l => l.HasOne<User>().WithMany()
        //                .HasForeignKey("UserId")
        //                .OnDelete(DeleteBehavior.ClientSetNull)
        //                .HasConstraintName("FK_UserRoles_Users"),
        //            j =>
        //            {
        //                j.HasKey("UserId", "RoleId");
        //                j.ToTable("UserRoles");
        //            });
        //});

        //modelBuilder.Entity<UserMessage>(entity =>
        //{
        //    entity.Property(e => e.DateCreated)
        //    .HasDefaultValueSql("(getdate())")
        //        .HasColumnType("datetime");
        //    entity.Property(e => e.DateModified)
        //    .HasDefaultValueSql("(getdate())")
        //        .HasColumnType("datetime");
        //    entity.Property(e => e.Email).HasMaxLength(255);
        //    entity.Property(e => e.FirstName).HasMaxLength(255);
        //    entity.Property(e => e.LastName).HasMaxLength(255);
        //    entity.Property(e => e.UserMessage).HasMaxLength(255);
        //    entity.Property(e => e.Subject).HasMaxLength(255);
        //});

        //OnModelCreatingPartial(modelBuilder);
    }

    //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
