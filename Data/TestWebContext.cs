using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Learnify.Data;

public partial class TestWebContext : DbContext
{
    public TestWebContext()
    {
    }

    public TestWebContext(DbContextOptions<TestWebContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Stddatum> Stddata { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=TestWeb;User Id=postgres;Password=54321");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Stddatum>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("stddata");

            entity.Property(e => e.Modules).HasColumnName("modules");
            entity.Property(e => e.Sem).HasColumnName("sem");
            entity.Property(e => e.Subject)
                .HasMaxLength(10)
                .HasColumnName("subject");
            entity.Property(e => e.Topic)
                .HasMaxLength(50)
                .HasColumnName("topic");
            entity.Property(e => e.Ytvideo)
                .HasMaxLength(20)
                .HasColumnName("ytvideo");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
