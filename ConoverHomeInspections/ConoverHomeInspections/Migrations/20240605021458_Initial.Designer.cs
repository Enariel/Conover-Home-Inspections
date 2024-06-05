﻿// <auto-generated />
using System;
using ConoverHomeInspections.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ConoverHomeInspections.Migrations
{
    [DbContext(typeof(ConfigDbContext))]
    [Migration("20240605021458_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ConoverHomeInspections.Shared.Assignment", b =>
                {
                    b.Property<int>("AssignmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AssignmentId"));

                    b.Property<int?>("CommuteTimeToLocationInMins")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CompletionTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("EstimatedCompletionTimeInMins")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ScheduledTime")
                        .HasColumnType("datetime2");

                    b.HasKey("AssignmentId");

                    b.ToTable("Assignments", (string)null);
                });

            modelBuilder.Entity("ConoverHomeInspections.Shared.AssignmentTask", b =>
                {
                    b.Property<int>("AssignmentId")
                        .HasColumnType("int");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("AssignmentId", "ServiceId");

                    b.HasIndex("ServiceId");

                    b.ToTable("Tasks", (string)null);
                });

            modelBuilder.Entity("ConoverHomeInspections.Shared.ClientContact", b =>
                {
                    b.Property<Guid>("ContactId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<int?>("GroupId")
                        .HasColumnType("int");

                    b.Property<string>("InspectionAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("MailingAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddleInitial")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("NamePrefix")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameSuffix")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("PreferredEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("PreferredStart")
                        .HasColumnType("datetime2");

                    b.Property<bool>("PrefersEmail")
                        .HasColumnType("bit");

                    b.Property<bool>("PrefersPhone")
                        .HasColumnType("bit");

                    b.Property<bool>("PrefersText")
                        .HasColumnType("bit");

                    b.Property<string>("RealtorEmail")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("RealtorFirstName")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("RealtorLastName")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("RealtorPhone")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("RemovedOn")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ServiceId")
                        .HasColumnType("int");

                    b.HasKey("ContactId");

                    b.HasIndex("GroupId");

                    b.HasIndex("ServiceId");

                    b.ToTable("ClientContacts");
                });

            modelBuilder.Entity("ConoverHomeInspections.Shared.ConfigurationSetting", b =>
                {
                    b.Property<int>("SettingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SettingId"));

                    b.Property<int?>("Field")
                        .HasColumnType("int");

                    b.Property<string>("For")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SettingId");

                    b.ToTable("SiteSettings", (string)null);
                });

            modelBuilder.Entity("ConoverHomeInspections.Shared.MailTemplate", b =>
                {
                    b.Property<string>("TemplateName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Body")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subject")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("TemplateName");

                    b.ToTable("EmailTemplates", (string)null);
                });

            modelBuilder.Entity("ConoverHomeInspections.Shared.ServiceDetail", b =>
                {
                    b.Property<int>("DetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DetailId"));

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int?>("Order")
                        .HasColumnType("int");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("DetailId");

                    b.HasIndex("ServiceId");

                    b.ToTable("Details", (string)null);
                });

            modelBuilder.Entity("ConoverHomeInspections.Shared.SiteGroup", b =>
                {
                    b.Property<int>("GroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GroupId"));

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("GroupName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.HasKey("GroupId");

                    b.ToTable("Groups", (string)null);
                });

            modelBuilder.Entity("ConoverHomeInspections.Shared.SiteService", b =>
                {
                    b.Property<int>("ServiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ServiceId"));

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int>("EstimatedCompletionTimeInMins")
                        .HasColumnType("int");

                    b.Property<int?>("GroupId")
                        .HasColumnType("int");

                    b.Property<int?>("Order")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("SKU")
                        .HasColumnType("int");

                    b.Property<string>("ServiceName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("ServiceId");

                    b.HasIndex("GroupId");

                    b.ToTable("Services", (string)null);
                });

            modelBuilder.Entity("ConoverHomeInspections.Shared.Assignment", b =>
                {
                    b.OwnsOne("ConoverHomeInspections.Shared.Address", "Location", b1 =>
                        {
                            b1.Property<int>("AssignmentId")
                                .HasColumnType("int");

                            b1.Property<string>("City")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("State")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Street")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Street2")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<int?>("Zip4")
                                .HasColumnType("int");

                            b1.Property<int>("ZipCode")
                                .HasColumnType("int");

                            b1.HasKey("AssignmentId");

                            b1.ToTable("Assignments");

                            b1.WithOwner()
                                .HasForeignKey("AssignmentId");
                        });

                    b.Navigation("Location");
                });

            modelBuilder.Entity("ConoverHomeInspections.Shared.AssignmentTask", b =>
                {
                    b.HasOne("ConoverHomeInspections.Shared.Assignment", "Assignment")
                        .WithMany("RequestedServices")
                        .HasForeignKey("AssignmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ConoverHomeInspections.Shared.SiteService", "Service")
                        .WithMany("Task")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.Navigation("Assignment");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("ConoverHomeInspections.Shared.ClientContact", b =>
                {
                    b.HasOne("ConoverHomeInspections.Shared.SiteGroup", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .HasConstraintName("FK_ClientContacts_Group");

                    b.HasOne("ConoverHomeInspections.Shared.SiteService", "Service")
                        .WithMany()
                        .HasForeignKey("ServiceId")
                        .HasConstraintName("FK_ClientContacts_Service");

                    b.Navigation("Group");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("ConoverHomeInspections.Shared.ServiceDetail", b =>
                {
                    b.HasOne("ConoverHomeInspections.Shared.SiteService", "Service")
                        .WithMany("Details")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Service");
                });

            modelBuilder.Entity("ConoverHomeInspections.Shared.SiteService", b =>
                {
                    b.HasOne("ConoverHomeInspections.Shared.SiteGroup", "Group")
                        .WithMany("Services")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Group");
                });

            modelBuilder.Entity("ConoverHomeInspections.Shared.Assignment", b =>
                {
                    b.Navigation("RequestedServices");
                });

            modelBuilder.Entity("ConoverHomeInspections.Shared.SiteGroup", b =>
                {
                    b.Navigation("Services");
                });

            modelBuilder.Entity("ConoverHomeInspections.Shared.SiteService", b =>
                {
                    b.Navigation("Details");

                    b.Navigation("Task");
                });
#pragma warning restore 612, 618
        }
    }
}