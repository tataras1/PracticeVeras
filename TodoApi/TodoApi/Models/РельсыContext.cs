using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TodoApi.Models;

public partial class РельсыContext : DbContext
{
    public РельсыContext()
    {
    }

    public РельсыContext(DbContextOptions<РельсыContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Ведомости> Ведомостиs { get; set; }

    public virtual DbSet<ВидыДефектов> ВидыДефектовs { get; set; }

    public virtual DbSet<Марки> Маркиs { get; set; }

    public virtual DbSet<Места> Местаs { get; set; }

    public virtual DbSet<ПеречниПродукции> ПеречниПродукцииs { get; set; }

    public virtual DbSet<ПеречниХарактеристик> ПеречниХарактеристикs { get; set; }

    public virtual DbSet<Продукция> Продукцияs { get; set; }

    public virtual DbSet<Профили> Профилиs { get; set; }

    public virtual DbSet<ТаблицаДефектов> ТаблицаДефектовs { get; set; }

    public virtual DbSet<ТипыВедомости> ТипыВедомостиs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\;Database=Рельсы;User=Tataras1;pwd=nimda; TrustServerCertificate=True; Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ведомости>(entity =>
        {
            entity.HasKey(e => e.ВедомостьId).HasName("PK_Ведомость");

            entity.ToTable("Ведомости");

            entity.Property(e => e.ВедомостьId).HasColumnName("ВедомостьID");
            entity.Property(e => e.ДатаВремя).HasColumnType("datetime");
            entity.Property(e => e.Ответственные)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.МестоФормированияNavigation).WithMany(p => p.Ведомостиs)
                .HasForeignKey(d => d.МестоФормирования)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Ведомости_Места");

            entity.HasOne(d => d.ТипВедомостиNavigation).WithMany(p => p.Ведомостиs)
                .HasForeignKey(d => d.ТипВедомости)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Ведомости_ТипыВедомости");
        });

        modelBuilder.Entity<ВидыДефектов>(entity =>
        {
            entity.ToTable("ВидыДефектов");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Вид)
                .HasMaxLength(40)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Марки>(entity =>
        {
            entity.ToTable("Марки");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Марка)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Места>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Место");

            entity.ToTable("Места");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Место)
                .HasMaxLength(25)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ПеречниПродукции>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ПеречниПродукции");

            entity.HasOne(d => d.ВедомостьNavigation).WithMany()
                .HasForeignKey(d => d.Ведомость)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Перечни_Ведомости");

            entity.HasOne(d => d.ПродукцияNavigation).WithMany()
                .HasForeignKey(d => d.Продукция)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Перечни_Продукция");
        });

        modelBuilder.Entity<ПеречниХарактеристик>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ПеречниХарактеристик");

            entity.Property(e => e.Значение)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Ключ)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ПродукцияId).HasColumnName("ПродукцияID");

            entity.HasOne(d => d.Продукция).WithMany()
                .HasForeignKey(d => d.ПродукцияId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_ПеречниХарактеристик_Продукция");
        });

        modelBuilder.Entity<Продукция>(entity =>
        {
            entity.ToTable("Продукция");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Клеймо)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.МаркаСтали).HasColumnName("Марка_стали");

            entity.HasOne(d => d.МаркаСталиNavigation).WithMany(p => p.Продукцияs)
                .HasForeignKey(d => d.МаркаСтали)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Продукция_Марки");

            entity.HasOne(d => d.ПрофильNavigation).WithMany(p => p.Продукцияs)
                .HasForeignKey(d => d.Профиль)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Продукция_Профили");
        });

        modelBuilder.Entity<Профили>(entity =>
        {
            entity.ToTable("Профили");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Профиль)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ТаблицаДефектов>(entity =>
        {
            entity.HasKey(e => e.ДефектId);

            entity.ToTable("ТаблицаДефектов");

            entity.Property(e => e.ДефектId).HasColumnName("ДефектID");
            entity.Property(e => e.ДлинаДефекта).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ПродукцияId).HasColumnName("ПродукцияID");

            entity.HasOne(d => d.ВидNavigation).WithMany(p => p.ТаблицаДефектовs)
                .HasForeignKey(d => d.Вид)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_ТаблицаДефектов_ВидыДефектов");

            entity.HasOne(d => d.Продукция).WithMany(p => p.ТаблицаДефектовs)
                .HasForeignKey(d => d.ПродукцияId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_ТаблицаДефектов_Продукция");
        });

        modelBuilder.Entity<ТипыВедомости>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_ТипВедомости");

            entity.ToTable("ТипыВедомости");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ТипВедомости)
                .HasMaxLength(8)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
