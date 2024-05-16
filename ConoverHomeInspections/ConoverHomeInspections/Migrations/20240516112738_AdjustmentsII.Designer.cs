﻿// <auto-generated />
using System;
using ConoverHomeInspections.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ConoverHomeInspections.Migrations
{
    [DbContext(typeof(ConfigDbContext))]
    [Migration("20240516112738_AdjustmentsII")]
    partial class AdjustmentsII
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.5");

            modelBuilder.Entity("ConoverHomeInspections.Shared.ProductDetail", b =>
                {
                    b.Property<int>("DetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("TEXT");

                    b.Property<int>("ServiceId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("DetailId");

                    b.HasIndex("ServiceId");

                    b.ToTable("Details", (string)null);
                });

            modelBuilder.Entity("ConoverHomeInspections.Shared.ProductGroup", b =>
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

                    b.HasKey("GroupId");

                    b.ToTable("Groups", (string)null);
                });

            modelBuilder.Entity("ConoverHomeInspections.Shared.ServiceProduct", b =>
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

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ServiceName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.HasKey("ServiceId");

                    b.HasIndex("GroupId");

                    b.ToTable("Services", (string)null);
                });

            modelBuilder.Entity("ConoverHomeInspections.Shared.WorkService", b =>
                {
                    b.Property<int>("WorkOrderId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ServiceId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("TEXT");

                    b.HasKey("WorkOrderId", "ServiceId");

                    b.HasIndex("ServiceId");

                    b.ToTable("WorkServices");
                });

            modelBuilder.Entity("ConoverHomeInspections.Shared.WorkUnit", b =>
                {
                    b.Property<int>("WorkOrderId")
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

                    b.HasKey("WorkOrderId");

                    b.ToTable("Assignments", (string)null);
                });

            modelBuilder.Entity("ConoverHomeInspections.Shared.ProductDetail", b =>
                {
                    b.HasOne("ConoverHomeInspections.Shared.ServiceProduct", "Service")
                        .WithMany("Details")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Service");
                });

            modelBuilder.Entity("ConoverHomeInspections.Shared.ServiceProduct", b =>
                {
                    b.HasOne("ConoverHomeInspections.Shared.ProductGroup", "Group")
                        .WithMany("Services")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .HasConstraintName("FK_Groups_Services");

                    b.Navigation("Group");
                });

            modelBuilder.Entity("ConoverHomeInspections.Shared.WorkService", b =>
                {
                    b.HasOne("ConoverHomeInspections.Shared.ServiceProduct", "Service")
                        .WithMany("WorkServices")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.HasOne("ConoverHomeInspections.Shared.WorkUnit", "WorkOrder")
                        .WithMany("RequestedServices")
                        .HasForeignKey("WorkOrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Service");

                    b.Navigation("WorkOrder");
                });

            modelBuilder.Entity("ConoverHomeInspections.Shared.WorkUnit", b =>
                {
                    b.OwnsOne("ConoverHomeInspections.Shared.Address", "Location", b1 =>
                        {
                            b1.Property<int>("WorkUnitWorkOrderId")
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

                            b1.HasKey("WorkUnitWorkOrderId");

                            b1.ToTable("Assignments");

                            b1.WithOwner()
                                .HasForeignKey("WorkUnitWorkOrderId");
                        });

                    b.Navigation("Location");
                });

            modelBuilder.Entity("ConoverHomeInspections.Shared.ProductGroup", b =>
                {
                    b.Navigation("Services");
                });

            modelBuilder.Entity("ConoverHomeInspections.Shared.ServiceProduct", b =>
                {
                    b.Navigation("Details");

                    b.Navigation("WorkServices");
                });

            modelBuilder.Entity("ConoverHomeInspections.Shared.WorkUnit", b =>
                {
                    b.Navigation("RequestedServices");
                });
#pragma warning restore 612, 618
        }
    }
}
