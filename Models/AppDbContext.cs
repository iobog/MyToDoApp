using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MyToDoApp.Models;

public partial class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TTask> TTasks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TTask>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TTask__3214EC07438F5A01");

            entity.ToTable("TTask");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DeletedAt).HasColumnType("datetime");
            entity.Property(e => e.Description)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.IsCompleted).HasDefaultValue(false);
            entity.Property(e => e.Notes)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Title)
                .HasMaxLength(250)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
