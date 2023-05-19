using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DostavkaFood;

public partial class DostavkaContext : DbContext
{
    public DostavkaContext()
    {
    }

    public DostavkaContext(DbContextOptions<DostavkaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Food> Foods { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\DostavkaFood\\Dostravka.mdf;Integrated Security=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.IdClient);

            entity.Property(e => e.Address).HasColumnType("text");
            entity.Property(e => e.Fio)
                .HasColumnType("text")
                .HasColumnName("FIO");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(13)
                .IsFixedLength();
        });

        modelBuilder.Entity<Food>(entity =>
        {
            entity.HasKey(e => e.IdFood);

            entity.ToTable("Food");

            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsFixedLength();
            entity.Property(e => e.Note).HasColumnType("text");
            entity.Property(e => e.Type)
                .HasMaxLength(15)
                .IsFixedLength();
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.IdOrder);

            entity.HasOne(d => d.IdClientNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdClient)
                .HasConstraintName("Orders_Clients");

            entity.HasOne(d => d.IdFoodNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdFood)
                .HasConstraintName("Orders_Food");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
