// ConoverHomeInspections
// ConfigDbContext.cs
//  2024
// Oliver Conover
// Modified: 16-05-2024
using ConoverHomeInspections.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;

namespace ConoverHomeInspections.Data
{
    public class ConfigDbContext : DbContext
    {
        private string _connString = "";

        public ConfigDbContext(DbContextOptions<ConfigDbContext> options) : base(options) {}

        public string ConnectionString
        {
            get
            {
                if (string.IsNullOrEmpty(_connString))
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
        public virtual DbSet<ConfigurationSetting> SiteSettings { get; set; }
        public virtual DbSet<MailTemplate> EmailTemplates { get; set; }
        public virtual DbSet<ClientContact> ClientContacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ClientContact>(entity =>
            {
                entity.HasKey(e => e.ContactId);
                entity.Property(e => e.ContactId)
                      .ValueGeneratedOnAdd();
                entity.Property(e => e.EmailAddress)
                      .IsRequired()
                      .HasMaxLength(255);
                entity.Property(e => e.PhoneNumber)
                      .HasMaxLength(255);
                entity.Property(e => e.FirstName)
                      .IsRequired()
                      .HasMaxLength(128);
                entity.Property(e => e.LastName)
                      .IsRequired()
                      .HasMaxLength(128);
                entity.Property(e => e.RealtorEmail)
                      .HasMaxLength(255);
                entity.Property(e => e.RealtorFirstName)
                      .HasMaxLength(128);
                entity.Property(e => e.RealtorLastName)
                      .HasMaxLength(128);
                entity.Property(e => e.RealtorPhone)
                      .HasMaxLength(255);
                entity.Property(e => e.CreatedOn)
                      .IsRequired();
                entity.HasOne(d => d.Service)
                      .WithMany()
                      .HasForeignKey(d => d.ServiceId)
                      .HasConstraintName("FK_ClientContacts_Service");
                entity.HasOne(d => d.Group)
                      .WithMany()
                      .HasForeignKey(d => d.GroupId)
                      .HasConstraintName("FK_ClientContacts_Group");
            });


            modelBuilder.Entity<ConfigurationSetting>(entity =>
            {
                entity.ToTable("SiteSettings");
                entity.HasKey(s => s.SettingId);
                entity.Property(s => s.SettingId)
                      .ValueGeneratedOnAdd();
                entity.Property(t => t.Name)
                      .HasMaxLength(100);
                entity.Property(t => t.For)
                      .HasMaxLength(100);
                entity.Property(s => s.Field);
            });

            modelBuilder.Entity<MailTemplate>(entity =>
            {
                entity.ToTable("EmailTemplates");
                entity.HasKey(t => t.TemplateName);
                entity.Property(t => t.TemplateName)
                      .HasMaxLength(100);
                entity.Property(t => t.Subject)
                      .HasMaxLength(255);
            });

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
                      .HasForeignKey(ws => ws.AssignmentId)
                      .OnDelete(DeleteBehavior.Cascade);

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
                      .WithMany(g => g.Services)// if Group has a collection of ServiceProduct, define it here
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
            var configPath = Path.Combine(projectDirectory, "ConoverHomeInspections", "wwwroot", "data", "ConfigData.db");
            Console.WriteLine($"Database path: {configPath}");
            var connString = $"Data Source={configPath}";
            return connString;
        }
    }
}