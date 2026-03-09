using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DapperDb.AppDbContextModels;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<Contact> Contacts { get; set; }

    public virtual DbSet<Major> Majors { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=dapperDb;User ID=sa;Password=DataC0Ntr0ll3r;Encrypt=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Class>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Class__3214EC07925323A8");

            entity.ToTable("Class");

            entity.Property(e => e.ClassCode).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Contact>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Contact__3214EC072219E636");

            entity.ToTable("Contact");

            entity.Property(e => e.Address).HasMaxLength(100);
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.StudentId).HasColumnName("StudentID");

            entity.HasOne(d => d.Student).WithMany(p => p.Contacts)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK_Contact_Student");
        });

        modelBuilder.Entity<Major>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Major__3214EC07EDCBAD35");

            entity.ToTable("Major");

            entity.Property(e => e.MajorCode).HasMaxLength(10);
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Product__B40CC6EDBA3C4227");

            entity.ToTable("Product");

            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.ProductCode).HasMaxLength(10);
            entity.Property(e => e.ProductName).HasMaxLength(100);
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Student__3214EC072B589831");

            entity.ToTable("Student");

            entity.Property(e => e.ClassId).HasColumnName("ClassID");
            entity.Property(e => e.MajorId).HasColumnName("MajorID");
            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(d => d.Class).WithMany(p => p.Students)
                .HasForeignKey(d => d.ClassId)
                .HasConstraintName("FK_Student_Class");

            entity.HasOne(d => d.Major).WithMany(p => p.Students)
                .HasForeignKey(d => d.MajorId)
                .HasConstraintName("FK_Student_Major");
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Subject__3214EC07391183A6");

            entity.ToTable("Subject");

            entity.Property(e => e.ClassId).HasColumnName("ClassID");
            entity.Property(e => e.Name).HasMaxLength(50);

            entity.HasOne(d => d.Class).WithMany(p => p.Subjects)
                .HasForeignKey(d => d.ClassId)
                .HasConstraintName("FK_Subject_Class");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
