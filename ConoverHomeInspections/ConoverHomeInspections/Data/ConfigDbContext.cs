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

        public virtual DbSet<AssignmentTask> Tasks { get; set; }
        public virtual DbSet<Assignment> Assignments { get; set; }
        public virtual DbSet<SiteGroup> Groups { get; set; }
        public virtual DbSet<SiteService> Services { get; set; }
        public virtual DbSet<ServiceDetail> Details { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(GetConnectionString());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AssignmentTask>(entity =>
            {
                entity.ToTable("Tasks");
                entity.HasKey(w => new { w.AssignmentId, w.ServiceId });
                entity.HasOne(ws => ws.Assignment)
                      .WithMany(wo => wo.RequestedServices)
                      .HasForeignKey(ws => ws.AssignmentId)
                      .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(ws => ws.Service)
                      .WithMany(s => s.Task)
                      .HasForeignKey(ws => ws.ServiceId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Assignment>(entity =>
            {
                entity.ToTable("Assignments");
                entity.HasKey(e => e.AssignmentId);
                entity.Property(e => e.AssignmentId).ValueGeneratedOnAdd();

                entity.HasMany(wo => wo.RequestedServices)
                      .WithOne(ws => ws.Assignment)
                      .HasForeignKey(ws => ws.AssignmentId);

                entity.OwnsOne(e => e.Location);
            });

            modelBuilder.Entity<SiteService>(entity =>
            {
                entity.ToTable("Services");
                entity.HasKey(e => e.ServiceId);
                entity.Property(e => e.ServiceId).ValueGeneratedOnAdd();
                entity.Property(e => e.ServiceName).IsRequired().HasMaxLength(255);
                entity.Property(e => e.Description).HasMaxLength(1000);
                entity.Property(e => e.Price).HasColumnType("decimal(18,2)");

                entity.HasMany(sp => sp.Task)
                      .WithOne(ws => ws.Service)
                      .HasForeignKey(ws => ws.ServiceId)
                      .OnDelete(DeleteBehavior.SetNull);
                entity.HasOne(sp => sp.Group)
                      .WithMany(g=>g.Services)// if Group has a collection of ServiceProduct, define it here
                      .HasForeignKey(sp => sp.GroupId)
                      .OnDelete(DeleteBehavior.SetNull);
                entity.HasMany(e => e.Details)
                      .WithOne(e => e.Service)
                      .HasForeignKey(e => e.ServiceId)
                      .OnDelete(DeleteBehavior.Cascade);
            });


            modelBuilder.Entity<SiteGroup>(entity =>
            {
                entity.ToTable("Groups");
                entity.HasKey(e => e.GroupId);
                entity.Property(e => e.GroupId).ValueGeneratedOnAdd();
                entity.Property(e => e.GroupName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Description).HasMaxLength(500);
            });

            modelBuilder.Entity<ServiceDetail>(entity =>
            {
                entity.ToTable("Details");
                entity.HasKey(e => e.DetailId);
                entity.Property(e => e.DetailId).ValueGeneratedOnAdd();
                entity.Property(e => e.ServiceId).IsRequired();
                entity.Property(e => e.Title).HasMaxLength(100);
                entity.Property(e => e.Description).HasMaxLength(1000);
            });


        }

        public static string GetConnectionString()
        {
            var workingDir = Environment.CurrentDirectory;
            var projectDirectory = Directory.GetParent(workingDir)!.FullName;
            var configPath = Path.Combine(projectDirectory, "ConoverHomeInspections", "Data", "ConfigData.db");
            Console.WriteLine($"Database path: {configPath}");
            var connString = $"Data Source={configPath}";
            return connString;
        }
    }
}