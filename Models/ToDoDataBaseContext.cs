using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MyToDoApp.Models;

public partial class ToDoDataBaseContext : DbContext
{
    public ToDoDataBaseContext()
    {
    }

    public ToDoDataBaseContext(DbContextOptions<ToDoDataBaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Ttask> Ttasks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost,1433;Database=ToDoDataBase;User Id=ToDoApi;Password=Parola2024;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ttask>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Ttask__3213E83F8D552E6B");

            entity.ToTable("Ttask");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cover).HasColumnName("cover");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("datetime")
                .HasColumnName("deleted_at");
            entity.Property(e => e.Description)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Observations)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("observations");
            entity.Property(e => e.Title)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("title");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
