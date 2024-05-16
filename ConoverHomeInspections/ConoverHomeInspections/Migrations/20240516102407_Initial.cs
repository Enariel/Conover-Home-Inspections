using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConoverHomeInspections.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Assignments",
                columns: table => new
                {
                    WorkOrderId = table.Column<int>(type: "INTEGER", nullable: false),
                    Location_Street = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    Location_Street2 = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    Location_City = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Location_State = table.Column<string>(type: "TEXT", maxLength: 2, nullable: true),
                    Location_ZipCode = table.Column<int>(type: "INTEGER", maxLength: 6, nullable: true),
                    Location_Zip4 = table.Column<int>(type: "INTEGER", maxLength: 4, nullable: true),
                    EstimatedCompletionTimeInMins = table.Column<int>(type: "INTEGER", nullable: true),
                    CommuteTimeToLocationInMins = table.Column<int>(type: "INTEGER", nullable: true),
                    ScheduledTime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CompletionTime = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignments", x => x.WorkOrderId);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    GroupId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GroupName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.GroupId);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    ServiceId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GroupId = table.Column<int>(type: "INTEGER", nullable: true),
                    ServiceName = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EstimatedCompletionTimeInMins = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductGroupGroupId = table.Column<int>(type: "INTEGER", nullable: true),
                    WorkUnitWorkOrderId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.ServiceId);
                    table.ForeignKey(
                        name: "FK_Services_Assignments_WorkUnitWorkOrderId",
                        column: x => x.WorkUnitWorkOrderId,
                        principalTable: "Assignments",
                        principalColumn: "WorkOrderId");
                    table.ForeignKey(
                        name: "FK_Services_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Services_Groups_ProductGroupGroupId",
                        column: x => x.ProductGroupGroupId,
                        principalTable: "Groups",
                        principalColumn: "GroupId");
                });

            migrationBuilder.CreateTable(
                name: "Details",
                columns: table => new
                {
                    DetailId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ServiceId = table.Column<int>(type: "INTEGER", nullable: false),
                    Title = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Details", x => x.DetailId);
                    table.ForeignKey(
                        name: "FK_Details_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "ServiceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Details_ServiceId",
                table: "Details",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_GroupId",
                table: "Services",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_ProductGroupGroupId",
                table: "Services",
                column: "ProductGroupGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_WorkUnitWorkOrderId",
                table: "Services",
                column: "WorkUnitWorkOrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Details");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Assignments");

            migrationBuilder.DropTable(
                name: "Groups");
        }
    }
}
