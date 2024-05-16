﻿// <auto-generated />
using System;
using ConoverHomeInspections.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ConoverHomeInspections.Migrations
{
    [DbContext(typeof(ConfigDbContext))]
    partial class ConfigDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.5");

            modelBuilder.Entity("ConoverHomeInspections.Shared.Assignment", b =>
                {
                    b.Property<int>("AssignmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CommuteTimeToLocationInMins")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("CompletionTime")
                        .HasColumnType("TEXT");

                    b.Property<int?>("EstimatedCompletionTimeInMins")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("ScheduledTime")
                        .HasColumnType("TEXT");

                    b.HasKey("AssignmentId");

                    b.ToTable("Assignments", (string)null);
                });

            modelBuilder.Entity("ConoverHomeInspections.Shared.AssignmentTask", b =>
                {
                    b.Property<int>("AssignmentId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ServiceId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("TEXT");

                    b.HasKey("AssignmentId", "ServiceId");

                    b.HasIndex("ServiceId");

                    b.ToTable("Tasks", (string)null);
                });

            modelBuilder.Entity("ConoverHomeInspections.Shared.ServiceDetail", b =>
                {
                    b.Property<int>("DetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("TEXT");

                    b.Property<int?>("Order")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ServiceId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("DetailId");

                    b.HasIndex("ServiceId");

                    b.ToTable("Details", (string)null);
                });

            modelBuilder.Entity("ConoverHomeInspections.Shared.SiteGroup", b =>
                {
                    b.Property<int>("GroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<string>("GroupName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<int>("Order")
                        .HasColumnType("INTEGER");

                    b.HasKey("GroupId");

                    b.ToTable("Groups", (string)null);
                });

            modelBuilder.Entity("ConoverHomeInspections.Shared.SiteService", b =>
                {
                    b.Property<int>("ServiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("TEXT");

                    b.Property<int>("EstimatedCompletionTimeInMins")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("GroupId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Order")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("SKU")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ServiceName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.HasKey("ServiceId");

                    b.HasIndex("GroupId");

                    b.ToTable("Services", (string)null);
                });

            modelBuilder.Entity("ConoverHomeInspections.Shared.Assignment", b =>
                {
                    b.OwnsOne("ConoverHomeInspections.Shared.Address", "Location", b1 =>
                        {
                            b1.Property<int>("AssignmentId")
                                .HasColumnType("INTEGER");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<string>("State")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<string>("Street2")
                                .HasColumnType("TEXT");

                            b1.Property<int?>("Zip4")
                                .HasColumnType("INTEGER");

                            b1.Property<int>("ZipCode")
                                .HasColumnType("INTEGER");

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
                        .OnDelete(DeleteBehavior.SetNull)
                        .HasConstraintName("FK_Groups_Services");

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
