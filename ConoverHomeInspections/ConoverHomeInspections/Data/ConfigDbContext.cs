// ConoverHomeInspections
// ConfigDbContext.cs
//  2024
// Oliver Conover
// Modified: 16-05-2024
using ConoverHomeInspections.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace ConoverHomeInspections.Data
{
    public class ConfigDbContext : DbContext
    {
        private string _connString = "";
        public ConfigDbContext() : base() {}
        public ConfigDbContext(DbContextOptions<ConfigDbContext> options) : base(options) {}

        public string ConnectionString
        {
            get
            {
                if (_connString.IsNullOrEmpty())
                    _connString = GetConnectionString();
                return _connString;
            }
            private set => _connString = value;
        }

        // Tables

        public virtual DbSet<ProductGroup> Groups { get; set; }
        public virtual DbSet<ServiceProduct> Services { get; set; }
        public virtual DbSet<ProductDetail> Details { get; set; }
        public virtual DbSet<WorkUnit> WorkUnits { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(GetConnectionString());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ServiceProduct>(entity =>
            {
                entity.ToTable("Services");
                entity.HasKey(e => e.ServiceId);
                entity.Property(e => e.ServiceId).ValueGeneratedOnAdd();
                entity.Property(e => e.ServiceName).IsRequired().HasMaxLength(255);
                entity.Property(e => e.Description).HasMaxLength(1000);
                entity.Property(e => e.Price).HasColumnType("decimal(18,2)");

                entity.HasOne(e=>e.Group)
                      .WithMany()
                      .HasForeignKey(e=>e.GroupId)
                      .OnDelete(DeleteBehavior.SetNull);
                entity.HasMany(e => e.Details)
                      .WithOne(e => e.Service)
                      .HasForeignKey(e => e.ServiceId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<ProductDetail>(entity =>
            {
                entity.ToTable("Details");
                entity.HasKey(e => e.DetailId);
                entity.Property(e => e.DetailId).ValueGeneratedOnAdd();
                entity.Property(e => e.ServiceId).IsRequired();
                entity.Property(e => e.Title).HasMaxLength(100);
                entity.Property(e => e.Description).HasMaxLength(1000);
            });

            modelBuilder.Entity<ProductGroup>(entity =>
            {
                entity.ToTable("Groups");
                entity.HasKey(e => e.GroupId);
                entity.Property(e => e.GroupId).ValueGeneratedOnAdd();
                entity.Property(e => e.GroupName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Description).HasMaxLength(500);
            });

            modelBuilder.Entity<WorkUnit>(entity =>
            {
                entity.ToTable("Assignments");
                entity.HasKey(e => e.WorkOrderId);
                entity.Property(e => e.WorkOrderId).ValueGeneratedOnAdd();

                entity.HasMany(e => e.Services)
                      .WithOne()
                      .OnDelete(DeleteBehavior.NoAction);

                entity.OwnsOne(e => e.Location, location => {
                    location.Property(e => e.Street).HasMaxLength(255);
                    location.Property(e => e.Street2).HasMaxLength(255);
                    location.Property(e => e.City).HasMaxLength(100);
                    location.Property(e => e.State).HasMaxLength(2);
                    location.Property(e => e.ZipCode).HasMaxLength(6);
                    location.Property(e => e.Zip4).HasMaxLength(4);
                });
            });
        }

        public static string GetConnectionString()
        {
            var workingDir = Environment.CurrentDirectory;
            var projectDirectory = Directory.GetParent(workingDir)!.FullName;
            var configPath = Path.Combine(projectDirectory,"ConoverHomeInspections", "Data", "ConfigData.db");
            Console.WriteLine($"Database path: {configPath}");
            var connString = $"Data Source={configPath}";
            return connString;
        }
    }
}