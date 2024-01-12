using Microsoft.EntityFrameworkCore;

namespace Server.Models;

public partial class CarsStoreContext : DbContext
{
    public CarsStoreContext()
    {
    }

    public CarsStoreContext(DbContextOptions<CarsStoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BodyType> BodyTypes { get; set; }
    public virtual DbSet<Manufacturer> Manufacturers { get; set; }
    public virtual DbSet<Order> Orders { get; set; }
    public virtual DbSet<Sample> Samples { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=.\\DB\\CarsStore.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BodyType>(entity =>
        {
            entity.ToTable("BodyType");

            entity.HasIndex(e => e.Id, "IX_BodyType_ID").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Name).HasColumnType("STRING");
        });

        modelBuilder.Entity<Manufacturer>(entity =>
        {
            entity.ToTable("Manufacturer");

            entity.HasIndex(e => e.Id, "IX_Manufacturer_ID").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Name).HasColumnType("STRING");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.ToTable("Order");

            entity.HasIndex(e => e.Id, "IX_Order_ID").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.SampleId).HasColumnName("Sample_ID");

            entity.HasOne(d => d.Sample).WithMany(p => p.Orders)
                .HasForeignKey(d => d.SampleId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Sample>(entity =>
        {
            entity.ToTable("Sample");

            entity.HasIndex(e => e.Id, "IX_Sample_Id").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.BodyTypeId).HasColumnName("BodyTypeID");
            entity.Property(e => e.ManufacturerId).HasColumnName("ManufacturerID");
            entity.Property(e => e.Name).HasColumnType("STRING");

            entity.HasOne(d => d.BodyType).WithMany(p => p.Samples)
                .HasForeignKey(d => d.BodyTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Manufacturer).WithMany(p => p.Samples)
                .HasForeignKey(d => d.ManufacturerId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}